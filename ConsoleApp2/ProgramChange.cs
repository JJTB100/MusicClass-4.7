using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class ProgramChange : MidiEvent
    {
        public ProgramChange(int channel)
        {
            buffer[0] = (byte)channel;
        }


    }
}