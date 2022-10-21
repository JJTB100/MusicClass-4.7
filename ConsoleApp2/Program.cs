using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int device = 0; device < MidiOut.NumberOfDevices; device++)

            {

                Console.WriteLine(MidiOut.DeviceInfo(device).ProductId);

            }
            MidiOut midi = new MidiOut(0);


            Music masterpiece = new Music("Music.txt", midi);
            masterpiece.Play();
        }
    }
}