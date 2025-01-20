using QRGeneratorProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace QRGeneratorProject.Services
{
    public class LayoutService : ILayoutService
    {
        public void GenerateA4Layout(List<string> qrCodePaths, string outputDirectory)
        {
            // Hvis ingen QR-kode stier er givet, kastes en undtagelse.
            if (qrCodePaths == null || qrCodePaths.Count == 0)
                throw new ArgumentException("No QR code paths provided for layout generation.");

            // Definer layoutens egenskaber og A4-sidens dimensioner.
            const int qrCodeSize = 200;
            const int margin = 20;
            const int cols = 4;
            const int rows = 6;
            int a4Width = cols * (qrCodeSize + margin) - margin;
            int a4Height = rows * (qrCodeSize + margin) - margin;

            // Opret en ny bitmap til A4-layoutet.
            using (Bitmap a4Bitmap = new Bitmap(a4Width, a4Height))
            {
                using (Graphics g = Graphics.FromImage(a4Bitmap))
                {
                    g.Clear(Color.White); // Baggrundsfarve

                    // Positioner QR-koderne på layoutet.
                    int x = 0, y = 0;
                    foreach (var filePath in qrCodePaths)
                    {
                        if (!File.Exists(filePath))
                        {
                            Console.WriteLine($"QR code file not found: {filePath}");
                            continue;
                        }

                        using (Bitmap qrCode = new Bitmap(filePath))
                        {
                            g.DrawImage(qrCode, x, y, qrCodeSize, qrCodeSize);
                        }

                        // Juster positionen for næste QR-kode.
                        x += qrCodeSize + margin;
                        if (x + qrCodeSize > a4Width)
                        {
                            x = 0;
                            y += qrCodeSize + margin;
                        }

                        // Stop hvis vi har fyldt A4-siden.
                        if (y + qrCodeSize > a4Height)
                        {
                            break;
                        }
                    }
                }

                // Gem A4-layoutet som en PNG-billede.
                string outputFile = Path.Combine(outputDirectory, "QRCodes_A4Layout.png");
                a4Bitmap.Save(outputFile, System.Drawing.Imaging.ImageFormat.Png);

                Console.WriteLine($"A4 layout saved as: {outputFile}");
            }
        }
    }
}
