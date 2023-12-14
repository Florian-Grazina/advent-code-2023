using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _13
{
    internal class Pattern(string[] lines)
    {
        public string[] Lines = lines;
        public int NbOfRows { get; set; } = 0;
        public int NbOfColumns { get; set; } = 0;
        public List<string> Possibilities { get; set; }


        internal void CheckMirrors()
        {
            string[] copyLines = new string[Lines.Length];
            Array.Copy(Lines, copyLines, Lines.Length);

            NbOfRows = Check(copyLines);

            // rotate pattern
            List<string> rotatedPattern = [];

            for (int y = 0; y < Lines.Length; y++)
            {
                Console.Clear();
                for (int x = 0; x < Lines[0].Length; x++)
                {
                    if (y == 0)
                    {
                        rotatedPattern.Add(Lines[y][x].ToString());
                    }
                    else
                    {
                        rotatedPattern[x] = rotatedPattern[x].Insert(0,Lines[y][x].ToString());

                    }
                    Console.WriteLine(rotatedPattern[x]);
                }
            }

            NbOfColumns = Check(rotatedPattern.ToArray());
        }

        private int Check(string[] lines)
        {
            bool smudgeFound = false;
            // check Y
            for (int i = 0; i < lines.Length - 1; i++)
            {
                bool isMirror = true;
                for (int j = 0; i + j >= 0 && i - j + 1 < lines.Length; j--)
                {
                    if (lines[i + j] != lines[i - j + 1])
                    {
                        isMirror = false;
                        if (!smudgeFound)
                        {
                            for(int k = 0; k < lines[0].Length; k++)
                            {
                                string newLine = "";

                                if (lines[i + j][k] == '.')
                                    newLine = lines[i + j].Substring(0, k) + '#' + lines[i + j].Substring(k + 1);
                                else
                                    newLine = lines[i + j].Substring(0, k) + '.' + lines[i + j].Substring(k + 1);

                                if (newLine == lines[i - j + 1])
                                {
                                    isMirror = true;
                                    smudgeFound = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (isMirror && smudgeFound)
                {
                    return i + 1;
                }

                else smudgeFound = false;
            }
            return 0;
            //if(toReturn == null)
            //    return 0;
            //else
            //    return toReturn.Value + 1; 
        }
    }
}
