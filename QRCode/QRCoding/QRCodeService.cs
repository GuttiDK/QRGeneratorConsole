using System;
using System.Drawing;
using System.IO;
using QRCoder;

namespace QRGeneratorProject.QRCoding
{
    public class QRCodeService
    {
        // Method to generate QR code and save the image with text below it
        public string GenerateQRCode(string inputData, string bottomText, string outputDirectory)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(inputData, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);

                Bitmap qrCodeImage = qrCode.GetGraphic(10); 

                int width = qrCodeImage.Width;
                int height = qrCodeImage.Height + 80; // Space for the text
                Bitmap finalImage = new Bitmap(width, height);

                using (Graphics g = Graphics.FromImage(finalImage))
                {
                    g.Clear(Color.White);

                    g.DrawImage(qrCodeImage, 0, 0);

                    Font font = new Font("Arial", 16);  // Larger font size
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

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");  // Format for date and time
                string outputPath = Path.Combine(outputDirectory, $"QRCODE_{timestamp}.png");

                finalImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);

                return outputPath;  // Return the file path
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while generating the QR code: " + ex.Message);
            }
        }
    }
}
