using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class Note : MusicalNotation
    {
        public Note(int notenum, int duration, MidiOut midi, int tempo)
        {
            NoteNumber = notenum;
            Duration = duration;
            base.midi = midi;
        }

        public override void Play()
        {
            NoteOn noteOn = new NoteOn(this);
            NoteOff noteOff = new NoteOff(this);
            noteOn.Send(midi);
            if(Duration == 0)
            {
                System.Threading.Thread.Sleep(1);
            }
            if(Duration == 100)
            {
                System.Threading.Thread.Sleep(50);
            }
            else
            {
                System.Threading.Thread.Sleep(Duration * 4 * tempo);
            }
            
            noteOff.Send(midi);
        }
    }
}