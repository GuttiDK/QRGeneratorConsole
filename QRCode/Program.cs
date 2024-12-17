using QRGeneratorProject.QRCode;
using QRGeneratorProject.Utilities;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Indtast tekst eller link til QR-kode:");
            string data = Console.ReadLine();

            Console.WriteLine("Indtast tekst til visning under QR-koden:");
            string footerText = Console.ReadLine();

            // Absolut path
            string outputDirectory = @"C:\Users\ChristianHøttges\source\repos\QRGeneratorProject\QRCode\Assets\Output";
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            var generator = new QRCodeGenerator();
            var qrMatrix = generator.Generate(data);

            var renderer = new ImageRenderer();
            string outputPath = Path.Combine(outputDirectory, "QRCode.png");

            using (var qrImage = renderer.Render(qrMatrix, footerText))
            {
                qrImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
            }

            Console.WriteLine($"QR-koden er gemt som '{outputPath}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"En fejl opstod: {ex.Message}");
        }
    }
}
