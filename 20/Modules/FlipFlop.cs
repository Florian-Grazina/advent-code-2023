using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20.Modules;

namespace _20
{
    internal class FlipFlop(string id) : Module(id)
    {
        public bool On { get; set; } = false;



        public override void Release(Pulse pulse)
        {
            if(pulse == Pulse.low)
            {
                SendPulse(Toggle());
            }
        }

        private Pulse Toggle()
        {
            Pulse toReturn = Pulse.high;

            if(On)
                toReturn = Pulse.low;

            On = !On;

            return toReturn;
        }
    }
}
