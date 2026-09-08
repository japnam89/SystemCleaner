# AI Smart Cleaner & System Tuneup

Lightweight cross-platform system cleaner and tuneup utility built with Avalonia and .NET 10.

Cross-platform support
----------------------
The UI is implemented with Avalonia (Fluent theme) and the application is designed to run on Windows, macOS, and Linux. Some functionality is implemented using OS-specific paths and commands. Summary of platform support:

- Windows: Full feature set supported (system cleaner, duplicate finder, browser cache cleanup for Chrome/Edge, app uninstaller, startup manager, system specs).
- macOS: Most features supported (system cleaner, duplicate finder, browser cleanup for Chrome/Edge, startup manager via LaunchAgents, app listing via /Applications). Some uninstall behavior (directory deletion) may be limited by permissions.
- Linux: The UI runs on Linux, but several convenience features (browser cleanup, installed apps listing, startup manager) are limited or not implemented. The app will still provide cleaning of temporary files and duplicate detection.

Notes & limitations
-------------------
- The app uses platform checks (RuntimeInformation) and performs file operations directly (deleting cache directories, removing application folders, moving startup files). These operations may require elevated permissions on some systems — run the app as administrator/root if you need to modify protected files.
- Browser cleanup currently targets common Chrome/Edge cache locations on Windows and macOS. Linux browser paths are not enumerated by default.
- The uninstaller removes application directories (Program Files or /Applications) rather than invoking platform package managers; use with caution.
- Startup manager toggles files in the user's startup directory (Windows Startup folder, macOS LaunchAgents) by renaming to .disabled. This is a lightweight approach and may not cover every startup mechanism.

How this was verified
----------------------
- The project uses Avalonia which supports Windows/macOS/Linux and is included as the UI framework.
- The code contains RuntimeInformation checks and OS-specific path handling for core features (see Program.cs). This demonstrates intended cross-platform behavior while implementing platform-specific functionality where required.

If you want me to add an explicit runtime check or a short platform diagnostics page inside the app that shows which features are available for the current OS, I can implement that and add tests.

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

Quickstart (Linux / macOS)
1. Requirements:
   - .NET 10 SDK installed (use your distro package manager or Homebrew on macOS).
   - For Linux, ensure GTK and desktop libraries are present: e.g., on Debian/Ubuntu `sudo apt install libgtk-3-0 libnotify4 libnss3 libxss1 libasound2`.
2. Open a terminal in the repository root (where `SystemCleaner.sln` / `SystemCleaner.csproj` live).
3. Build and run for development:
   - dotnet build -c Release
   - dotnet run --project ./SystemCleaner.csproj -c Release
   - or run the produced DLL: `dotnet ./bin/Release/net10.0/SystemCleaner.dll`
4. Publish a native app (optional):
   - Publish for Linux x64: `dotnet publish -c Release -r linux-x64 --self-contained false -o ./publish/linux-x64`
   - Publish for macOS x64: `dotnet publish -c Release -r osx-x64 --self-contained false -o ./publish/osx-x64`
   - For ARM use `linux-arm64` / `osx-arm64` runtimes.

Notes for Linux/macOS
- Many cleanup and uninstall operations modify files and may require elevated privileges. Use sudo only when necessary and with caution.
- Browser cache cleanup targets common user-level cache locations; no root needed for user caches.
- On Linux, uninstaller support is limited: the app discovers `.desktop` entries and `/opt` installs and can remove `/opt` directories. Package-managed apps should be removed with the system package manager (apt/dnf/snap/flatpak).
- On macOS, uninstalling apps in `/Applications` may require privileges; prefer dragging apps to Trash or using native uninstallers where appropriate.
- If the UI fails to start on Linux, ensure the required GTK libs are installed.

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
