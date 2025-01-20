using System;
using System.Collections.Generic;

namespace QRGeneratorProject.Services
{
    public class TestDataService
    {
        public static readonly List<string> InstrumentList = new List<string>
        {
            "Guitar", "Piano", "Violin", "Drums", "Flute", "Saxophone", "Trumpet", "Clarinet", "Cello", "Trombone"
        };

        public string GenerateTestData()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1000, 9999); // Tilfældigt nummer
            string randomInstrument = InstrumentList[rand.Next(InstrumentList.Count)]; // Tilfældigt instrument

            return $"{randomNumber} - {randomInstrument}";
        }
    }
}
