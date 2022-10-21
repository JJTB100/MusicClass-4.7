using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NAudio.Midi;


namespace Music
{
    class MidiEvent
    {
        

        // the bytes that are sent as MIDI data
        protected byte[] buffer = new byte[3];

        // there are 16 channels to choose from. Channel 9 is percussion
        private int Channel;

        /// <summary>
        /// Send MIDI data
        /// </summary>
        public virtual void Send(MidiOut midi)
        {
            
            midi.SendBuffer(buffer);
            

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{buffer[i]}");
            }
            Console.WriteLine();
        }
    }
}
