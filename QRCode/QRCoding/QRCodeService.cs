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
                // Create the QR code generator
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(inputData, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);

                // Generate QR code image with a smaller size
                Bitmap qrCodeImage = qrCode.GetGraphic(10);  // Smaller QR code size

                // Create a new image to fit the QR code and the text below it
                int width = qrCodeImage.Width;
                int height = qrCodeImage.Height + 80; // Space for the text
                Bitmap finalImage = new Bitmap(width, height);

                using (Graphics g = Graphics.FromImage(finalImage))
                {
                    // Set the background color to white
                    g.Clear(Color.White);

                    // Draw the QR code on the final image
                    g.DrawImage(qrCodeImage, 0, 0);

                    // Set text font and color (larger text)
                    Font font = new Font("Arial", 16);  // Larger font size
                    Brush brush = Brushes.Black;

                    // Calculate text position (centered below QR code)
                    SizeF textSize = g.MeasureString(bottomText, font);
                    float textX = (width - textSize.Width) / 2;
                    float textY = qrCodeImage.Height + 10; // 10 pixels distance from the QR code

                    // Draw the text below the QR code
                    g.DrawString(bottomText, font, brush, textX, textY);
                }

                // Create output directory if it doesn't exist
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Generate the output file path with timestamp
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");  // Format for date and time
                string outputPath = Path.Combine(outputDirectory, $"QRCODE_{timestamp}.png");

                // Save the final image as PNG
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
