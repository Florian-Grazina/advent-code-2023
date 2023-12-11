using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_12
{
    internal class Galaxy : Node
    {
        private static int Number {  get; set; } = 0;
        public int Id { get; set; }
        public long Steps { get; set; } = 0;


        public Galaxy(long x, long y)
        {
            Number++;
            Id = Number;
            Coords = [x, y];
        }

        public void CalculateSteps(List<Galaxy> galaxy)
        {
            foreach(Galaxy g in galaxy)
            {
                long newSteps = Math.Abs(Coords[0] - g.Coords[0]) + Math.Abs(Coords[1] - g.Coords[1]);
                Steps += newSteps;
            }
        }
    }
}
