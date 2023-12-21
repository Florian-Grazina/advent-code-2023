using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21
{
    internal static class Garden
    {
        public static string[,] Map { get; set; }


        public static Plot Generate(string[] input)
        {
            Map = new string[input[0].Length, input.Length];
            Plot? start = null;

            // mapping
            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[0].Length; x++)
                {
                    Map[x, y] = input[y][x].ToString();
                    if (Map[x, y] == "S")
                        start = new((x, y));
                }
            }

            return start!;
        }
    }
}
