using QRGeneratorProject.Interfaces;
using QRGeneratorProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace QRGeneratorProject.Services
{
    public class LayoutService : ILayoutService
    {
        public void GenerateA4Layout(List<FinalImage> qrCodePaths)
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
            string outputDirectory = "";
            // Opret en ny mappe til layouts, hvis den ikke eksisterer
            string layoutsDirectory = Path.Combine(outputDirectory, "Layouts");
            Directory.CreateDirectory(layoutsDirectory);

            int pageNumber = 1;
            List<FinalImage> currentPageImages = new List<FinalImage>();

            foreach (var filePath in qrCodePaths)
            {
                currentPageImages.Add(filePath);

                // Når vi har fyldt 24 QR-koder (6x4 = 24), opretter vi en ny side
                if (currentPageImages.Count == 24)
                {
                    SaveLayoutPage(currentPageImages, layoutsDirectory, pageNumber);
                    currentPageImages.Clear();  // Tøm listen til næste side
                    pageNumber++;
                }
            }

            // Hvis der er resterende QR-koder på den sidste side
            if (currentPageImages.Count > 0)
            {
                SaveLayoutPage(currentPageImages, layoutsDirectory, pageNumber);
            }
        }

        private void SaveLayoutPage(List<FinalImage> qrCodePaths, string layoutsDirectory, int pageNumber)
        {
            // Definer layoutens egenskaber og A4-sidens dimensioner
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
                        if (!File.Exists(filePath.OutputPath))
                        {
                            Console.WriteLine($"QR code file not found: {filePath.OutputPath}");
                            continue;
                        }

                        using (Bitmap qrCode = new Bitmap(filePath.Image))
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
                string outputFile = Path.Combine(layoutsDirectory, $"QRCodes_A4Layout_Page{pageNumber}.png");
                a4Bitmap.Save(outputFile, System.Drawing.Imaging.ImageFormat.Png);

                Console.WriteLine($"A4 layout for page {pageNumber} saved as: {outputFile}");
            }
        }
    }
}
