# AI Smart Cleaner & System Tuneup

Lightweight cross-platform system cleaner and tuneup utility built with Avalonia and .NET 10.

Features
- AI-driven system cleaning (temp files, caches)
- Duplicate media & file finder
- Performance tuneup utilities
- Browser cache cleanup (Chrome, Edge)
- App uninstaller, startup manager, system specs
- Localization: English, Français, हिन्दी, ਪੰਜਾਬੀ
- About tab with website and donate (PayPal) link

Quickstart (Windows)
1. Requirements: .NET 10 SDK, Visual Studio 2022/2026 or newer
2. Open the solution: `SystemCleaner.sln` in Visual Studio
3. Build and Run (F5) or from command line:
   - dotnet build
   - dotnet run --project ./

Localization
- The app uses an internal Localization helper in `Program.cs`.
- To change language at runtime use the language selector in the top bar; supported codes: `en`, `fr`, `hi`, `pa`.
- To add or fix translations, edit the string maps in `Program.cs` (functions GetEnglish/GetFrench/GetHindi/GetPunjabi).

Donate
- If you like the app, you can donate via PayPal: https://www.paypal.com/paypalme/japnam89

Development notes
- Target: .NET 10
- UI framework: Avalonia (Fluent theme)
- Main UI: `Program.cs` (single-file app for simplicity)

Contributing
- Open an issue or submit a pull request. Please include a description and steps to reproduce.

License
- Add your preferred license to the repository. Currently no license file is included.
