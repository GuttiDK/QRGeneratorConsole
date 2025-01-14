using System;
using QRGeneratorProject.DownloadsPath;
using QRGeneratorProject.QRCoding;

namespace QRGeneratorProject
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter text or link for the QR code:");
            string inputData = Console.ReadLine();

            Console.WriteLine("Enter text to display below the QR code:");
            string bottomText = Console.ReadLine();

            // Define the output directory
            string outputDirectory = KnownFolders.GetPath(KnownFolder.Downloads);
            if (string.IsNullOrEmpty(outputDirectory))
            {
                Console.WriteLine("Downloads folder not found.");
                outputDirectory = @"C:\Users\ChristianHøttges\OneDrive - SpeedAdmin ApS\Skrivebord\QRGeneratorProject\QRCode\Assets\Output";
            }
            else
            {
                Console.WriteLine($"Downloads folder found: {outputDirectory}");
            }

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
