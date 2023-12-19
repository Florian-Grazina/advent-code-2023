using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _19
{
    public enum Status
    {
        accepted, rejected
    }

    internal class Part
    {
        public int X { get; set; }
        public int M { get; set; }
        public int A { get; set; }
        public int S { get; set; }
        public Status? Status { get; set; }

        public int Total => X + M + A + S;


        public Part(string input)
        {
            Parse(input);
        }


        private void Parse(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"(\d+)");

            X = int.Parse(matches[0].ToString());
            M = int.Parse(matches[1].ToString());
            A = int.Parse(matches[2].ToString());
            S = int.Parse(matches[3].ToString());
        }
    }
}
