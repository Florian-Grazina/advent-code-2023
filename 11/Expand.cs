using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_12
{
    internal class Expand : Node
    {
        public Expand(long x, long y)
        {
            Coords = [x, y];
        }
    }
}
