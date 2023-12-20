using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    internal class Seed
    {
        public long[] Locations { get; set; } = [];


        public Seed(long start, long range)
        {
            Locations = [start, start + range];
        }

        public bool isInRange(long num)
        {
            return Locations[0] <= num && num <= Locations[1];
        }
    }
}
