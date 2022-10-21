using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using NAudio.Midi;

namespace Music
{
    class NoteOn : MidiEvent
    {

        Note Note;
        public NoteOn(Note pnote)
        {
            Note = pnote;
            buffer[0] = 0x90;
            buffer[1] = (byte)Note.NoteNumber;
            buffer[2] = 127;



        }




    }
}
