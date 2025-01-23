using System;
using System.Collections.Generic;

namespace QRGeneratorProject.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static readonly List<string> InstrumentList = new List<string>
        {
            "Guitar", "Piano", "Violin", "Drums", "Flute", "Saxophone", "Trumpet", "Clarinet", "Cello", "Trombone"
        };

        public Instrument GenerateInstrument()
        {
            Random rand = new Random();
            string randomInstrument = InstrumentList[rand.Next(InstrumentList.Count)]; // Tilfældigt instrument
            var instrument = new Instrument()
            {
                Id = rand.Next(1000, 9999),
                Name = randomInstrument
            };
            return instrument;
        }
    }
}
