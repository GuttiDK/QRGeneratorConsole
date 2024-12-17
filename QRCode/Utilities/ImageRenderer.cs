using System.Drawing;

namespace QRGeneratorProject.Utilities
{
    public class ImageRenderer
    {
        public Bitmap Render(bool[,] matrix, string footerText)
        {
            int size = matrix.GetLength(0);
            int scale = 10;
            int padding = 10;
            int footerHeight = 40;

            int imageSize = size * scale + 2 * padding + footerHeight;
            Bitmap bitmap = new Bitmap(imageSize, imageSize);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);

                for (int y = 0; y < size; y++)
                    for (int x = 0; x < size; x++)
                        if (matrix[y, x])
                            g.FillRectangle(Brushes.Black, x * scale + padding, y * scale + padding, scale, scale);

                using (Font font = new Font("Arial", 12))
                    g.DrawString(footerText, font, Brushes.Black, padding, size * scale + padding);
            }

            return bitmap;
        }
    }
}
