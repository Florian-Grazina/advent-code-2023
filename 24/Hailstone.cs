using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24
{
    internal class Hailstone
    {
        public long X { get; set; }
        public long Y{ get; set; }
        public int VelX { get; set; }
        public int VelY { get; set; }


        public Hailstone(string input)
        {
            Parse(input);
        }

        private void Parse(string input)
        {
            string[] data = input.Split(" @ ");
            string[] coords = data[0].Split(",");
            string[] velocity = data[1].Split(",");

            X = int.Parse(coords[0]);
            Y = int.Parse(coords[1]);

            VelX = int.Parse(velocity[0]);
            VelY = int.Parse(velocity[1]);
        }

        public void Move()
        {
            X += VelX;
            Y += VelY;
        }
    }
}
