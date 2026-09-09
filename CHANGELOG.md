# Changelog

All notable changes to this project will be documented in this file.

Unreleased
---------
### v2.5.3 - Unreleased
- Feature: AI Smart Clean enhancements — allow selecting specific folders and drives to scan and clean. Users can now add custom folders or pick drives to include in scans.
- Feature: Include additional cleanup targets (optional checkboxes):
  - Clear Temp files (system and user temp folders)
  - Remove system crash dumps and minidumps
  - Empty Recycle Bin / Trash
  - Clear Downloads folder (optional)
  - Include system drivers folders (advanced; use with caution)
- Feature: Browser Cleaner improvements — fixed cross-thread crash and made cleanup asynchronous with limited concurrency and robust error handling for locked files.
- Dev: Add cross-platform publish scripts and a GitHub Actions workflow to produce self-contained artifacts for Windows, macOS, and Linux.
- Fix: UI/Build fixes (moved helper dialog class, updated version badge)

Released
--------
### v2.5.2 - 2026-09-09
- Fix: Browser cleanup crash when run from background thread. The cleanup now captures UI state on the UI thread and performs asynchronous, limited-concurrency file deletions to avoid cross-thread access and improve robustness.
- Enhancement: Add options and improved handling for additional cleanup targets:
  - Empty the Recycle Bin / Trash when selected.
  - Clear system and application temp folders (Windows %TEMP%, user temp, macOS /tmp, Linux /tmp).
  - Remove Windows crash dump and minidump files (.dmp) to free large diagnostic files.
  - Optionally clear the Downloads folder temporary files (user-selected) to remove stale installers and archives.
  - Skip files that are locked/in use and continue processing remaining items.

Released
--------
### v2.5.1 - 2026-09-08
- Add Linux support improvements:
  - Browser cache cleanup paths for Chrome/Chromium and Microsoft Edge on Linux
  - Installed applications discovery via .desktop files and /opt directory scanning
  - Limited uninstall support for /opt-installed apps; other removals should use the system package manager
- Improved localization:
  - Localized About tab text and buttons (Visit website, Donate)
  - Fixed Punjabi text issues and refreshed localization keys
- About tab: added PayPal donate button (opens PayPal.me link)
- README updated with cross-platform notes and diagnostic suggestions

Released
--------
### v2.5.0 - Initial Public Release
- AI Smart Cleaner core features: temp/cache cleaning, duplicate finder, tuneup helpers
- Browser cleanup for Chrome & Edge (Windows/macOS)
- App uninstaller, startup manager, and system specs view
- Localization support for English, French, Hindi, Punjabi
- Avalonia UI with Fluent theme (cross-platform UI)

Notes
-----
- The app version displayed in the UI is currently v2.5.0 (Program.cs). Unreleased changes are targeted for v2.5.1.
- When you are ready to release, update the version badge in Program.cs and move the Unreleased section under a released heading with a date.
