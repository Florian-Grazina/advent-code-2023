using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08
{
    internal class Route (Node node)
    {
        public Node ActiveNode { get; set; } = node;
        public long NumberOfSteps { get; set; } = 0;
    }
}
