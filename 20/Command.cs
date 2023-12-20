using _20.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20
{
    internal class Command(Module module, Pulse pulse)
    {
        public Module Module{ get; set; } = module;
        public Pulse Pulse{ get; set; } = pulse;


        public void Release()
        {
            Module.Release(pulse);
        }
    }
}
