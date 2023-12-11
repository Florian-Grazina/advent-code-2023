using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    internal class Pipe
    {
        public char Connection { get; set; }
        public List<Direction> Directions { get; set; } = [];


        public Pipe(char connection, List<Direction> directions)
        {
            Connection = connection;
            Directions = directions;
        }
    }
}
