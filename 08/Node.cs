using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08
{
    internal class Node(string location, string[] network)
    {
        public string Location { get; set; } = location;
        public string[] Network { get; set; } = network;
    }
}
