using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16
{
    internal class Tile(string content)
    {
        public bool IsEnergized { get; private set; } = false;
        private List<Direction> StoredDirections { get; set; } = [];
        public string Content { get; set; } = content;


        public void ProcessLaser(Laser laser)
        {
            if(!IsEnergized) IsEnergized = true;

            if (!StoredDirections.Contains(laser.Direction))
                StoredDirections.Add(laser.Direction);
            else
            {
                laser.IsActive = false;
                return;
            }

            switch (laser.Direction)
            {
                case Direction.top : LaserTop(laser); break;
                case Direction.right : LaserRight(laser); break;
                case Direction.bot : LaserBot(laser); break;
                case Direction.left : LaserLeft(laser); break;
            }
        }

        public void LaserTop(Laser laser)
        {
            switch (Content)
            {
                case "/" : laser.Direction = Direction.right; break;
                case "\\" : laser.Direction = Direction.left; break;
                case "-" : laser.Direction = Direction.left; CopyLaser(laser, Direction.right); break;
                case "|" : break;
            }
        }
        public void LaserRight(Laser laser)
        {
            switch (Content)
            {
                case "/": laser.Direction = Direction.top; break;
                case "\\": laser.Direction = Direction.bot; break;
                case "-": break;
                case "|": laser.Direction = Direction.top; CopyLaser(laser, Direction.bot); break;
            }

        }
        public void LaserBot(Laser laser)
        {
            switch (Content)
            {
                case "/": laser.Direction = Direction.left; break;
                case "\\": laser.Direction = Direction.right; break;
                case "-": laser.Direction = Direction.left; CopyLaser(laser, Direction.right); break;
                case "|": break;
            }

        }
        public void LaserLeft(Laser laser)
        {
            switch (Content)
            {
                case "/": laser.Direction = Direction.bot; break;
                case "\\": laser.Direction = Direction.top; break;
                case "-": break;
                case "|": laser.Direction = Direction.top; CopyLaser(laser, Direction.bot); break;
            }

        }

        private void CopyLaser(Laser laser, Direction direction)
        {
            Grid.QueueLaser.Add(new(laser.Coord, direction));
        }
    }
}
