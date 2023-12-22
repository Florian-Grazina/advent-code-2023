using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16
{
    public enum Direction
    {
        top, right, bot, left
    }

    internal class Laser((int, int) coord, Direction direction)
    {
        public (int, int) Coord {get; set;} = coord;
        public Direction Direction { get; set; } = direction;
        public bool IsActive { get; set; } = true;

        public int X => Coord.Item1;
        public int Y => Coord.Item2;


        public void Move()
        {
            if(!IsActive) return;

            if(X >= Grid.Map.GetLength(0) ||
                Y >= Grid.Map.GetLength(1) ||
                X < 0 || Y < 0)
            {
                IsActive = false;
                return;
            }

            Grid.Map[X, Y].ProcessLaser(this);

            if (Direction == Direction.top)
                if (Y != 0)
                {
                    Coord = (X, Y - 1);
                    return;
                }

            if (Direction == Direction.right)
                if (X != Grid.Map.GetLength(0))
                {
                    Coord = (X + 1, Y);
                    return;
                }

            if (Direction == Direction.bot)
                if (Y != Grid.Map.GetLength(1))
                {
                    Coord = (X, Y + 1);
                    return;
                }

            if (Direction == Direction.left)
                if (X != 0)
                {
                    Coord = (X - 1, Y);
                    return;
                }
        }
    }
}
