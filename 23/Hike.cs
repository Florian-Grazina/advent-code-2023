using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _23
{
    public enum Road
    {
        top, right, left, bot
    }

    internal class Hike
    {
        // data 
        public string[,] Map { get; set; }
        public (int, int) Coords { get; set; }
        public long Steps { get; set; }
        public bool IsActive { get; set; } = true;
        private int X => Coords.Item1;
        private int Y => Coords.Item2;


        // 
        public Hike(string[,] map, (int, int) coords, long steps)
        {
            Map = map;
            Coords = coords;
            Steps = steps;
        }

        public void Start()
        {
            while(Coords.Item2 != Map.GetLength(1) - 1 && IsActive)
            {
                Map[X, Y] = "#";
                Steps++;

                List<Road> possibilities = CheckPoss();

                if(possibilities.Count == 0)
                    IsActive = false;

                if(possibilities.Count == 1)
                    Coords = Move(possibilities[0]);

                else
                {
                    for(int i = 0; i < possibilities.Count; i++)
                    {
                        if(i == possibilities.Count - 1)
                            Coords = Move(possibilities[i]);
                        else
                        {
                            Logs.NewHikes.Add(new(CopyMap(), Move(possibilities[i]), Steps));
                        }
                    }
                }

            }
            Logs.Rec(Steps);
            IsActive = false;
        }

        private void Print()
        {
            Console.Clear();
            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    Console.Write(Map[j,i]);
                }
                Console.WriteLine();
            }
        }

        private string[,] CopyMap()
        {
            string[,] toReturn = new string [Map.GetLength(0), Map.GetLength(1)];

            for (int y = 0; y < Map.GetLength(1); y++)
            {
                for (int x = 0; x < Map.GetLength(0); x++)
                {
                    toReturn[x, y] = Map[x,y].ToString();
                }
            }

            return toReturn;
        }

        private List<Road> CheckPoss()
        {
            List<Road> toReturn = [];

            // look right
            if (Map[X + 1, Y] != "#")
                toReturn.Add(Road.right);

            // look left
            if (Map[X - 1, Y] != "#")
                toReturn.Add(Road.left);

            // look bot
            if (Map[X, Y + 1] != "#")
                toReturn.Add(Road.bot);

            // look top
            if (Y != 0)
                if (Map[X, Y - 1] != "#")
                    toReturn.Add(Road.top);

            return toReturn;
        }

        private (int, int) Move(Road road)
        {
            switch (road)
            {
                case Road.right: return (X + 1, Y);
                case Road.left: return (X - 1, Y);
                case Road.bot: return (X, Y + 1);
                case Road.top: return (X, Y - 1);
                default: throw new Exception("no Road");
            }
        }
    }
}
