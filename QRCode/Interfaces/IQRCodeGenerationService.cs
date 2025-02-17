namespace QRGeneratorProject.Interfaces
{
    public interface IQRCodeGenerationService
    {
        void GenerateSingleQRCode(string inputData, string bottomText);
        void GenerateMultipleQRCodes(string[] input, string[] bottomText);
        void GenerateTestQRCode();
        void GenerateMultipleTestQRCodes(int number);
    }
}
