using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23
{
    internal static class Logs
    {
        public static List<Hike> Hikes { get; set; } = [];
        public static List<Hike> NewHikes { get; set; } = [];
        public static long LongestHike { get; set; }


        public static void Rec(long steps)
        {
            if(LongestHike < steps)
                LongestHike = steps;
        }
    }
}
