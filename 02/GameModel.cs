using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_12
{
    internal class GameModel
    {
        public int Id { get; set; }
        public int RedCubes { get; set; }
        public int BlueCubes { get; set; }
        public int GreenCubes { get; set; }
        public bool GameIsPossible { get; set; } = true;
    }
}
