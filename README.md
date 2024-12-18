# QR Generator Project

This project allows you to generate QR codes from user input and save them as PNG images. The QR codes are accompanied by customizable footer text. The image filenames are automatically generated with timestamps to ensure uniqueness.

## Project Structure

The project structure has been refactored to improve maintainability and readability. The main logic for generating QR codes and rendering them has been encapsulated in the `QRCodeService` class. The project now uses the `QRCoder` library for QR code generation.

### Key Features:
- **QR Code Generation**: Uses the `QRCoder` library to generate QR codes.
- **Custom Footer Text**: Allows adding custom footer text below the QR code.
- **Timestamped Filenames**: Saves the QR code with a filename based on the current date and time (`QRCODE_YYYYMMDD_HHMMSS.png`).
- **Error Handling**: Includes error handling and informative exception messages.

## Getting Started

### Prerequisites

- .NET Framework 4.8.1 or higher
- `QRCoder` library (version 1.6.0) via NuGet
- `System.Drawing.Common` package (for image rendering)

### Installation

1. Clone this repository to your local machine.
2. Open the solution in Visual Studio.
3. Restore the NuGet packages to ensure all dependencies are installed.
4. Build and run the project.

### Usage

When you run the program, you will be prompted to enter:
1. **QR code data (link or text)**: This will be encoded into the QR code.
2. **Footer text**: This text will appear below the QR code.

The QR code will be generated, saved as a PNG file in the specified output directory, and named with a timestamp.

### Example
Enter text or link for the QR code: 
https://example.com 
Enter text to display below the QR code: 
Example Footer 
QR code has been saved as: C:\path\to\your\output\directory\QRCODE_20241217_143520.png


## Files and Structure

### `QRCodeService.cs`
The main service class responsible for generating QR codes and saving them as PNG images. It uses the `QRCoder` library to generate QR codes, combines them with footer text, and saves them in a specified output directory.

### `Program.cs`
Contains the entry point for the application, handles user input, and calls the `QRCodeService` to generate and save QR codes.

### `QRGeneratorProject.csproj`
The project file for the `QRGeneratorProject` project. It has been updated to reflect the new project structure and dependencies.

### `packages.config`
Lists the NuGet packages required by the project, including `QRCoder` and `System.Drawing.Common`.

## Refactoring and Updates

### Commit 1: Refactor QR code generation and update project structure
- Refactored `Program.cs` to use the `QRCodeService` class.
- Removed custom QR code generation files and used `QRCoder` for QR code creation.
- Introduced the `QRCodeService` class for generating and saving QR codes with footer text.
- The image filename now includes a timestamp for uniqueness.

### Commit 2: Refactor QR code generation to use `QRCoder` library
- Replaced custom QR code generation logic with the `QRCoder` library.
- Removed unnecessary files related to custom encoding, error correction, and masking logic.
- Simplified the project by leveraging the `QRCoder` library.

### Commit 3: Refactor and update QR code generator project
- Significant refactor to the project structure.
- Updated various files to streamline the QR code generation process.
- Enhanced error handling and improved user prompts.

## Contributing

If you would like to contribute to the project, please fork the repository, make your changes, and submit a pull request.

## License

This project is open-source and available under the MIT License.

---

Thank you for using the QR Generator Project!
