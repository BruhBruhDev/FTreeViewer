using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTreeViewer
{
    static partial class Data
    {
        public static void DEPRECATEDReadManualData()
        {
            int[] x =  {
                CreatePerson("", ""),

                CreatePerson("Rinata", "1"),
                CreatePerson("Vladimir", "2"),
                CreatePerson("Magda", "3"),
                CreatePerson("Anatolii", "4"),
                CreatePerson("Stas", "5"),
                CreatePerson("Edgar", "6"),
                CreatePerson("David", "7"),
                CreatePerson("Leonid", "8"),
                CreatePerson("Katja", "9"),
                CreatePerson("Pjotr", "10"),
                CreatePerson("Lyba", "11"),
                CreatePerson("Artur", "12"),
                CreatePerson("Ira", "13"),
                CreatePerson("Valera", "14"),
                CreatePerson("Rosa", "15"),
                CreatePerson("Unbekannt", "16"),
                CreatePerson("Antanina", "17"),
                CreatePerson("Valentin", "18"),
                CreatePerson("Olga", "19"),
                CreatePerson("Vadim", "20"),
                CreatePerson("Evgeni", "21"),
                CreatePerson("Olesja", "22"),
                CreatePerson("Mischa", "23"),
                CreatePerson("Papa?", "24"),
                CreatePerson("Anja", "25"),
                CreatePerson("Ljenja", "26"),
                CreatePerson("Sonja", "27"),
                CreatePerson("Amrastan", "28"),
                CreatePerson("Mama?", "29"),
                CreatePerson("Karp", "30"),
                CreatePerson("Asad", "31"),
                CreatePerson("Dosmamed", "32"),
                CreatePerson("Junus/Jura","33"),
                CreatePerson("Sweta", "34"),
                CreatePerson("Galja", "35"),
                CreatePerson("Lida", "36"),
                CreatePerson("Teresa", "37"),
                CreatePerson("Akop", "38"),
                CreatePerson("Armina", "39"),
                CreatePerson("Lewa","40"),
                CreatePerson("Riwa", "41"),
                CreatePerson("Zjama", "42"),
                CreatePerson("Tochter?","43"),
                CreatePerson("Lewa", "44"),
                CreatePerson("Mama?", "45"),
                CreatePerson("Raja", "46"),
                CreatePerson("Senja", "47"),
                CreatePerson("Dima", "48"),
                CreatePerson("Rita", "49"),
                CreatePerson("Vlad", "50"),
                CreatePerson("Arkadii", "51"),
                CreatePerson("Sascha", "52"),
                CreatePerson("Sascha", "53"),
                CreatePerson("Tansaja", "54"),
                CreatePerson("Fanja", "55"),
                CreatePerson("Edik", "56"),
                CreatePerson("Borja", "57"),
                CreatePerson("Olga", "58"),
                CreatePerson("Rita", "59"),
                CreatePerson("Pascha", "60"),
                CreatePerson("Diana", "61"),
                CreatePerson("David", "62"),
                
                //CreatePerson("", ""),
                //CreatePerson("", ""),
            };

            SetMother(x[1], x[25]);
            SetFather(x[1], x[26]);
            SetMother(x[2], x[27]);
            SetFather(x[2], x[28]);
            SetMother(x[3], x[1]);
            SetFather(x[3], x[2]);
            SetMother(x[4], x[9]);
            SetFather(x[4], x[10]);
            SetMother(x[5], x[13]);
            SetFather(x[5], x[14]);
            SetMother(x[6], x[3]);
            SetFather(x[6], x[4]);
            SetMother(x[7], x[3]);
            SetFather(x[7], x[4]);
            SetMother(x[8], x[3]);
            SetFather(x[8], x[5]);
            SetMother(x[9], -1);
            SetFather(x[9], -1);
            SetMother(x[10], -1);
            SetFather(x[10], -1);
            SetMother(x[11], x[9]);
            SetFather(x[11], x[10]);
            SetMother(x[12], x[11]);
            SetFather(x[12], x[24]);
            SetMother(x[13], x[17]);
            SetFather(x[13], x[18]);
            SetMother(x[14], x[15]);
            SetFather(x[14], x[16]);
            SetMother(x[15], -1);
            SetFather(x[15], -1);
            SetMother(x[16], -1);
            SetFather(x[16], -1);
            SetMother(x[17], -1);
            SetFather(x[17], -1);
            SetMother(x[18], -1);
            SetFather(x[18], -1);
            SetMother(x[19], x[17]);
            SetFather(x[19], x[18]);
            SetMother(x[20], x[19]);
            SetFather(x[20], x[21]);
            SetMother(x[21], -1);
            SetFather(x[21], -1);
            SetMother(x[22], -1);
            SetFather(x[22], -1);
            SetMother(x[23], x[22]);
            SetFather(x[23], x[20]);
            SetMother(x[24], -1);
            SetFather(x[24], -1);
            SetMother(x[25], x[45]);
            SetFather(x[25], x[44]);
            SetMother(x[26], x[41]);
            SetFather(x[26], x[42]);
            SetMother(x[27], x[29]);
            SetFather(x[27], x[30]);
            SetMother(x[28], -1);
            SetFather(x[28], -1);
            SetMother(x[29], -1);
            SetFather(x[29], -1);
            SetMother(x[30], -1);
            SetFather(x[30], -1);
            SetMother(x[31], -1);
            SetFather(x[31], -1);
            SetMother(x[32], -1);
            SetFather(x[32], -1);
            SetMother(x[33], x[27]);
            SetFather(x[33], x[32]);
            SetMother(x[34], x[27]);
            SetFather(x[34], x[31]);
            SetMother(x[35], x[29]);
            SetFather(x[35], x[30]);
            SetMother(x[36], x[35]);
            SetFather(x[36], -1);
            SetMother(x[37], -1);
            SetFather(x[37], -1);
            SetMother(x[38], x[37]);
            SetFather(x[38], x[28]);
            SetMother(x[39], x[37]);
            SetFather(x[39], x[28]);
            SetMother(x[40], x[37]);
            SetFather(x[40], x[28]);
            SetMother(x[41], -1);
            SetFather(x[41], -1);
            SetMother(x[42], -1);
            SetFather(x[42], -1);
            SetMother(x[43], x[41]);
            SetFather(x[43], x[42]);
            SetMother(x[44], -1);
            SetFather(x[44], -1);
            SetMother(x[45], -1);
            SetFather(x[45], -1);
            SetMother(x[46], x[45]);
            SetFather(x[46], x[44]);
            SetMother(x[47], x[45]);
            SetFather(x[47], x[44]);
            SetMother(x[48], x[45]);
            SetFather(x[48], x[44]);
            SetMother(x[49], x[45]);
            SetFather(x[49], x[44]);
            SetMother(x[50], x[25]);
            SetFather(x[50], x[26]);
            SetMother(x[51], x[25]);
            SetFather(x[51], -1);
            SetMother(x[52], x[25]);
            SetFather(x[52], -1);
            SetMother(x[53], x[25]);
            SetFather(x[53], -1);
            SetMother(x[54], x[25]);
            SetFather(x[54], -1);
            SetMother(x[55], -1);
            SetFather(x[55], -1);
            SetMother(x[56], x[55]);
            SetFather(x[56], x[53]);
            SetMother(x[57], -1);
            SetFather(x[57], -1);
            SetMother(x[58], x[54]);
            SetFather(x[58], x[57]);
            SetMother(x[59], x[54]);
            SetFather(x[59], x[57]);
            SetMother(x[60], -1);
            SetFather(x[60], -1);
            SetMother(x[61], x[58]);
            SetFather(x[61], x[60]);
            SetMother(x[62], x[58]);
            SetFather(x[62], -1);
            

        }

        public static void ReadData2000()
        {
            int[] x =  {
                CreatePerson("Edgar", "6"),
                CreatePerson("Magda", "3"),
                CreatePerson("Anatolii", "4"),
                CreatePerson("Rinata", "1"),
                CreatePerson("Vladimir", "2"),

                CreatePerson("Ljenja", "26"),
                CreatePerson("Riwa", "41"),
                CreatePerson("Zjama", "42"),
                CreatePerson("Anja", "25"),
                CreatePerson("Lewa", "44"),

                CreatePerson("Mama?", "45"),
                CreatePerson("Rita", "49"),
                CreatePerson("Dima", "48"),
                CreatePerson("Senja", "47"),
                CreatePerson("Raja", "46"),

                CreatePerson("David", "7"),
                CreatePerson("Leonid", "8"),
                CreatePerson("Stas", "5"),
                CreatePerson("Ira", "13"),
                CreatePerson("Valera", "14"),

                // -----------------------

                CreatePerson("Katja", "9"),
                CreatePerson("Pjotr", "10"),
                CreatePerson("Lyba", "11"),
                CreatePerson("Artur", "12"),
                CreatePerson("Papa?", "24"),

                CreatePerson("Vlad", "50"),
                CreatePerson("Arkadii", "51"),
                CreatePerson("Sascha", "52"),
                CreatePerson("Sascha", "53"),
                CreatePerson("Tanja", "54"),

                CreatePerson("Fanja", "55"),
                CreatePerson("Edik", "56"),
                CreatePerson("Borja", "57"),
                CreatePerson("Rita", "59"),
                CreatePerson("Olga", "58"),

                CreatePerson("David", "62"),
                CreatePerson("Pascha", "60"),
                CreatePerson("Diana", "61"),
                CreatePerson("Tochter?","43"),
                CreatePerson("Sofja", "27"),

                // -----------------------

                CreatePerson("Amrastan", "28"),
                CreatePerson("Armina", "39"),
                CreatePerson("Teresa", "37"),
                CreatePerson("Lewa","40"),
                CreatePerson("Akop", "38"),

                CreatePerson("Asad", "31"),
                CreatePerson("Sweta", "34"),
                CreatePerson("Dosmamed", "32"),
                CreatePerson("Junus","33"),
                CreatePerson("Karp", "30"),

                CreatePerson("Mama?", "29"),
                CreatePerson("Galya", "35"),
                CreatePerson("Lida", "36"),
                //CreatePerson("", ""),
                //CreatePerson("", ""),
            };


            {
                SetMother(x[0], x[1]);
                SetFather(x[0], x[2]);
                SetMother(x[1], x[3]);
                SetFather(x[1], x[4]);
                SetMother(x[2], x[20]);
                SetFather(x[2], x[21]);
                SetMother(x[3], x[8]);
                SetFather(x[3], x[5]);
                SetMother(x[4], x[39]);
                SetFather(x[4], x[40]);

            }
            {
                SetMother(x[5], x[6]);
                SetFather(x[5], x[7]);
                SetMother(x[6], -1);
                SetFather(x[6], -1);
                SetMother(x[7], -1);
                SetFather(x[7], -1);
                SetMother(x[8], x[10]);
                SetFather(x[8], x[9]);
                SetMother(x[9], -1);
                SetFather(x[9], -1);
            }
            {
                SetMother(x[10], -1);
                SetFather(x[10], -1);
                SetMother(x[11], x[10]);
                SetFather(x[11], x[9]);
                SetMother(x[12], x[10]);
                SetFather(x[12], x[9]);
                SetMother(x[13], x[10]);
                SetFather(x[13], x[9]);
                SetMother(x[14], x[10]);
                SetFather(x[14], x[9]);
            }
            {
                SetMother(x[15], x[1]);
                SetFather(x[15], x[2]);
                SetMother(x[16], x[1]);
                SetFather(x[16], x[17]);
                SetMother(x[17], x[18]);
                SetFather(x[17], x[19]);
                //SetMother(x[18], x[0]);
                //SetFather(x[18], x[0]);
                //SetMother(x[19], x[0]);
                //SetFather(x[19], x[0]);
            }

            // ---------------

            {
                SetMother(x[20], -1);
                SetFather(x[20], -1);
                SetMother(x[21], -1);
                SetFather(x[21], -1);
                SetMother(x[22], x[20]);
                SetFather(x[22], x[21]);
                SetMother(x[23], x[22]);
                SetFather(x[23], x[24]);
                SetMother(x[24], -1);
                SetFather(x[24], -1);
            }
            {
                SetMother(x[25], x[8]);
                SetFather(x[25], x[5]);
                SetMother(x[26], x[8]);
                SetFather(x[26], -1);
                SetMother(x[27], -1);
                SetFather(x[27], -1);
                SetMother(x[28], x[8]);
                SetFather(x[28], -1);
                SetMother(x[29], x[8]);
                SetFather(x[29], -1);
            }
            {
                SetMother(x[30], -1);
                SetFather(x[30], -1);
                SetMother(x[31], x[30]);
                SetFather(x[31], x[28]);
                SetMother(x[32], -1);
                SetFather(x[32], -1);
                SetMother(x[33], x[29]);
                SetFather(x[33], x[32]);
                SetMother(x[34], x[29]);
                SetFather(x[34], x[32]);
            }
            {
                SetMother(x[35], x[34]);
                SetFather(x[35], -1);
                SetMother(x[36], -1);
                SetFather(x[36], -1);
                SetMother(x[37], x[34]);
                SetFather(x[37], x[36]);
                SetMother(x[38], x[6]);
                SetFather(x[38], x[7]);
                SetMother(x[39], x[50]);
                SetFather(x[39], x[49]);
            }

            // ---------------

            {
                SetMother(x[40], -1);
                SetFather(x[40], -1);
                SetMother(x[41], -1);
                SetFather(x[41], -1);
                SetMother(x[42], x[34]);
                SetFather(x[42], x[36]);
                SetMother(x[43], x[6]);
                SetFather(x[43], x[7]);
                SetMother(x[44], x[50]);
                SetFather(x[44], x[49]);
            }


        }
    }
}
