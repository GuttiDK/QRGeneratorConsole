using System;

namespace QRGeneratorProject.Models
{
    public class QRCodeInfo
    {
        public Guid Id { get; set; }
        public string Link { get; set; }
        public string FillerText { get; set; }
    }
}
