# Project Details: AI Smart Cleaner & System Tuneup

Repository layout (root)
- SystemCleaner.sln           -> Visual Studio solution
- Program.cs                  -> Application entry and UI implementation (Avalonia)
- README.md                   -> This overview and quickstart

Important files
- Program.cs: Single-file implementation that contains Localization, App, and MainWindow UI logic.
  - Localization strings are defined at the top of Program.cs. Use the keys (e.g., `tab_cleaner`, `hdr_about_title`) to reference localized text.
  - MainWindow constructs all UI controls programmatically and wires event handlers.

Build/Run
- Recommended: Visual Studio Community 2026
  - Open `SystemCleaner.sln`
  - Set Startup Project and Run (F5)
- CLI: ensure .NET 10 SDK installed
  - dotnet build
  - dotnet run --project .

Localization keys (examples)
- tab_cleaner, tab_duplicate, tab_browser, tab_updates, tab_specs, tab_uninstaller, tab_startup, tab_about
- hdr_cleaner, hdr_duplicate, hdr_tuneup, hdr_browser, hdr_updates, hdr_specs, hdr_uninstaller, hdr_startup, hdr_about_title
- status_ready, dup_status, tuneup_status, browser_status, app_update_status, specs_subtext
- btn_run_clean, btn_scan_dup, btn_delete_dup, btn_tuneup, btn_visit_website, btn_donate, etc.

Notes
- The UI is created procedurally in Program.cs. For larger changes consider splitting views into separate files.
- The PayPal donation button opens a PayPal.me link; update the URL in Program.cs if you want to change it.

Suggested next tasks
- Add a proper resource-based localization system (RESX or external JSON) to replace the inline maps.
- Add unit tests and CI (GitHub Actions) for builds.
- Add LICENSE and CONTRIBUTING.md
