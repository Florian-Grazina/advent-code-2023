using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    internal class Box
    {
        public OrderedDictionary Lenses = [];


        public void AddLens(string lens)
        {
            Lenses.Add(lens.Split(' ')[0], int.Parse(lens.Split(" ")[1]));
        }
    }
}
