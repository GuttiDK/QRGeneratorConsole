using QRGeneratorProject.Helpers;
using QRGeneratorProject.Interfaces;
using System;
using System.Collections.Generic;

namespace QRGeneratorProject.Services
{
    public class MenuService : IMenuService
    {
        private readonly IQRCodeGenerationService _qrCodeGenerationService;
        private readonly ITestModeService _testModeService;

        public MenuService(IQRCodeGenerationService qrCodeGenerationService, ITestModeService testModeService)
        {
            _qrCodeGenerationService = qrCodeGenerationService;
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
                if (_testModeService.IsTestModeActive()) // Show this option only in Test Mode
                {
                    Console.WriteLine("3. Generate a single test QR code (Test Mode only)");
                    Console.WriteLine("4. Generate multiple test QR codes (Test Mode only)");
                }
                Console.WriteLine("5. Exit");
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
                    case "3":
                        if (_testModeService.IsTestModeActive())
                        {
                            GenerateTestQRCode();
                        }
                        else
                        {
                            Console.WriteLine("Test mode is not enabled. Option not available.");
                        }
                        break;
                    case "4":
                        if (_testModeService.IsTestModeActive())
                        {
                            GenerateMultipleTestQRCodes();
                        }
                        else
                        {
                            Console.WriteLine("Test mode is not enabled. Option not available.");
                        }
                        break;
                    case "5":
                        exitProgram = true;
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                    case "6":
                        _testModeService.ToggleTestMode();
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

            _qrCodeGenerationService.GenerateSingleQRCode(inputData, bottomText);
        }

        private void GenerateMultipleQRCodes()
        {
            Console.Clear();
            Console.WriteLine("Enter text or link for each QR code, separated by commas:");
            string input = Console.ReadLine();
            string[] dataItems = input.Split(',');

            Console.WriteLine("Enter text to display below each QR code (leave blank if no text):");
            string bottomText = Console.ReadLine();

            _qrCodeGenerationService.GenerateMultipleQRCodes(input, bottomText);
        }

        private void GenerateTestQRCode()
        {
            _qrCodeGenerationService.GenerateTestQRCode();
        }

        private void GenerateMultipleTestQRCodes()
        {
            Console.Clear();
            Console.WriteLine("Enter a number between 1 and 9999 for the test QR codes:");

            string input = Console.ReadLine();
            if (int.TryParse(input, out int number) && number >= 1 && number <= 9999)
            {
                _qrCodeGenerationService.GenerateMultipleTestQRCodes(number);
            }
            else
            {
                Console.WriteLine("Invalid number. Please enter a value between 1 and 9999.");
            }
        }
    }
}
