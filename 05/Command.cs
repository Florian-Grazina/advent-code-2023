using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    public enum Soil
    {
        none, bitch, seed, soil, fertilizer, water, light, temp, humidity
    }

    internal class Command(long dest, long source, long range, Soil soil)
    {
        public long Destination { get; set; } = dest;
        public long Source { get; set; } = source;
        public long Range { get; set; } = range;
        public Soil Soil { get; set; } = soil;


        internal long Move(long index)
        {
            if (!isInRange(index))
                return 0;

            return Source - Destination;
        }

        private bool isInRange(long num)
        {
            return Destination <= num && num <= Destination + Range;
        }
    }
}
