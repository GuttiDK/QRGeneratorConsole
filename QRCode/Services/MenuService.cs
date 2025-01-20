using System;
using QRGeneratorProject.Helpers;
using System.Collections.Generic;
using QRGeneratorProject.Interfaces;

namespace QRGeneratorProject.Services
{
    public class MenuService : IMenuService
    {
        private readonly IQRCodeService _qrCodeService;
        private readonly ILayoutService _layoutService;
        private readonly ITestModeService _testModeService;

        public MenuService(IQRCodeService qrCodeService, ILayoutService layoutService, ITestModeService testModeService)
        {
            _qrCodeService = qrCodeService;
            _layoutService = layoutService;
            _testModeService = testModeService;
        }

        public void StartMenu()
        {
            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.Clear();
                Console.WriteLine("QR Code Generator Menu:");
                Console.WriteLine("1. Generate a single QR code");
                Console.WriteLine("2. Generate multiple QR codes");
                Console.WriteLine("3. Generate a single QR code for a room (coming soon)");
                Console.WriteLine("4. Generate multiple QR codes for rooms (coming soon)");
                Console.WriteLine("5. Toggle Debug Mode");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GenerateSingleQRCode();
                        break;
                    case "2":
                        GenerateMultipleQRCodes();
                        break;
                    case "5":
                        _testModeService.ToggleTestMode();
                        break;
                    case "6":
                        exitProgram = true;
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (!exitProgram)
                {
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }

        private void GenerateSingleQRCode()
        {
            Console.Clear();
            Console.WriteLine("Enter text or link for the QR code (max ~300 characters for best quality):");
            string inputData = Console.ReadLine();

            Console.WriteLine("Enter text to display below the QR code:");
            string bottomText = Console.ReadLine();

            string outputDirectory = DirectoryHelper.GetOutputDirectory();

            try
            {
                string savedFilePath = _qrCodeService.GenerateQRCode(inputData, bottomText, outputDirectory);
                Console.WriteLine($"QR code has been saved as: {savedFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void GenerateMultipleQRCodes()
        {
            Console.Clear();
            Console.WriteLine("Enter text or link for each QR code, separated by commas:");
            string input = Console.ReadLine();
            string[] dataItems = input.Split(',');

            Console.WriteLine("Enter text to display below each QR code (leave blank if no text):");
            string bottomText = Console.ReadLine();

            string outputDirectory = DirectoryHelper.GetOutputDirectory();
            List<string> filePaths = new List<string>();

            try
            {
                foreach (string data in dataItems)
                {
                    string trimmedData = data.Trim();
                    if (!string.IsNullOrEmpty(trimmedData))
                    {
                        string savedFilePath = _qrCodeService.GenerateQRCode(trimmedData, bottomText, outputDirectory);
                        filePaths.Add(savedFilePath);
                    }
                }

                _layoutService.GenerateA4Layout(filePaths, outputDirectory);
                Console.WriteLine("All QR codes saved and compiled into an A4 layout.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
