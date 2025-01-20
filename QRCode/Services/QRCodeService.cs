using System;
using System.Drawing;
using System.IO;
using QRCoder;
using QRGeneratorProject.Interfaces;

namespace QRGeneratorProject.Services
{
    public class QRCodeService : IQRCodeService
    {
        public string GenerateQRCode(string inputData, string bottomText, string outputDirectory)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(inputData, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);

                Bitmap qrCodeImage = qrCode.GetGraphic(10);

                int width = qrCodeImage.Width;
                int height = qrCodeImage.Height + 80;
                Bitmap finalImage = new Bitmap(width, height);

                using (Graphics g = Graphics.FromImage(finalImage))
                {
                    g.Clear(Color.White);
                    g.DrawImage(qrCodeImage, 0, 0);

                    Font font = new Font("Arial", 16);
                    Brush brush = Brushes.Black;
                    SizeF textSize = g.MeasureString(bottomText, font);
                    float textX = (width - textSize.Width) / 2;
                    float textY = qrCodeImage.Height + 10;

                    g.DrawString(bottomText, font, brush, textX, textY);
                }

                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string outputPath = Path.Combine(outputDirectory, $"QRCODE_{timestamp}.png");

                finalImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                return outputPath;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while generating the QR code: " + ex.Message);
            }
        }
    }
}
