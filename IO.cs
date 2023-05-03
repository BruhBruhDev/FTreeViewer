using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTreeViewer
{
    static partial class Data
    {
        private static string _null = "null";
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
            int iProp = 0, propExpect = 7, meta = 0, lineCounter = 1, result = fs.ReadByte();
            StringBuilder sb = new StringBuilder();
            string[] prop = new string[_maxProp];
            while (result != -1)
            {
                c = (char)result;
                if (c == '\n')
                {
                    prop[iProp++] = sb.ToString();
                    sb.Clear();
                    
                    if (meta == 0 && iProp > 0) // if meta data possible
                    {
                        if (prop[0] != "meta") // if no meta data
                            meta = -1000;
                        else
                        {
                            //interpret
                            //...
                            
                            meta = 1;
                            iProp = 0;
                            lineCounter++;
                            prop = new string[_maxProp];
                            result = fs.ReadByte();
                            continue;
                        }
                    }
                    if (iProp == propExpect)
                        iProp = 0;
                    else throw new FormatException("File format inconsistent or dismatches expected format. Expected properties: "+propExpect+", got: "+iProp+", on line: "+lineCounter);
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
            byte[] arr = Encoding.ASCII.GetBytes("meta,v=1.0.0\n");
            fs.Write(arr, 0, arr.Length);
            for (int i = 0; i < GetAmountPeople(); i++)
            {
                Person p = People[i];
                if (p == null) continue;
                arr = Encoding.ASCII.GetBytes(string.Format(_datasetFormat, p.id,
                    p.ParentMum == null ? _null : p.ParentMum.id.ToString(), p.ParentDad == null ? _null : p.ParentDad.id.ToString(),
                    p.FirstName, p.FullName, p.undefinedPos ? _null : p.Pos.X.ToString(), p.undefinedPos ? _null : p.Pos.Y.ToString()));
                fs.Write(arr, 0, arr.Length);
            }
            fs.Close();
        }

    }
}
