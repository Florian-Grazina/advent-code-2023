using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    public enum Direction
    {
        Down, Right, Up, Left
    }

    internal class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<char[]> Map { get; set; } = [];
        public Direction Direction { get; set; }
        public int Steps { get; set; }

        public List<Pipe> Pipes =
        [
            new('|', [Direction.Up, Direction.Down]),
            new('-', [Direction.Left, Direction.Right]),
            new('L', [Direction.Up, Direction.Right]),
            new('J', [Direction.Up, Direction.Left]),
            new('7', [Direction.Left, Direction.Down]),
            new('F', [Direction.Right, Direction.Down])
        ];

        public char ActualLoc => Map[Y][X];


        public int Navigate()
        {
            // find the loop
            if (Map[Y][X + 1] == '-' || Map[Y][X + 1] == 'J' || Map[Y][X + 1] == '7')
                Direction = Direction.Right;
            else if (Map[Y][X - 1] == '-' || Map[Y][X + 1] == 'L' || Map[Y][X + 1] == 'F')
                Direction = Direction.Left;
            else if (Map[Y][Y + 1] == '|' || Map[Y][Y + 1] == 'L')
                Direction = Direction.Down;
            else if (Map[Y][Y - 1] == '|' || Map[Y][Y - 1] == '7' || Map[Y][Y - 1] == 'F')
                Direction = Direction.Up;

            Move(Direction);

            while (ActualLoc != 'S')
            {
                Pipe pipe = Pipes.Where(p => p.Connection == ActualLoc).First();

                if (pipe.Directions[0] == GetOpposite(Direction))
                    Direction = pipe.Directions[1];
                else Direction = pipe.Directions[0];

                Move(Direction);
                Steps++;
            }

            if (Steps % 2 == 1)
                Steps++;
            return Steps / 2;
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right: X += 1; break;
                case Direction.Left: X -= 1; break;
                case Direction.Down: Y += 1; break;
                case Direction.Up: Y -= 1; break;
            }
        }

        public Direction GetOpposite(Direction direction)
        {
            return direction switch
            {
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                _ => Direction.Right,
                //kkk
            };
        }
    }
}
