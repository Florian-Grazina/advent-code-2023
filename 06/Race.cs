using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06
{
    internal class Race(long time, long distance)
    {
        public long Time { get; set; } = time;
        public long DistanceRecord { get; set; } = distance;
        public long BeatRecord { get; set; } = 0;



        public void CalculateDistance(long timePressing)
        {
            if (timePressing > time)
                throw new Exception("Pressing too long");

            long travelTime = Time - timePressing;
            long distance = travelTime * timePressing;

            if (distance > DistanceRecord)
                BeatRecord++;
        }
    }
}
