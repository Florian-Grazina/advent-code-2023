using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18
{
    public enum Direction
    {
        right, down, up, left
    }

    internal class Command
    {
        public Direction Direction { get; set; }
        public long Steps { get; set; }


        public Command(string input)
        {
            Parse(input);
        }


        public (long, long) Move()
        {
            return Direction switch
            {
                Direction.right => (Steps, 0),
                Direction.down => (0, Steps),
                Direction.left => (-Steps, 0),
                Direction.up => (0, -Steps)
            };
        }

        private void Parse(string input)
        {
            string[] values = input.Split(' ');
            Steps = Convert.ToInt32(values[2].Substring(2, 5), 16);

            Direction = int.Parse(values[2].Substring(7, 1)) switch
            {
                0 => Direction.right,
                3 => Direction.up,
                2 => Direction.left,
                1 => Direction.down
            };
        }
    }
}
