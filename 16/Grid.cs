using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16
{
    internal static class Grid
    {
        public static Tile[,] Map;
        public static List<Laser> ListLaser;
        public static List<Laser> QueueLaser;


        public static void Generate(string[] input)
        {
            Map = new Tile[input[0].Length, input.Length];
            ListLaser = [];
            QueueLaser = [];

            // mapping
            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[0].Length; x++)
                {
                    Map[x, y] = new(input[y][x].ToString());
                }
            }

        }

        internal static void Move()
        {
            QueueLaser.Clear();

            foreach(Laser laser in ListLaser)
            {
                if(laser.IsActive == true)
                    laser.Move();
            }

            ListLaser.AddRange(QueueLaser);
        }
    }
}
