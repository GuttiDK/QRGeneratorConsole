using System;
using QRGeneratorProject.QRCoding;

namespace QRGeneratorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text or link for the QR code:");
            string inputData = Console.ReadLine();

            Console.WriteLine("Enter text to display below the QR code:");
            string bottomText = Console.ReadLine();

            // Define the output directory
            string outputDirectory = @"C:\Users\ChristianHøttges\OneDrive - SpeedAdmin ApS\Skrivebord\QRGeneratorProject\QRCode\Assets\Output";

            // Instantiate the QRCodeService
            QRCodeService qrCodeService = new QRCodeService();

            try
            {
                // Generate the QR code and save it
                string savedFilePath = qrCodeService.GenerateQRCode(inputData, bottomText, outputDirectory);

                Console.WriteLine($"QR code has been saved as: {savedFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
