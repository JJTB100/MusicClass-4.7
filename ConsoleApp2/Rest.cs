using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class Rest : MusicalNotation
    {

        public Rest(int time)
        {

            Duration = time;

        }



    }
}
