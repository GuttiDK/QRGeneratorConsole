﻿using System;
using System.Drawing;
using QRCoder;

namespace QRCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indtast tekst eller link til QR-kode:");
            string inputData = Console.ReadLine();

            Console.WriteLine("Indtast tekst til visning under QR-koden:");
            string bottomText = Console.ReadLine();

            try
            {
                // Opretter en QR-kode generator
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(inputData, QRCodeGenerator.ECCLevel.Q);

                QRCode qrCode = new QRCode(qrCodeData);

                // Genererer billede af QR-koden
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                // Opretter et grafikobjekt til at tilføje tekst
                using (Graphics graphics = Graphics.FromImage(qrCodeImage))
                {
                    // Definerer tekst og font
                    Font font = new Font("Arial", 12);
                    SizeF textSize = graphics.MeasureString(bottomText, font);

                    // Beregner positionen til teksten, så den er centreret under QR-koden
                    PointF position = new PointF(
                        (qrCodeImage.Width - textSize.Width) / 2,
                        qrCodeImage.Height - textSize.Height - 10
                    );

                    // Tegner teksten på billedet
                    graphics.DrawString(bottomText, font, Brushes.Black, position);
                }

                // Gem QR-koden som PNG
                string outputPath = @"C:\Users\ChristianHøttges\source\repos\QRGeneratorProject\QRCode\Assets\Output\QRCode.png";
                qrCodeImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);

                Console.WriteLine($"QR-koden er gemt som: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"En fejl opstod: {ex.Message}");
            }
        }
    }
}
