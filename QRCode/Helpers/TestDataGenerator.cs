using QRGeneratorProject.Models;
using System;
using System.Collections.Generic;

namespace QRGeneratorProject.Services
{
    public interface ITestDataGenerator
    {
        QRCodeInfo GenerateTestData();
    }

    public class TestDataGenerator : ITestDataGenerator
    {
        private static readonly List<string> InstrumentList = new List<string>
        {
            "Guitar", "Piano", "Violin", "Drums", "Flute", "Saxophone", "Trumpet", "Clarinet", "Cello", "Trombone"
        };

        public QRCodeInfo GenerateTestData()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1000, 9999); // Tilfældigt nummer
            string randomInstrument = InstrumentList[rand.Next(InstrumentList.Count)]; // Tilfældigt instrument

            var qrcodeinfo = new QRCodeInfo()
            {
                Id = new Guid(),
                Link = $@"https://tstcka.speedadmin.dk/play/instrument/{randomInstrument}/",
                FillerText =  $@"{randomNumber} - {randomInstrument}"

            };

            return qrcodeinfo;
        }
    }
}
