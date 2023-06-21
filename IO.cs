using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTreeViewer
{
    static partial class Data
    {
        private static string _null = "null";
        private static string CSV_FILE_VERSION = "1.1.0";
        private static string _datasetFormat = "{0},{1},{2},{3},{4},{5},{6}\n"; // id, mumId, dadId, firstname, fullname, posX, posY
        public static void ReadCSV(string str)
        {
            NEW();

            var issues = new List<(int line, int property)>();

            int _maxProp = 30;
            int iP = 0;
            int[] personId = new int[_maxEntities];
            int[] personMumId = new int[_maxEntities];
            int[] personDadId = new int[_maxEntities];
            string[] personFirst = new string[_maxEntities];
            string[] personFull = new string[_maxEntities];
            var personPos = new (int X, int Y)[_maxEntities];
            bool[] personUndefinedPos = new bool[_maxEntities];

            FileStream fs = File.Open(str, FileMode.Open);
            char c;
            bool headers = false, escape = false;
            int iProp = 0, // counter of properties for the current object
                propExpect = 7, // expected amount of columns / properties ; constant
                meta = 0, // blabla look in the code
                lineCounter = 1, // counts the global current line in the file. Mainly for better error messages
                result = fs.ReadByte(); // saves the byte thingy
            StringBuilder sb = new StringBuilder();
            string[] prop = new string[_maxProp];
            while (result != -1)
            {
                c = (char)result;

                if (c == '\\' && !escape)
                {
                    escape = true;
                    result = fs.ReadByte(); // next char
                    continue;
                }
                if (escape)
                {
                    escape = false;
                    if (c == '\n')
                        lineCounter++;
                    sb.Append(c);
                    result = fs.ReadByte();
                    continue;
                }
                // there are no further checks after the code above regarding badly escaped stuff.
                // Its going to brake the file at some point anyway, because of too many props or something. Its dumb to check all the other cases

                if (c == '\n')
                {
                    prop[iProp++] = sb.ToString(); // iProp is equivalent to arr length after the operation
                    sb.Clear();
                    
                    if (meta == 0 && iProp > 0) // if meta data possible
                    {
                        if (prop[0] != "meta") // if no meta data
                            meta = -1000; // idk, do something?
                        else
                        {
                            //interpret
                            //...

                            // check could be made more flexible, but too lazy [--> I mean it only checks the fixed index X]
                            if (iProp > 1 && prop[1].Contains("v=")) // I guess its ok if version is not specified. Would be otherwise annoying doing manual changes
                            {
                                if (Version.TryParse(prop[1].Substring(2), out Version v)) // NOTE the inline var declaration feature seems dumb, unnecessary feature, maybe remove
                                {
                                    if (v.Minor > Version.Parse(CSV_FILE_VERSION).Major)
                                        throw new VersionNotFoundException("CSV file major-version is newer and therefore expected to brake");
                                }
                                else
                                    throw new VersionNotFoundException("CSV-file version-string format is not supported");
                            }
                            if (iProp > 2 && prop[2].Contains("headers=") && prop[2].Contains("true"))
                                headers = true;

                            meta = 1;
                            iProp = 0;
                            lineCounter++;
                            prop = new string[_maxProp];
                            result = fs.ReadByte();
                            continue;
                        }
                    }
                    if (meta == 1 && headers && iProp > 0) // if metadata exists and headers set to =true then basically skip ths row
                    {
                        meta = 2;
                        iProp = 0;
                        lineCounter++;
                        prop = new string[_maxProp];
                        result = fs.ReadByte();
                        continue;
                    }
                    if (iProp == propExpect)
                        iProp = 0;
                    else throw new FormatException("File format inconsistent or mismatches expected format. Expected properties: "+propExpect+", got: "+iProp+", on line: "+lineCounter);
                    // stack data set
                    int id = -1;
                    if (!int.TryParse(prop[0], out id)) issues.Add((lineCounter, 0));
                    if (id < -1) id = -1;
                    if (id > _maxEntities - 1) throw new ArgumentOutOfRangeException("File contains exceeding ids. Current limit: "+_maxEntities+", id parsed: "+id+", on line: "+lineCounter);
                    personId[iP] = id;

                    if (prop[1] == _null || !int.TryParse(prop[1], out personMumId[iP])) personMumId[iP] = -1;
                    else issues.Add((lineCounter, 1));
                    if (prop[2] == _null || !int.TryParse(prop[2], out personDadId[iP])) personDadId[iP] = -1;
                    else issues.Add((lineCounter, 2));
                    personFirst[iP] = prop[3];
                    personFull[iP] = prop[4];
                    bool b = false;
                    personPos[iP] = (0,0);
                    if (prop[5] == _null || !int.TryParse(prop[5], out personPos[iP].X)) b = true;
                    else issues.Add((lineCounter, 5));
                    if (prop[6] == _null || !int.TryParse(prop[6], out personPos[iP].Y)) b = true;
                    else issues.Add((lineCounter, 6));
                    personUndefinedPos[iP] = b;
                    
                    iP++;
                    prop = new string[_maxProp];
                    lineCounter++;
                }
                else
                {
                    if (c == ',')
                    {
                        prop[iProp++] = sb.ToString();
                        iProp %= prop.Length; // in case of too many properties
                        sb.Clear();
                    }
                    else
                        sb.Append(c);
                }
                result = fs.ReadByte();
            }
            fs.Close();
            // TODO figure out a way to sort and fill holes if there is a need to (in case of missing entries in between)
            for (int i = 0; i < iP; i++)
            {
                CreatePerson(personFirst[i], personFull[i], personId[i]);
            }
            for (int i = 0; i < iP; i++)
            {
                int id = personId[i];
                if (personMumId[i] != -1) People[id].ParentMum = People[personMumId[i]];
                if (personDadId[i] != -1) People[id].ParentDad = People[personDadId[i]];
                
                People[id].undefinedPos = personUndefinedPos[i];
                if (!People[id].undefinedPos)
                {
                    People[id].Pos.X = personPos[i].X;
                    People[id].Pos.Y = personPos[i].Y;
                }
            }
            Data.SetUndefinedPosPeople();
        }
        public static void WriteCSV(string str)
        {
            FileStream fs = File.Open(str, FileMode.Create);
            byte[] arr = Encoding.ASCII.GetBytes("meta,v="+CSV_FILE_VERSION+",headers=true\nID,ID_Mother,ID_Father, First Name, Full Name, Pos X, Pos Y\n");
            fs.Write(arr, 0, arr.Length);
            for (int i = 0; i < GetAmountPeople(); i++)
            {
                Person p = People[i];
                if (p == null) continue;
                string row = PersonToString(p);
                arr = Encoding.ASCII.GetBytes(row);
                fs.Write(arr, 0, arr.Length);
            }
            fs.Close();
        }
        public static int[] ListDataThatNeedsEscaping()
        {
            var list = new List<int>();
            for (int i = 0; i < GetAmountPeople(); i++)
            {
                Person p = People[i];
                if (p == null) continue;
                if (PersonToString(p).Contains('\\'))
                    list.Add(p.id);
            }
            return list.ToArray();
        }
        public static bool DoesDataNeedEscaping() // this one is kinda redundant
        {
            bool b = false;
            for (int i = 0; i < GetAmountPeople(); i++)
            {
                Person p = People[i];
                if (p == null) continue;
                if (PersonToString(p).Contains('\\'))
                {
                    b = true;
                    break;
                }
            }
            return b;
        }
        private static string PersonToString(Person p)
        {
            return string.Format(_datasetFormat, p.id,
                    p.ParentMum == null ? _null : p.ParentMum.id.ToString(),
                    p.ParentDad == null ? _null : p.ParentDad.id.ToString(),
                    FilterStr(p.FirstName), FilterStr(p.FullName),
                    p.undefinedPos ? _null : p.Pos.X.ToString(),
                    p.undefinedPos ? _null : p.Pos.Y.ToString());
        }
        private static string FilterStr(string s)
        {
            // escape special chars. maybe there are some more which need to be checked but this should do
            s = s.Replace("\\", "\\\\");
            s = s.Replace(",", "\\,");
            s = s.Replace("\n", "\\\n");
            return s;
        }
    }
}
