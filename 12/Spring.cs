using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _12
{
    internal class Spring(string input, List<int> groups)
    {
        public string Input { get; set; } = input;
        public List<int> Groups { get; set; } = groups;
        public int Possibilities { get; set; } = 0;



        public void GenerateCombinations()
        {
            Generate(Input, 0);
        }

        private void Generate(string input, int index)
        {
            if (index == input.Length)
                CheckInput(input);

            else if (input[index] == '?')
            {
                input = input.Substring(0, index) + '#' + input.Substring(index + 1);
                Generate(input, index + 1);

                input = input.Substring(0, index) + '.' + input.Substring(index + 1);
                Generate(input, index + 1);
            }
            else
                Generate(input, index + 1);
        }

        private void CheckInput(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"(#+)");

            if(matches.Count == Groups.Count)
            {
                bool isPossible = true;
                for (int i = 0; i < matches.Count; i++)
                {
                    if (Groups[i] != matches[i].Length)
                    {
                        isPossible = false;
                        break;
                    }
                }

                if (isPossible)
                    Possibilities++;
            }
        }
    }
}
