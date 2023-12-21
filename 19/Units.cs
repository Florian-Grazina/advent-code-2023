using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19
{
    internal class Units(long number, (int, int) rangeX, (int, int) rangeM, (int, int) rangeA, (int, int) rangeS, string command) : ICloneable
    {
        public long Number { get; set; } = number;
        public (int, int) RangeX { get; set; } = rangeX;
        public (int, int) RangeM { get; set; } = rangeM;
        public (int, int) RangeA { get; set; } = rangeA;
        public (int, int) RangeS { get; set; } = rangeS;
        public string Command { get; set; } = command;


        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
