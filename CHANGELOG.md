# Changelog

All notable changes to this project will be documented in this file.

Unreleased
---------
### v2.5.2 - Unreleased
- Fix: Browser cleanup crash when run from background thread. The cleanup now captures UI state on the UI thread and performs asynchronous, limited-concurrency file deletions to avoid cross-thread access and improve robustness.

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
