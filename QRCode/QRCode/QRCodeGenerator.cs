
namespace QRGeneratorProject.QRCode
{
    public class QRCodeGenerator
    {
        public bool[,] Generate(string data)
        {
            var encoder = new DataEncoding();
            string encodedData = encoder.Encode(data);

            var errorCorrection = new ErrorCorrection();
            string errorData = errorCorrection.Generate(encodedData);

            var builder = new QRMatrixBuilder();
            bool[,] qrMatrix = builder.Build(encodedData + errorData);

            var masker = new Masking();
            masker.Apply(qrMatrix);

            return qrMatrix;
        }
    }
}
