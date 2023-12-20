using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.Modules
{
    internal class Broadcaster(string id) : Module(id)
    {
        public void PushButton()
        {
            ModuleFactory.LowPulses++;
            ReceivePulse(Pulse.low);
        }

        public override void Release(Pulse pulse)
        {
            SendPulse(pulse);
        }
    }
}
