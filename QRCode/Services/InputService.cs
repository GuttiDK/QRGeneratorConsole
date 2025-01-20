using System;

namespace QRGeneratorProject.Services
{
    public class InputService
    {
        public string GetInputDataFromUser()
        {
            Console.WriteLine("Enter text or link for the QR code (max ~300 characters for best quality):");
            return Console.ReadLine();
        }

        public string GetBottomTextFromUser()
        {
            Console.WriteLine("Enter text to display below the QR code:");
            return Console.ReadLine();
        }
    }
}
