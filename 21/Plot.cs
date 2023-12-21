using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21
{
    internal class Plot ((long, long) coord) : IEquatable<Plot>
    {
        public (long, long) Coord { get; set; } = coord;
        public long X => Parse(Coord.Item1);
        public long Y => Parse(Coord.Item2);
        public long x => Coord.Item1;
        public long y => Coord.Item2;
        private string[,] Map => Garden.Map;

        public bool Equals(Plot? other)
        {
            if (other == null) return false;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public List<Plot> Step()
        {
            List<Plot> toReturn = [];

            // top
            if (Map[X % 11, (Y - 1) % 11] != "#")
                toReturn.Add(new((x, y - 1)));

            // right
            if(Map[(X + 1)%11, Y % 11] != "#")
                toReturn.Add(new((x + 1, y)));

            // bottom
            if (Map[X % 11, (Y + 1) % 11] != "#")
                toReturn.Add(new((x, y + 1)));

            // left
            long a = (X - 1) % 11;
            long b = Y % 11;

            if (Map[(X - 1) % 11, Y % 11] != "#")
                toReturn.Add(new((x - 1, y)));

            return toReturn;
        }

        private long Parse(long coord)
        {
            while (coord < 1) coord += 11;
            return coord;
        }
    }
}
