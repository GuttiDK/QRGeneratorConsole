using System.Drawing;

namespace QRGeneratorProject.Models
{
    public class FinalImage
    {
        public int Id { get; set; }
        public Bitmap Image { get; set; }
        public string OutputPath { get; set; }
        public string Timestamp { get; set; }
        public string Link { get; set; }
    }
}
