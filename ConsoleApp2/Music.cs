using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NAudio.Midi;

namespace Music
{
    class Music
    {
        List<MusicalNotation> Notes = new List<MusicalNotation>();
        public void Play()
        {
            Console.WriteLine($"Playing...");
            foreach (Note n in Notes)
            {
                n.Play();
                Console.WriteLine($"Playing note: {n}");
            }
        }

        public int NoteToNumber(char noteName, bool flat, bool sharp, int octave)
        {
            int noteNumber = 0;
            switch (noteName)
            {
                case 'C':
                    noteNumber = 0;
                    break;
                case 'D':
                    noteNumber = 2;
                    break;
                case 'E':
                    noteNumber = 4;
                    break;
                case 'F':
                    noteNumber = 5;
                    break;
                case 'G':
                    noteNumber = 7;
                    break;
                case 'A':
                    noteNumber = 9;
                    break;
                case 'B':
                    noteNumber = 11;
                    break;
            }

            // decrease if flat
            if (flat)
            {
                noteNumber--;
            }

            // increase if sharp
            if (sharp)
            {
                noteNumber++;
            }

            return noteNumber + (octave * 12);
        }

        public Music(string Filename, MidiOut midi)
        {
            Console.WriteLine($"Loading file from {Filename}");
            // load from the file
            /*
             * example: 
// C major scale
C4 D E F G A B C5:2
// F major scale
F4 G A Bb C5 D E F:2
// G major scale
G A B C D E F# G:2
             * */



            string fileContents = File.ReadAllText(Filename);

            int tempo = 50;

            // remove the comments
            fileContents = Regex.Replace(fileContents, @"\/\/.*", "");

            int octave = 4;
            // extract the notes
            foreach (Match m in Regex.Matches(fileContents, @"([A-I])([b#])*(\d)*(:(\d*))*"))
            {
                
            
                // get the note name
                string note = m.Groups[1].Value;

                

                    // get the octave
                    if (m.Groups[3].Value.Length > 0)
                    {
                        octave = int.Parse(m.Groups[3].Value);
                    }

                // get flat or sharp
                bool flat = m.Groups[2].Value == "b";
                bool sharp = m.Groups[2].Value == "#";


                // get duration
                int Duration = 1;
                if (m.Groups[5].Value.Length > 0)
                {
                    Duration = int.Parse(m.Groups[5].Value);
                }

                //Check if tempo Change
                if (note == "I")
                {
                    tempo = int.Parse(m.Groups[5].Value);
                }
                // check if rest
                else if (note == "R")
                {
                    Notes.Add(new Rest(Duration));
                }
                else
                {
                    Notes.Add(new Note(NoteToNumber(note[0], flat, sharp, octave), Duration, midi, tempo));
                }
                
                Console.WriteLine($"Note: {note} Octave: {octave}: Duration: {Duration}");
            }
            //Console.WriteLine(fileContents);


        }
    }
}