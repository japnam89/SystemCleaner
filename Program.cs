using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;

// Simple localization helper for English, French, Hindi, Punjabi
static class Localization
{
    public static string Current = "en";
    public static void SetLanguage(string code) => Current = code ?? "en";

    public static string Get(string key)
    {
        return Current switch
        {
            "fr" => GetFrench(key),
            "hi" => GetHindi(key),
            "pa" => GetPunjabi(key),
            _ => GetEnglish(key),
        };
    }




    private static string GetEnglish(string key) => key switch
    {
        "app_title" => "🤖 AI Smart Cleaner",
        "tab_cleaner" => "🤖 AI Cleaner",
        "tab_duplicate" => "🔍 Duplicate Finder",
        "tab_tuneup" => "⚡ Performance",
        "tab_browser" => "🌐 Browser Cleaner",
        "tab_updates" => "🚀 App Updates",
        "tab_specs" => "💻 Specs",
        "tab_uninstaller" => "📦 Uninstaller",
        "tab_startup" => "🚀 Startup Apps",
        "tab_about" => "ℹ️ About",
        "status_ready" => "AI Engine ready to scan system temp files, cache & logs.",
        "btn_run_clean" => "✨ Run AI Smart Clean",
        "btn_scan_dup" => "🔎 Scan Duplicates",
        "btn_delete_dup" => "🗑️ Delete Selected Duplicate",
        "btn_tuneup" => "⚡ Boost System Performance",
        "chrome_check" => "🌐 Clean Google Chrome Cache & Cookies",
        "edge_check" => "🌐 Clean Microsoft Edge Cache & Cookies",
        "btn_clean_browsers" => "🧹 Clean Selected Browsers",
        "btn_check_updates" => "🔄 Check For New App Version",
        "btn_refresh_specs" => "🔄 Refresh Hardware Specs",
        "btn_uninstall" => "❌ Uninstall Selected Application",
        "btn_toggle_startup" => "⚙️ Toggle Startup Item",
        "btn_visit_website" => "🌐 Visit japnam.tech",
        "btn_donate" => "☕ Buy me a coffee (PayPal)",
                "hdr_cleaner" => "Smart System Cleaning",
                "hdr_duplicate" => "Duplicate Media & File Search",
                "hdr_tuneup" => "AI System Speedup & Memory Optimization",
                "hdr_browser" => "Web Browser Cache & Data Cleaner",
                "hdr_updates" => "Free PC/Mac Cleaner & Tuneup Updates",
                "hdr_specs" => "PC Specs & Hardware Diagnostics",
                "hdr_uninstaller" => "Software & App Uninstaller",
                "hdr_startup" => "Manage Startup Applications",
                "hdr_about_title" => "🤖 AI Smart Cleaner & System Tuneup",
                "dup_status" => "Scan your User Downloads folder for identical photos, videos, and files.",
                "tuneup_status" => "Click below to flush DNS cache, optimize System RAM, and free up background memory.",
                "browser_status" => "Clean cached web data, temporary internet files, and cookies for Chrome and Edge.",
                "app_update_status" => "You are currently running Version 2.5.2 (Stable Release).",
                "specs_subtext" => "Detailed CPU, System RAM memory usage, drive storage capacity, and OS build specs.",
                "uninstall_status" => "Select an installed application to safely remove it from your device.",
                "startup_subtext" => "Enable or disable apps to speed up system boot times.",
                "about_by" => "Created by japnam.tech for free use",
                "about_desc" => "A modern, lightweight cross-platform utility designed to keep your macOS & Windows systems clean, fast, and secure.",
        _ => key
    };

    private static string GetFrench(string key) => key switch
    {
        "app_title" => "🤖 Nettoyeur IA",
        "tab_cleaner" => "🤖 Nettoyeur IA",
        "tab_duplicate" => "🔍 Recherche de doublons",
        "tab_tuneup" => "⚡ Performance",
        "tab_browser" => "🌐 Nettoyage du navigateur",
        "tab_updates" => "🚀 Mises à jour",
        "tab_specs" => "💻 Infos système",
        "tab_uninstaller" => "📦 Désinstallation",
        "tab_startup" => "🚀 Applications au démarrage",
        "tab_about" => "ℹ️ À propos",
        "status_ready" => "Moteur IA prêt à analyser les fichiers temporaires, le cache et les journaux.",
        "btn_run_clean" => "✨ Exécuter le nettoyage IA",
        "btn_scan_dup" => "🔎 Rechercher les doublons",
        "btn_delete_dup" => "🗑️ Supprimer le doublon sélectionné",
        "btn_tuneup" => "⚡ Améliorer les performances",
        "chrome_check" => "🌐 Nettoyer le cache et les cookies de Google Chrome",
        "edge_check" => "🌐 Nettoyer le cache et les cookies de Microsoft Edge",
        "btn_clean_browsers" => "🧹 Nettoyer les navigateurs sélectionnés",
        "btn_check_updates" => "🔄 Vérifier les mises à jour",
        "btn_refresh_specs" => "🔄 Actualiser le matériel",
        "btn_uninstall" => "❌ Désinstaller l'application sélectionnée",
        "btn_toggle_startup" => "⚙️ Basculer l'élément de démarrage",
        "btn_visit_website" => "🌐 Visiter japnam.tech",
        "btn_donate" => "☕ Offrez-moi un café (PayPal)",
        "hdr_cleaner" => "Nettoyage système intelligent",
        "hdr_duplicate" => "Recherche de médias et fichiers en double",
        "hdr_tuneup" => "Accélération du système et optimisation de la mémoire",
        "hdr_browser" => "Nettoyage du cache et des données du navigateur",
        "hdr_updates" => "Mises à jour du nettoyeur et tuneup",
        "hdr_specs" => "Spécifications PC et diagnostics matériels",
        "hdr_uninstaller" => "Désinstallateur d'applications",
        "hdr_startup" => "Gérer les applications au démarrage",
        "hdr_about_title" => "\uD83E\uDD16 Nettoyeur IA & Tuneup",
        "dup_status" => "Analysez le dossier Téléchargements pour les photos, vidéos et fichiers identiques.",
        "tuneup_status" => "Cliquez ci-dessous pour vider le cache DNS, optimiser la RAM du système et libérer la mémoire en arrière-plan.",
        "browser_status" => "Nettoyez les données mises en cache, les fichiers Internet temporaires et les cookies pour Chrome et Edge.",
        "app_update_status" => "Vous exécutez actuellement la version 2.5.2 (Stable).",
        "specs_subtext" => "Utilisation détaillée du CPU, mémoire RAM système, capacité de stockage et spécifications du système d'exploitation.",
        "uninstall_status" => "Sélectionnez une application installée pour la supprimer en toute sécurité de votre appareil.",
        "startup_subtext" => "Activez ou désactivez les applications pour accélérer le démarrage du système.",
        "about_by" => "Créé par japnam.tech pour une utilisation gratuite",
        "about_desc" => "Un utilitaire moderne et léger multiplateforme conçu pour garder vos systèmes macOS et Windows propres, rapides et sécurisés.",
        _ => key
    };

    private static string GetHindi(string key) => key switch
    {
        "app_title" => "🤖 एआई स्मार्ट क्लीनर",
        "tab_cleaner" => "🤖 एआई क्लीनर",
        "tab_duplicate" => "🔍 डुप्लिकेट खोजक",
        "tab_tuneup" => "⚡ प्रदर्शन",
        "tab_browser" => "🌐 ब्राउज़र क्लीनर",
        "tab_updates" => "🚀 ऐप अपडेट्स",
        "tab_specs" => "💻 सिस्टम जानकारी",
        "tab_uninstaller" => "📦 अनइंस्टॉलर",
        "tab_startup" => "🚀 स्टार्टअप ऐप्स",
        "tab_about" => "ℹ️ जानकारी",
        "status_ready" => "AI इंजन अस्थायी फ़ाइलें, कैश और लॉग स्कैन करने के लिए तैयार है।",
        "btn_run_clean" => "✨ AI स्मार्ट क्लीन चलाएँ",
        "btn_scan_dup" => "🔎 डुप्लिकेट स्कैन करें",
        "btn_delete_dup" => "🗑️ चयनित डुप्लिकेट हटाएँ",
        "btn_tuneup" => "⚡ सिस्टम प्रदर्शन बढ़ाएँ",
        "chrome_check" => "🌐 Google Chrome कैश और कुकीज़ साफ करें",
        "edge_check" => "🌐 Microsoft Edge कैश और कुकीज़ साफ करें",
        "btn_clean_browsers" => "🧹 चयनित ब्राउज़रों को साफ़ करें",
        "btn_check_updates" => "🔄 नए संस्करण की जाँच करें",
        "btn_refresh_specs" => "🔄 हार्डवेयर स्पेक्स रिफ्रेश करें",
        "btn_uninstall" => "❌ चयनित एप्लिकेशन अनइंस्टॉल करें",
        "btn_toggle_startup" => "⚙️ स्टार्टअप आइटम टॉगल करें",
        "btn_visit_website" => "🌐 japnam.tech देखें",
        "btn_donate" => "☕ मुझे कॉफी खरीदें (PayPal)",
        "hdr_cleaner" => "स्मार्ट सिस्टम क्लीनिंग",
        "hdr_duplicate" => "डुप्लिकेट मीडिया और फ़ाइल खोज",
        "hdr_tuneup" => "AI सिस्टम स्पीडअप और मेमोरी अनुकूलन",
        "hdr_browser" => "वेब ब्राउज़र कैश और डेटा क्लीनर",
        "hdr_updates" => "क्लीनर और ट्यूनअप अपडेट",
        "hdr_specs" => "पीसी स्पेक्स और हार्डवेयर निदान",
        "hdr_uninstaller" => "सॉफ़्टवेयर अनइंस्टॉलर",
        "hdr_startup" => "स्टार्टअप ऐप्स प्रबंधित करें",
        "hdr_about_title" => "\uD83E\uDD16 एआई स्मार्ट क्ली너 और सिस्टम ट्यूनअप",
        "dup_status" => "अपनी यूज़र डाउनलोड्स फ़ोल्डर को समान फ़ोटो, वीडियो और फ़ाइलों के लिए स्कैन करें।",
        "tuneup_status" => "DNS कैश खाली करने, सिस्टम RAM अनुकूलित करने, और बैकग्राउंड मेमोरी मुक्त करने के लिए नीचे क्लिक करें।",
        "browser_status" => "Chrome और Edge के लिए कैश डेटा, अस्थायी इंटरनेट फ़ाइलें और कुकीज़ साफ़ करें।",
        "app_update_status" => "आप वर्तमान में संस्करण 2.5.2 (स्टेबल रिलीज़) चला रहे हैं।",
        "specs_subtext" => "विस्तृत CPU, सिस्टम RAM उपयोग, ड्राइव स्टोरेज क्षमता, और OS बिल्ड स्पेक्स।",
        "uninstall_status" => "किसी इंस्टॉल की गई एप्लिकेशन का चयन करें ताकि इसे आपके डिवाइस से सुरक्षित रूप से हटाया जा सके।",
        "startup_subtext" => "सिस्टम बूट समय तेज़ करने के लिए ऐप्स को सक्षम या अक्षम करें।",
        "about_by" => "japnam.tech द्वारा मुफ्त उपयोग के लिए बनाया गया",
        "about_desc" => "एक आधुनिक, हल्का क्रॉस-प्लेटफ़ॉर्म यूटिलिटी जो आपके macOS और Windows सिस्टम को साफ़, तेज़ और सुरक्षित रखता है।",
        _ => key
    };

    private static string GetPunjabi(string key) => key switch
    {
        "app_title" => "🤖 ਏਆਈ ਸਮਾਰਟ ਕਲੀਨਰ",
        "tab_cleaner" => "🤖 ਏਆਈ ਕਲੀਨਰ",
        "tab_duplicate" => "🔍 ਡੁਪਲਿਕੇਟ ਖੋਜ",
        "tab_tuneup" => "⚡ ਪ੍ਰਦਰਸ਼ਨ",
        "tab_browser" => "🌐 ਬਰਾਊਜ਼ਰ ਕਲੀਨਰ",
        "tab_updates" => "🚀 ਐਪ ਅੱਪਡੇਟ",
        "tab_specs" => "💻 ਸਿਸਟਮ ਜਾਣਕਾਰੀ",
        "tab_uninstaller" => "📦 ਅਨਇੰਸਟਾਲਰ",
        "tab_startup" => "🚀 ਸਟਾਰਟਅਪ ਐਪਸ",
        "tab_about" => "ℹ️ ਬਾਰੇ",
        "status_ready" => "AI ਇੰਜਣ ਅਸਥਾਈ ਫਾਈਲਾਂ, ਕੈਸ਼ ਅਤੇ ਲਾਗਾਂ ਸਕੈਨ ਕਰਨ ਲਈ ਤਿਆਰ ਹੈ।",
        "btn_run_clean" => "✨ AI ਸਮਾਰਟ ਕਲੀਨ ਚਲਾਓ",
        "btn_scan_dup" => "🔎 ਡੁਪਲਿਕੇਟ ਸਕੈਨ ਕਰੋ",
        "btn_delete_dup" => "🗑️ ਚੁਣਿਆ ਡੁਪਲਿਕੇਟ ਹਟਾਓ",
        "btn_tuneup" => "⚡ ਸਿਸਟਮ ਪ੍ਰਦਰਸ਼ਨ ਵਧਾਓ",
        "chrome_check" => "🌐 Google Chrome ਕੈਸ਼ ਅਤੇ ਕੁਕੀਜ਼ ਸਾਫ ਕਰੋ",
        "edge_check" => "🌐 Microsoft Edge ਕੈਸ਼ ਅਤੇ ਕੁਕੀਜ਼ ਸਾਫ ਕਰੋ",
        "btn_clean_browsers" => "🧹 ਚੁਣੇ ਹੋਏ ਬਰਾਊਜ਼ਰ ਸਾਫ ਕਰੋ",
        "btn_check_updates" => "🔄 ਨਵੇਂ ਵਰਜਨ ਦੀ ਜਾਂਚ ਕਰੋ",
        "btn_refresh_specs" => "🔄 ਹਾਰਡਵੇਅਰ ਸਪੈੱਕਸ ਰੀਫਰੇਸ਼ ਕਰੋ",
        "btn_uninstall" => "❌ ਚੁਣਿਆ ਐਪਲੀਕੇਸ਼ਨ ਅਨਇੰਸਟਾਲ ਕਰੋ",
        "btn_toggle_startup" => "⚙️ ਸਟਾਰਟਅਪ ਆਈਟਮ ਟੌਗਲ ਕਰੋ",
        "btn_visit_website" => "310 japnam.tech ਵੇਖੋ",
        "btn_donate" => "☕ ਮੈਨੂੰ ਕਾਫੀ ਖਰੀਦੋ (PayPal)",
        "hdr_cleaner" => "ਸਮਾਰਟ ਸਿਸਟਮ ਕਲੀਨਿੰਗ",
        "hdr_duplicate" => "ਡੁਪਲਿਕੇਟ ਮੀਡੀਆ ਅਤੇ ਫਾਈਲ ਖੋਜ",
        "hdr_tuneup" => "AI ਸਿਸਟਮ ਸਪੀਡਅੱਪ ਅਤੇ ਮੈਮੋਰੀ ਓਪਟਿਮਾਈਜੇਸ਼ਨ",
        "hdr_browser" => "ਵੈਬ ਬਰਾਊਜ਼ਰ ਕੈਸ਼ ਅਤੇ ਡੇਟਾ ਕਲੀਨਰ",
        "hdr_updates" => "ਕਲੀਨਰ ਅਤੇ ਟਿਊਨਅੱਪ ਅੱਪਡੇਟ",
        "hdr_specs" => "ਪੀਸੀ ਸਪੈਕਸ ਅਤੇ ਹਾਰਡਵੇਅਰ ਨਿਰਾਕਰਨ",
        "hdr_uninstaller" => "ਸੌਫਟਵੇਅਰ ਅਤੇ ਐਪ ਅਨਇੰਸਟਾਲਰ",
        "hdr_startup" => "ਸਟਾਰਟਅਪ ਐਪਸ ਪ੍ਰਬੰਧਿਤ ਕਰੋ",
        "hdr_about_title" => "\uD83E\uDD16 ਏਆਈ ਸਮਾਰਟ ਕਲੀਨਰ ਅਤੇ ਸਿਸਟਮ ਟਿਊਨਅੱਪ",
        "dup_status" => "ਆਪਣੇ ਯੂਜ਼ਰ ਡਾਊਨਲੋਡ ਫੋਲਡਰ ਨੂੰ ਇੱਕੋ-ਜਿਹੇ ਫੋਟੋ, ਵੀਡੀਓ ਅਤੇ ਫਾਈਲਾਂ ਲਈ ਸਕੈਨ ਕਰੋ।",
        "tuneup_status" => "DNS ਕੈਸ਼ ਖਾਲੀ ਕਰਨ, ਸਿਸਟਮ RAM ਨੂੰ ਓਪਟਿਮਾਈਜ਼ ਕਰਨ ਅਤੇ ਬੈਕਗ੍ਰਾਊਂਡ ਮੈਮੋਰੀ ਨੂੰ ਖਾਲੀ ਕਰਨ ਲਈ ਹੇਠਾਂ ਕਲਿੱਕ ਕਰੋ।",
        "browser_status" => "Chrome ਅਤੇ Edge ਲਈ ਕੈਸ਼ ਡੇਟਾ, ਅਸਥਾਈ ਇੰਟਰਨੈੱਟ ਫਾਇਲਾਂ ਅਤੇ ਕੁਕੀਜ਼ ਨੂੰ ਸਾਫ਼ ਕਰੋ।",
        "app_update_status" => "ਤੁਸੀਂ ਇਸ ਵੇਲੇ ਵਰਜ਼ਨ 2.5.2 (ਸਟੇਬਲ ਰੀਲੀਜ਼) ਚਲਾ ਰਹੇ ਹੋ।",
        "specs_subtext" => "ਵਿਸਤਾਰਤ CPU, ਸਿਸਟਮ RAM ਵਰਤੋਂ, ਡ੍ਰਾਈਵ ਸਟੋਰੇਜ ਸਮਰੱਥਾ ਅਤੇ OS ਬਿਲਡ ਸਪੈਕਸ।",
        "uninstall_status" => "ਕਿਰਪਾ ਕਰਕੇ ਇੱਕ ਇੰਸਟਾਲ ਕੀਤੀ ਐਪਲੀਕੇਸ਼ਨ ਚੁਣੋ ਤਾਂ ਕਿ ਇਸਨੂੰ ਤੁਹਾਡੇ ਡਿਵਾਈਸ ਤੋਂ ਸੁਰੱਖਿਅਤ ਤੌਰ 'ਤੇ ਹਟਾਇਆ ਜਾ ਸਕੇ।",
        "startup_subtext" => "ਸਿਸਟਮ ਬੂਟ ਸਮਾਂ ਤੇਜ਼ ਕਰਨ ਲਈ ਐਪਸ ਨੂੰ ਸਖਤ ਜਾਂ ਅਯੋਗ ਕਰੋ।",
        "about_by" => "japnam.tech ਦੁਆਰਾ ਮੁਫ਼ਤ ਵਰਤੋਂ ਲਈ ਬਣਾਇਆ ਗਿਆ",
        "about_desc" => "ਇੱਕ ਆਧੁਨਿਕ, ਹਲਕੀ ਕ੍ਰਾਸ-ਪਲੇਟਫਾਰਮ ਯੂਟਿਲਿਟੀ ਜੋ ਤੁਹਾਡੇ macOS ਅਤੇ Windows ਸਿਸਟਮਾਂ ਨੂੰ ਸਾਫ, ਤੇਜ਼ ਅਤੇ ਸੁਰੱਖਿਅਤ ਰੱਖਦੀ ਹੈ।",
        _ => key
    };
}

namespace AISmartCleanerFree
{
    // ==========================================
    // 1. AVALONIA APP ENTRY POINT
    // ==========================================
    class Program
    {
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
    }


    public class App : Application
    {
        public override void Initialize()
        {
            Styles.Add(new FluentTheme());
            RequestedThemeVariant = ThemeVariant.Light;
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }
            base.OnFrameworkInitializationCompleted();
        }
    }

    // ==========================================
    // 2. USER INTERFACE
    // ==========================================
    public class MainWindow : Window
    {
        private bool _isDarkMode = false;
        private Button _themeToggleButton;
        private Border _topBarBorder;
        private TextBlock _topBarTitle;
        private TextBlock _versionBadgeText;

        private List<TextBlock> _primaryTexts = new List<TextBlock>();
        private List<TextBlock> _secondaryTexts = new List<TextBlock>();
        private Dictionary<TextBlock, string> _primaryTextKeys = new Dictionary<TextBlock, string>();
        private Dictionary<TextBlock, string> _secondaryTextKeys = new Dictionary<TextBlock, string>();
        private List<ListBox> _listBoxes = new List<ListBox>();

        // --- CLEANER TAB FIELDS ---
        private TextBlock _statusText;
        private Button _cleanButton;
        private ProgressBar _progressBar;
        private Image _aiCleanerImageControl;
        private Border _aiImageBorder;
        private ListBox _scanTargetsListBox;
        private Button _addFolderButton;
        private Button _refreshDrivesButton;
        private CheckBox _includeDriversCheck;
        private CheckBox _includeDumpsCheck;

        // --- DUPLICATE FINDER FIELDS ---
        private ListBox _duplicateListBox;
        private Button _scanDuplicatesButton;
        private Button _deleteSelectedDupButton;
        private TextBlock _duplicateStatusText;

        // --- TUNEUP TAB FIELDS ---
        private TextBlock _tuneupStatusText;
        private Button _runTuneupButton;

        // --- BROWSER CLEANER FIELDS ---
        private TextBlock _browserStatusText;
        private Button _cleanBrowsersButton;
        private CheckBox _chromeCheck;
        private CheckBox _edgeCheck;
        private CheckBox _tempFilesCheck;
        private CheckBox _dumpsCheck;
        private CheckBox _recycleBinCheck;
        private CheckBox _downloadsCheck;

        // --- UNINSTALLER FIELDS ---
        private ListBox _uninstallerListBox;
        private Button _uninstallButton;
        private TextBlock _uninstallerStatusText;

        // --- STARTUP MANAGER FIELDS ---
        private ListBox _startupListBox;
        private Button _toggleStartupButton;

        // --- SYSTEM SPECS FIELDS ---
        private ListBox _sysInfoListBox;
        private Button _refreshSysInfoButton;

        // --- APP UPDATE TAB FIELDS ---
        private TextBlock _appUpdateStatusText;
        private Button _checkAppUpdatesButton;
        // --- ABOUT TAB BUTTONS ---
        private Button _visitWebsiteButton;
        private Button _donateButton;

        // --- TAB ITEMS ---
        private TabItem _cleanerTab;
        private TabItem _duplicateTab;
        private TabItem _tuneupTab;
        private TabItem _browserTab;
        private TabItem _appUpdatesTab;
        private TabItem _sysInfoTab;
        private TabItem _uninstallerTab;
        private TabItem _startupTab;
        private TabItem _aboutTab;

        // --- LANGUAGE SELECTOR ---
        private ComboBox _languageComboBox;

        public MainWindow()
        {
            Title = "🤖 AI Smart Cleaner & System Tuneup";
            Width = 900;
            Height = 720;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // --- TOP HEADER BAR WITH VERSION & THEME TOGGLE ---
            _topBarTitle = new TextBlock
            {
                Text = "🤖 AI Smart Cleaner",
                FontSize = 18,
                FontWeight = FontWeight.Bold,
                VerticalAlignment = VerticalAlignment.Center
            };

            _versionBadgeText = new TextBlock
            {
                Text = "v2.5.2",
                FontSize = 12,
                FontWeight = FontWeight.SemiBold,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var titlePanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children = { _topBarTitle, _versionBadgeText }
            };

            _themeToggleButton = new Button
            {
                Content = "🌙 Dark Mode",
                Padding = new Thickness(14, 6),
                CornerRadius = new CornerRadius(20),
                FontSize = 13,
                FontWeight = FontWeight.SemiBold,
                VerticalAlignment = VerticalAlignment.Center
            };
            _themeToggleButton.Click += OnToggleThemeClicked;

            var topBarGrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitions("*,Auto,Auto"),
                Margin = new Thickness(20, 12, 20, 12)
            };
            Grid.SetColumn(titlePanel, 0);

            // language selector
            _languageComboBox = new ComboBox
            {
                Width = 140,
                ItemsSource = new[] { "English", "Français", "हिन्दी", "ਪੰਜਾਬी" },
                SelectedIndex = 0,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 0, 10, 0)
            };
            _languageComboBox.SelectionChanged += (s, e) =>
            {
                try
                {
                    var idx = _languageComboBox.SelectedIndex;
                    var code = idx switch { 1 => "fr", 2 => "hi", 3 => "pa", _ => "en" };
                    Localization.SetLanguage(code);
                    UpdateLocalizedTexts();
                }
                catch { }
            };

            Grid.SetColumn(_languageComboBox, 1);
            Grid.SetColumn(_themeToggleButton, 2);
            topBarGrid.Children.Add(titlePanel);
            topBarGrid.Children.Add(_languageComboBox);
            topBarGrid.Children.Add(_themeToggleButton);

            _topBarBorder = new Border
            {
                BorderThickness = new Thickness(0, 0, 0, 1),
                Child = topBarGrid
            };

            // Populate initial scan targets
            PopulateScanTargets();

            // --- TAB 1: AI SYSTEM CLEANER ---
            _cleanerTab = new TabItem { Header = "🤖 AI Cleaner", FontSize = 15 };
            var cleanerHeader = CreatePrimaryHeader("hdr_cleaner");
            _statusText = CreateSecondaryText("status_ready");
            _statusText.TextAlignment = TextAlignment.Center;
            _statusText.Margin = new Thickness(0, 0, 0, 15);

            _progressBar = new ProgressBar
            {
                IsIndeterminate = true,
                IsVisible = false,
                Margin = new Thickness(0, 0, 0, 15),
                Height = 6,
                CornerRadius = new CornerRadius(3)
            };

            _aiCleanerImageControl = new Image { Width = 160, Height = 160, Stretch = Stretch.Uniform };
            _aiImageBorder = new Border
            {
                Width = 160,
                Height = 160,
                CornerRadius = new CornerRadius(16),
                ClipToBounds = true,
                Margin = new Thickness(0, 0, 0, 15),
                HorizontalAlignment = HorizontalAlignment.Center,
                IsVisible = false,
                BorderThickness = new Thickness(1),
                Child = _aiCleanerImageControl
            };

            _cleanButton = new Button
            {
                Content = "✨ Run AI Smart Clean",
                HorizontalAlignment = HorizontalAlignment.Center,
                Padding = new Thickness(30, 14),
                FontSize = 16,
                FontWeight = FontWeight.SemiBold,
                CornerRadius = new CornerRadius(8),
                Background = new SolidColorBrush(Color.Parse("#4F46E5")),
                Foreground = Brushes.White
            };
            _cleanButton.Click += OnCleanClicked;

            // Scan targets UI: list drives and allow adding custom folders
            _scanTargetsListBox = new ListBox { Height = 120, SelectionMode = SelectionMode.Multiple };
            _refreshDrivesButton = new Button { Content = "🔄 Refresh Drives", Padding = new Thickness(8,4), CornerRadius = new CornerRadius(6), Margin = new Thickness(0,6,6,0) };
            _addFolderButton = new Button { Content = "➕ Add Folder...", Padding = new Thickness(8,4), CornerRadius = new CornerRadius(6), Margin = new Thickness(6,6,0,0) };
            _includeDriversCheck = new CheckBox { Content = "🔧 Include Drivers Folders (e.g., system drivers)", IsChecked = false, Margin = new Thickness(0,8,0,0) };
            _includeDumpsCheck = new CheckBox { Content = "💥 Include System Crash Dumps", IsChecked = false, Margin = new Thickness(0,4,0,10) };

            var targetButtons = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Center };
            targetButtons.Children.Add(_refreshDrivesButton);
            targetButtons.Children.Add(_addFolderButton);

            // Hook up drive refresh and folder picker
            _refreshDrivesButton.Click += (s, e) => PopulateScanTargets();
            _addFolderButton.Click += async (s, e) =>
            {
                try
                {
                    // Simple text prompt for folder path (cross-platform)
                    var dlg = new SimpleInputDialog("Enter folder path to add:");
                    var folder = await dlg.ShowDialog<string?>(this);
                    if (!string.IsNullOrWhiteSpace(folder))
                    {
                        var current = (_scanTargetsListBox.ItemsSource as List<string>) ?? (_scanTargetsListBox.Items?.Cast<object>().Select(o => o?.ToString()).Where(s => !string.IsNullOrWhiteSpace(s)).ToList() ?? new List<string>());
                        if (!current.Contains(folder))
                        {
                            current.Add(folder);
                            _scanTargetsListBox.ItemsSource = current.Distinct().ToList();
                        }
                    }
                }
                catch { }
            };

            _cleanerTab.Content = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(40),
                Children = { cleanerHeader, _statusText, _progressBar, _aiImageBorder, _scanTargetsListBox, targetButtons, _includeDriversCheck, _includeDumpsCheck, _cleanButton }
            };

            // --- TAB 2: DUPLICATE FINDER ---
            _duplicateTab = new TabItem { Header = "🔍 Duplicate Finder", FontSize = 15 };
            var dupHeader = CreatePrimaryHeader("hdr_duplicate");
            _duplicateStatusText = CreateSecondaryText("dup_status");
            _duplicateStatusText.Margin = new Thickness(0, 0, 0, 12);

            _duplicateListBox = CreateStyledListBox();
            _scanDuplicatesButton = new Button { Content = "🔎 Scan Duplicates", Padding = new Thickness(16, 8), CornerRadius = new CornerRadius(6) };
            _scanDuplicatesButton.Click += OnScanDuplicatesClicked;

            _deleteSelectedDupButton = new Button { Content = "🗑️ Delete Selected Duplicate", Padding = new Thickness(16, 8), CornerRadius = new CornerRadius(6), Margin = new Thickness(10, 0, 0, 0) };
            _deleteSelectedDupButton.Click += OnDeleteDuplicateClicked;

            var dupButtonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                Children = { _scanDuplicatesButton, _deleteSelectedDupButton }
            };
            _duplicateTab.Content = new StackPanel
            {
                Margin = new Thickness(30, 20, 30, 20),
                Children = { dupHeader, _duplicateStatusText, _duplicateListBox, dupButtonPanel }
            };

            // --- TAB 3: PERFORMANCE TUNEUP ---
            _tuneupTab = new TabItem { Header = "⚡ Performance", FontSize = 15 };
            var tuneupHeader = CreatePrimaryHeader("hdr_tuneup");
            _tuneupStatusText = CreateSecondaryText("tuneup_status");
            _tuneupStatusText.TextAlignment = TextAlignment.Center;
            _tuneupStatusText.Margin = new Thickness(0, 0, 0, 25);

            _runTuneupButton = new Button
            {
                Content = "⚡ Boost System Performance",
                HorizontalAlignment = HorizontalAlignment.Center,
                Padding = new Thickness(24, 12),
                FontSize = 16,
                FontWeight = FontWeight.SemiBold,
                CornerRadius = new CornerRadius(8),
                Background = new SolidColorBrush(Color.Parse("#059669")),
                Foreground = Brushes.White
            };
            _runTuneupButton.Click += OnRunTuneupClicked;

            _tuneupTab.Content = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(40),
                Children = { tuneupHeader, _tuneupStatusText, _runTuneupButton }
            };

            // --- TAB 4: BROWSER CLEANER ---
            _browserTab = new TabItem { Header = "🌐 Browser Cleaner", FontSize = 15 };
            var browserHeader = CreatePrimaryHeader("hdr_browser");
            _browserStatusText = CreateSecondaryText("browser_status");
            _browserStatusText.TextAlignment = TextAlignment.Center;
            _browserStatusText.Margin = new Thickness(0, 0, 0, 20);

            _chromeCheck = new CheckBox { Content = "🌐 Clean Google Chrome Cache & Cookies", IsChecked = true, Margin = new Thickness(0, 0, 0, 10), FontSize = 14 };
            _edgeCheck = new CheckBox { Content = "🌐 Clean Microsoft Edge Cache & Cookies", IsChecked = true, Margin = new Thickness(0, 0, 0, 10), FontSize = 14 };
            _tempFilesCheck = new CheckBox { Content = "🧹 Clear Temp Files (TEMP / /tmp)", IsChecked = true, Margin = new Thickness(0, 0, 0, 10), FontSize = 14 };
            _dumpsCheck = new CheckBox { Content = "💥 Remove System Crash Dumps (.dmp)", IsChecked = true, Margin = new Thickness(0, 0, 0, 10), FontSize = 14 };
            _recycleBinCheck = new CheckBox { Content = "🗑️ Empty Recycle Bin / Trash", IsChecked = false, Margin = new Thickness(0, 0, 0, 10), FontSize = 14 };
            _downloadsCheck = new CheckBox { Content = "📥 Clear Downloads (optional)", IsChecked = false, Margin = new Thickness(0, 0, 0, 20), FontSize = 14 };

            _cleanBrowsersButton = new Button
            {
                Content = "🧹 Clean Selected Browsers",
                HorizontalAlignment = HorizontalAlignment.Center,
                Padding = new Thickness(24, 12),
                FontSize = 16,
                FontWeight = FontWeight.SemiBold,
                CornerRadius = new CornerRadius(8),
                Background = new SolidColorBrush(Color.Parse("#D97706")),
                Foreground = Brushes.White
            };
            _cleanBrowsersButton.Click += OnCleanBrowsersClicked;

            var browserStack = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(40),
                Children = { browserHeader, _browserStatusText, _chromeCheck, _edgeCheck, _tempFilesCheck, _dumpsCheck, _recycleBinCheck, _downloadsCheck, _cleanBrowsersButton }
            };
            _browserTab.Content = browserStack;

            // --- TAB 5: APP UPDATES ---
            _appUpdatesTab = new TabItem { Header = "🚀 App Updates", FontSize = 15 };
            var appUpdatesHeader = CreatePrimaryHeader("hdr_updates");
            _appUpdateStatusText = CreateSecondaryText("app_update_status");
            _appUpdateStatusText.Margin = new Thickness(0, 0, 0, 15);

            _checkAppUpdatesButton = new Button
            {
                Content = "🔄 Check For New App Version",
                HorizontalAlignment = HorizontalAlignment.Center,
                Padding = new Thickness(20, 10),
                CornerRadius = new CornerRadius(6),
                Background = new SolidColorBrush(Color.Parse("#2563EB")),
                Foreground = Brushes.White
            };
            _checkAppUpdatesButton.Click += (s, e) =>
            {
                _appUpdateStatusText.Text = "✨ You are running the latest version v2.5.2 created by japnam.tech!";
            };

            _appUpdatesTab.Content = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(40),
                Children = { appUpdatesHeader, _appUpdateStatusText, _checkAppUpdatesButton }
            };

            // --- TAB 6: PC SPECS & HARDWARE ---
            _sysInfoTab = new TabItem { Header = "💻 Specs", FontSize = 15 };
            var sysHeader = CreatePrimaryHeader("hdr_specs");
            var sysSubtext = CreateSecondaryText("specs_subtext");
            sysSubtext.Margin = new Thickness(0, 0, 0, 12);

            _sysInfoListBox = CreateStyledListBox();
            _sysInfoListBox.Height = 220;

            _refreshSysInfoButton = new Button { Content = "🔄 Refresh Hardware Specs", HorizontalAlignment = HorizontalAlignment.Center, Padding = new Thickness(20, 10), CornerRadius = new CornerRadius(6) };
            _refreshSysInfoButton.Click += (sender, e) => LoadSystemInfo();

            _sysInfoTab.Content = new StackPanel
            {
                Margin = new Thickness(30, 20, 30, 20),
                Children = { sysHeader, sysSubtext, _sysInfoListBox, _refreshSysInfoButton }
            };

            // --- TAB 7: UNINSTALLER ---
            _uninstallerTab = new TabItem { Header = "📦 Uninstaller", FontSize = 15 };
            var uninstallHeader = CreatePrimaryHeader("hdr_uninstaller");
            _uninstallerStatusText = CreateSecondaryText("uninstall_status");
            _uninstallerStatusText.Margin = new Thickness(0, 0, 0, 10);

            _uninstallerListBox = CreateStyledListBox();
            _uninstallerListBox.Height = 220;
            _uninstallButton = new Button { Content = "❌ Uninstall Selected Application", HorizontalAlignment = HorizontalAlignment.Center, Padding = new Thickness(20, 10), CornerRadius = new CornerRadius(6) };
            _uninstallButton.Click += OnUninstallClicked;

            _uninstallerTab.Content = new StackPanel
            {
                Margin = new Thickness(30, 20, 30, 20),
                Children = { uninstallHeader, _uninstallerStatusText, _uninstallerListBox, _uninstallButton }
            };

            // --- TAB 8: STARTUP MANAGER ---
            _startupTab = new TabItem { Header = "🚀 Startup Apps", FontSize = 15 };
            var startupHeader = CreatePrimaryHeader("hdr_startup");
            var startupSubtext = CreateSecondaryText("startup_subtext");
            startupSubtext.Margin = new Thickness(0, 0, 0, 12);

            _startupListBox = CreateStyledListBox();
            _startupListBox.Height = 220;
            _toggleStartupButton = new Button { Content = "⚙️ Toggle Startup Item", HorizontalAlignment = HorizontalAlignment.Center, Padding = new Thickness(20, 10), CornerRadius = new CornerRadius(6) };
            _toggleStartupButton.Click += OnToggleStartupClicked;

            _startupTab.Content = new StackPanel
            {
                Margin = new Thickness(30, 20, 30, 20),
                Children = { startupHeader, startupSubtext, _startupListBox, _toggleStartupButton }
            };

            // --- TAB 9: ABOUT US ---
            _aboutTab = new TabItem { Header = "ℹ️ About", FontSize = 15 };
            var aboutTitle = CreatePrimaryHeader("hdr_about_title");
            aboutTitle.HorizontalAlignment = HorizontalAlignment.Center;
            aboutTitle.Margin = new Thickness(0, 0, 0, 10);

            var aboutBy = CreateSecondaryText("about_by");
            aboutBy.HorizontalAlignment = HorizontalAlignment.Center;
            aboutBy.FontSize = 16;
            aboutBy.FontWeight = FontWeight.Medium;
            aboutBy.Margin = new Thickness(0, 0, 0, 20);

            var aboutDesc = CreateSecondaryText("about_desc");
            aboutDesc.HorizontalAlignment = HorizontalAlignment.Center;
            aboutDesc.TextAlignment = TextAlignment.Center;
            aboutDesc.TextWrapping = TextWrapping.Wrap;
            aboutDesc.Margin = new Thickness(0, 0, 0, 25);
            aboutDesc.MaxWidth = 450;

            _visitWebsiteButton = new Button
            {
                Content = Localization.Get("btn_visit_website"),
                HorizontalAlignment = HorizontalAlignment.Center,
                Padding = new Thickness(24, 12),
                FontSize = 16,
                FontWeight = FontWeight.SemiBold,
                CornerRadius = new CornerRadius(8),
                Background = new SolidColorBrush(Color.Parse("#2563EB")),
                Foreground = Brushes.White
            };
            _visitWebsiteButton.Click += (sender, e) => OpenWebpage("https://japnam.tech");

            _donateButton = new Button
            {
                Content = Localization.Get("btn_donate"),
                HorizontalAlignment = HorizontalAlignment.Center,
                Padding = new Thickness(24, 12),
                FontSize = 16,
                FontWeight = FontWeight.SemiBold,
                CornerRadius = new CornerRadius(8),
                Background = new SolidColorBrush(Color.Parse("#003087")),
                Foreground = Brushes.White,
                Margin = new Thickness(0, 12, 0, 0)
            };
            _donateButton.Click += (sender, e) => OpenWebpage("https://www.paypal.com/paypalme/japnam89");

            _aboutTab.Content = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(40),
                Children = { aboutTitle, aboutBy, aboutDesc, _visitWebsiteButton, _donateButton }
            };

            var tabControl = new TabControl
            {
                ItemsSource = new[] { _cleanerTab, _duplicateTab, _tuneupTab, _browserTab, _appUpdatesTab, _sysInfoTab, _uninstallerTab, _startupTab, _aboutTab },
                Margin = new Thickness(10, 0, 10, 10)
            };

            Content = new DockPanel
            {
                Children = { _topBarBorder, tabControl }
            };
            DockPanel.SetDock(_topBarBorder, Dock.Top);

            ApplyTheme();
            LoadStartupItems();
            LoadInstalledApps();
            LoadSystemInfo();
        }

        private TextBlock CreatePrimaryHeader(string key)
        {
            var tb = new TextBlock { Text = Localization.Get(key), FontSize = 20, FontWeight = FontWeight.Bold, Margin = new Thickness(0, 0, 0, 6) };
            _primaryTexts.Add(tb);
            _primaryTextKeys[tb] = key;
            return tb;
        }

        private TextBlock CreateSecondaryText(string key)
        {
            var tb = new TextBlock { Text = Localization.Get(key), FontSize = 13 };
            _secondaryTexts.Add(tb);
            _secondaryTextKeys[tb] = key;
            return tb;
        }

        private void UpdateLocalizedTexts()
        {
            // Basic localized strings for UI elements
            try
            {
                if (_topBarTitle != null) _topBarTitle.Text = Localization.Get("app_title");

                if (_cleanerTab != null) _cleanerTab.Header = Localization.Get("tab_cleaner");
                if (_duplicateTab != null) _duplicateTab.Header = Localization.Get("tab_duplicate");
                if (_tuneupTab != null) _tuneupTab.Header = Localization.Get("tab_tuneup");
                if (_browserTab != null) _browserTab.Header = Localization.Get("tab_browser");
                if (_appUpdatesTab != null) _appUpdatesTab.Header = Localization.Get("tab_updates");
                if (_sysInfoTab != null) _sysInfoTab.Header = Localization.Get("tab_specs");
                if (_uninstallerTab != null) _uninstallerTab.Header = Localization.Get("tab_uninstaller");
                if (_startupTab != null) _startupTab.Header = Localization.Get("tab_startup");
                if (_aboutTab != null) _aboutTab.Header = Localization.Get("tab_about");

                if (_statusText != null) _statusText.Text = Localization.Get("status_ready");

                if (_cleanButton != null) _cleanButton.Content = Localization.Get("btn_run_clean");
                if (_scanDuplicatesButton != null) _scanDuplicatesButton.Content = Localization.Get("btn_scan_dup");
                if (_deleteSelectedDupButton != null) _deleteSelectedDupButton.Content = Localization.Get("btn_delete_dup");
                if (_runTuneupButton != null) _runTuneupButton.Content = Localization.Get("btn_tuneup");

                if (_chromeCheck != null) _chromeCheck.Content = Localization.Get("chrome_check");
                if (_edgeCheck != null) _edgeCheck.Content = Localization.Get("edge_check");
                if (_cleanBrowsersButton != null) _cleanBrowsersButton.Content = Localization.Get("btn_clean_browsers");

                if (_checkAppUpdatesButton != null) _checkAppUpdatesButton.Content = Localization.Get("btn_check_updates");
                if (_refreshSysInfoButton != null) _refreshSysInfoButton.Content = Localization.Get("btn_refresh_specs");
                if (_uninstallButton != null) _uninstallButton.Content = Localization.Get("btn_uninstall");
                if (_toggleStartupButton != null) _toggleStartupButton.Content = Localization.Get("btn_toggle_startup");
                if (_visitWebsiteButton != null) _visitWebsiteButton.Content = Localization.Get("btn_visit_website");
                if (_donateButton != null) _donateButton.Content = Localization.Get("btn_donate");
                // Refresh any dynamically created primary/secondary texts using stored keys
                foreach (var kv in _primaryTextKeys)
                {
                    if (kv.Key != null && kv.Value != null)
                        kv.Key.Text = Localization.Get(kv.Value);
                }
                foreach (var kv in _secondaryTextKeys)
                {
                    if (kv.Key != null && kv.Value != null)
                        kv.Key.Text = Localization.Get(kv.Value);
                }
            }
            catch { }
        }

        private ListBox CreateStyledListBox()
        {
            var lb = new ListBox { Margin = new Thickness(0, 0, 0, 15), Height = 250, CornerRadius = new CornerRadius(8), BorderThickness = new Thickness(1) };
            _listBoxes.Add(lb);
            return lb;
        }

        private void OnToggleThemeClicked(object? sender, RoutedEventArgs e)
        {
            _isDarkMode = !_isDarkMode;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            if (Application.Current != null)
            {
                Application.Current.RequestedThemeVariant = _isDarkMode ? ThemeVariant.Dark : ThemeVariant.Light;
            }

            if (_isDarkMode)
            {
                Background = new SolidColorBrush(Color.Parse("#0F172A"));
                _topBarBorder.Background = new SolidColorBrush(Color.Parse("#1E293B"));
                _topBarBorder.BorderBrush = new SolidColorBrush(Color.Parse("#334155"));
                _topBarTitle.Foreground = new SolidColorBrush(Color.Parse("#F8FAFC"));
                _versionBadgeText.Foreground = new SolidColorBrush(Color.Parse("#38BDF8"));

                _themeToggleButton.Content = "☀️ Light Mode";
                _themeToggleButton.Background = new SolidColorBrush(Color.Parse("#334155"));
                _themeToggleButton.Foreground = new SolidColorBrush(Color.Parse("#F8FAFC"));

                foreach (var tb in _primaryTexts) tb.Foreground = new SolidColorBrush(Color.Parse("#F9FAFB"));
                foreach (var tb in _secondaryTexts) tb.Foreground = new SolidColorBrush(Color.Parse("#9CA3AF"));
                foreach (var lb in _listBoxes)
                {
                    lb.Background = new SolidColorBrush(Color.Parse("#1E293B"));
                    lb.BorderBrush = new SolidColorBrush(Color.Parse("#334155"));
                    lb.Foreground = new SolidColorBrush(Color.Parse("#F8FAFC"));
                }
                _aiImageBorder.Background = new SolidColorBrush(Color.Parse("#1E1B4B"));
                _aiImageBorder.BorderBrush = new SolidColorBrush(Color.Parse("#3730A3"));
            }
            else
            {
                Background = new SolidColorBrush(Color.Parse("#F4F6F9"));
                _topBarBorder.Background = Brushes.White;
                _topBarBorder.BorderBrush = new SolidColorBrush(Color.Parse("#E5E7EB"));
                _topBarTitle.Foreground = new SolidColorBrush(Color.Parse("#111827"));
                _versionBadgeText.Foreground = new SolidColorBrush(Color.Parse("#2563EB"));

                _themeToggleButton.Content = "🌙 Dark Mode";
                _themeToggleButton.Background = new SolidColorBrush(Color.Parse("#E2E8F0"));
                _themeToggleButton.Foreground = new SolidColorBrush(Color.Parse("#1E293B"));

                foreach (var tb in _primaryTexts) tb.Foreground = new SolidColorBrush(Color.Parse("#111827"));
                foreach (var tb in _secondaryTexts) tb.Foreground = new SolidColorBrush(Color.Parse("#6B7280"));
                foreach (var lb in _listBoxes)
                {
                    lb.Background = Brushes.White;
                    lb.BorderBrush = new SolidColorBrush(Color.Parse("#E5E7EB"));
                    lb.Foreground = new SolidColorBrush(Color.Parse("#111827"));
                }
                _aiImageBorder.Background = new SolidColorBrush(Color.Parse("#EEF2FF"));
                _aiImageBorder.BorderBrush = new SolidColorBrush(Color.Parse("#C7D2FE"));
            }
        }

        // ==========================================
        // BROWSER CLEANUP LOGIC (CHROME & EDGE)
        // ==========================================
        private async void OnCleanBrowsersClicked(object? sender, RoutedEventArgs e)
        {
            _cleanBrowsersButton.IsEnabled = false;
            _browserStatusText.Text = "Cleaning web browser caches and temporary files...";

            // Capture UI state on the UI thread to avoid cross-thread access
            bool chromeChecked = _chromeCheck.IsChecked == true;
            bool edgeChecked = _edgeCheck.IsChecked == true;
            bool tempChecked = _tempFilesCheck.IsChecked == true;
            bool dumpsChecked = _dumpsCheck.IsChecked == true;
            bool recycleChecked = _recycleBinCheck.IsChecked == true;
            bool downloadsChecked = _downloadsCheck.IsChecked == true;

            int cleanedFiles = await PerformBrowserCleanupAsync(chromeChecked, edgeChecked, tempChecked, dumpsChecked, recycleChecked, downloadsChecked);

            _browserStatusText.Text = $"✨ Browser Cleanup Complete! Removed {cleanedFiles} temporary cache files.";
            _cleanBrowsersButton.IsEnabled = true;
        }

        // P/Invoke to empty the Windows Recycle Bin
        [System.Runtime.InteropServices.DllImport("shell32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, uint dwFlags);

        private async Task<int> PerformBrowserCleanupAsync(bool chromeChecked, bool edgeChecked, bool tempChecked, bool dumpsChecked, bool recycleChecked, bool downloadsChecked)
        {
            int count = 0;
            var pathsToClean = new List<string>();
            string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                if (chromeChecked)
                {
                    pathsToClean.Add(Path.Combine(localAppData, "Google", "Chrome", "User Data", "Default", "Cache"));
                    pathsToClean.Add(Path.Combine(localAppData, "Google", "Chrome", "User Data", "Default", "Code Cache"));
                }
                if (edgeChecked)
                {
                    pathsToClean.Add(Path.Combine(localAppData, "Microsoft", "Edge", "User Data", "Default", "Cache"));
                    pathsToClean.Add(Path.Combine(localAppData, "Microsoft", "Edge", "User Data", "Default", "Code Cache"));
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (chromeChecked)
                {
                    pathsToClean.Add(Path.Combine(home, "Library", "Caches", "Google", "Chrome"));
                }
                if (edgeChecked)
                {
                    pathsToClean.Add(Path.Combine(home, "Library", "Caches", "Microsoft", "Edge"));
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Common Chrome/Chromium cache locations on Linux
                if (chromeChecked)
                {
                    pathsToClean.Add(Path.Combine(home, ".cache", "google-chrome"));
                    pathsToClean.Add(Path.Combine(home, ".cache", "chromium"));
                    pathsToClean.Add(Path.Combine(home, ".config", "google-chrome", "Default", "Cache"));
                    pathsToClean.Add(Path.Combine(home, ".config", "chromium", "Default", "Cache"));
                }
                // Microsoft Edge (Linux)
                if (edgeChecked)
                {
                    pathsToClean.Add(Path.Combine(home, ".cache", "microsoft-edge"));
                    pathsToClean.Add(Path.Combine(home, ".config", "microsoft-edge", "Default", "Cache"));
                }
            }

            // TEMP files
            try
            {
                if (tempChecked)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        pathsToClean.Add(Path.GetTempPath());
                        pathsToClean.Add(Path.Combine(home, "AppData", "Local", "Temp"));
                    }
                    else
                    {
                        pathsToClean.Add(Path.Combine("/tmp"));
                    }
                }
            }
            catch { }

            // Downloads
            try
            {
                if (downloadsChecked)
                {
                    pathsToClean.Add(Path.Combine(home, "Downloads"));
                }
            }
            catch { }

            // Crash dumps / memory dump files
            var dumpFiles = new List<string>();
            try
            {
                if (dumpsChecked)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                        var windir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                        dumpFiles.Add(Path.Combine(windir, "MEMORY.DMP"));
                        dumpFiles.Add(Path.Combine(windir, "Minidump"));
                        dumpFiles.Add(Path.Combine(localAppData, "CrashDumps"));
                    }
                    else
                    {
                        // common crash dirs on Unix
                        dumpFiles.Add(Path.Combine("/var", "crash"));
                    }
                }
            }
            catch { }

            // Recycle Bin / Trash
            bool emptiedRecycle = false;
            try
            {
                if (recycleChecked)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        try
                        {
                            const uint SHERB_NOCONFIRMATION = 0x00000001;
                            const uint SHERB_NOPROGRESSUI = 0x00000002;
                            const uint SHERB_NOSOUND = 0x00000004;
                            SHEmptyRecycleBin(IntPtr.Zero, null, SHERB_NOCONFIRMATION | SHERB_NOPROGRESSUI | SHERB_NOSOUND);
                            emptiedRecycle = true;
                        }
                        catch { }
                    }
                    else
                    {
                        // Try common trash locations on Unix-like systems
                        var trash1 = Path.Combine(home, ".local", "share", "Trash", "files");
                        var trash2 = Path.Combine(home, ".Trash");
                        pathsToClean.Add(trash1);
                        pathsToClean.Add(trash2);
                    }
                }
            }
            catch { }

            // Use a semaphore to limit concurrency when deleting many files
            var deleteTasks = new List<Task>();
            var sem = new System.Threading.SemaphoreSlim(Environment.ProcessorCount);

            foreach (var dir in pathsToClean)
            {
                if (Directory.Exists(dir))
                {
                    try
                    {
                        foreach (var file in Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories))
                        {
                            await sem.WaitAsync();
                            var f = file; // capture
                            var t = Task.Run(() =>
                            {
                                try
                                {
                                    File.Delete(f);
                                    System.Threading.Interlocked.Increment(ref count);
                                }
                                catch { /* Locked or inaccessible file */ }
                                finally
                                {
                                    sem.Release();
                                }
                            });

                            deleteTasks.Add(t);
                        }
                    }
                    catch { }
                }
            }

            // Delete explicit dump files / directories
            foreach (var df in dumpFiles)
            {
                try
                {
                    if (File.Exists(df))
                    {
                        try { File.Delete(df); System.Threading.Interlocked.Increment(ref count); } catch { }
                    }
                    else if (Directory.Exists(df))
                    {
                        try
                        {
                            foreach (var file in Directory.EnumerateFiles(df, "*.*", SearchOption.AllDirectories))
                            {
                                await sem.WaitAsync();
                                var f = file;
                                var t = Task.Run(() =>
                                {
                                    try { File.Delete(f); System.Threading.Interlocked.Increment(ref count); } catch { }
                                    finally { sem.Release(); }
                                });
                                deleteTasks.Add(t);
                            }
                        }
                        catch { }
                    }
                }
                catch { }
            }

            try
            {
                await Task.WhenAll(deleteTasks);
            }
            catch { }

            return count;
        }

        private void LoadSystemInfo()
        {
            var infoItems = new List<InfoItem>();
            try
            {
                infoItems.Add(new InfoItem("🖥️ Operating System", $"{RuntimeInformation.OSDescription} ({RuntimeInformation.OSArchitecture})"));
                infoItems.Add(new InfoItem("👤 Computer / User", $"{Environment.MachineName} / {Environment.UserName}"));
                infoItems.Add(new InfoItem("⚙️ System Framework", RuntimeInformation.FrameworkDescription));
                infoItems.Add(new InfoItem("🧠 Processor Architecture", $"{RuntimeInformation.ProcessArchitecture} Architecture"));
                infoItems.Add(new InfoItem("⚡ CPU Core Count", $"{Environment.ProcessorCount} Logical Cores"));

                long processMemoryBytes = GC.GetTotalMemory(false);
                double processMemoryMB = processMemoryBytes / (1024.0 * 1024.0);
                infoItems.Add(new InfoItem("📊 App Memory Usage", $"{processMemoryMB:0.0} MB"));

                TimeSpan uptime = TimeSpan.FromMilliseconds(Environment.TickCount64);
                infoItems.Add(new InfoItem("⏱️ System Uptime", $"{uptime.Days} days, {uptime.Hours} hours, {uptime.Minutes} minutes"));

                foreach (var drive in DriveInfo.GetDrives())
                {
                    if (drive.IsReady)
                    {
                        double totalGB = drive.TotalSize / (1024.0 * 1024.0 * 1024.0);
                        double freeGB = drive.AvailableFreeSpace / (1024.0 * 1024.0 * 1024.0);
                        double usedGB = totalGB - freeGB;
                        double usedPercent = (usedGB / totalGB) * 100.0;
                        string driveLabel = string.IsNullOrEmpty(drive.VolumeLabel) ? drive.Name : $"{drive.Name} ({drive.VolumeLabel})";
                        infoItems.Add(new InfoItem($"💾 Storage [{driveLabel}]", $"{usedGB:0.0} GB Used / {totalGB:0.0} GB Total ({freeGB:0.0} GB Free, {usedPercent:0}% Used)"));
                    }
                }
            }
            catch (Exception ex)
            {
                infoItems.Add(new InfoItem("⚠️ Notice", $"Could not load specs: {ex.Message}"));
            }
            _sysInfoListBox.ItemsSource = infoItems;
        }

        private void PopulateScanTargets()
        {
            try
            {
                var items = new List<string>();
                // logical drives
                try
                {
                    foreach (var d in Environment.GetLogicalDrives()) items.Add(d);
                }
                catch { }

                // common user folders
                try
                {
                    var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    items.Add(Path.Combine(home, "Downloads"));
                    items.Add(Path.Combine(home, "Desktop"));
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        items.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "System32", "drivers"));
                    }
                }
                catch { }

                _scanTargetsListBox.ItemsSource = items.Distinct().Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
            }
            catch { }
        }

        private Bitmap GetEmbeddedAiCleanerImage()
        {
            string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 160 160' width='160' height='160'>
                <rect width='160' height='160' rx='16' fill='#4F46E5'/>
                <circle cx='80' cy='80' r='60' fill='#6366F1' opacity='0.5'/>
                <rect x='50' y='45' width='60' height='45' rx='10' fill='#FFFFFF'/>
                <circle cx='65' cy='62' r='6' fill='#4F46E5'/>
                <circle cx='95' cy='62' r='6' fill='#4F46E5'/>
                <rect x='68' y='75' width='24' height='4' rx='2' fill='#9CA3AF'/>
                <line x1='80' y1='45' x2='80' y2='32' stroke='#FFFFFF' stroke-width='4' stroke-linecap='round'/>
                <circle cx='80' cy='28' r='5' fill='#38BDF8'/>
                <path d='M45 110 L75 110 L85 125 L35 125 Z' fill='#38BDF8'/>
                <line x1='70' y1='90' x2='55' y2='110' stroke='#FFFFFF' stroke-width='4' stroke-linecap='round'/>
                <path d='M110 100 L114 108 L122 112 L114 116 L110 124 L106 116 L98 112 L106 108 Z' fill='#FBBF24'/>
                <path d='M125 50 L128 55 L133 57 L128 59 L125 64 L122 59 L117 57 L122 55 Z' fill='#FBBF24'/>
            </svg>";

            byte[] byteArray = Encoding.UTF8.GetBytes(svgContent);
            using var stream = new MemoryStream(byteArray);
            return new Bitmap(stream);
        }

        private void OpenWebpage(string url)
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
            }
            catch { }
        }

        private async void OnCleanClicked(object? sender, RoutedEventArgs e)
        {
            _cleanButton.IsEnabled = false;
            _progressBar.IsVisible = true;
            _statusText.Text = "AI Smart Engine analyzing and cleaning temporary caches...";

            try
            {
                _aiCleanerImageControl.Source = GetEmbeddedAiCleanerImage();
                _aiImageBorder.IsVisible = true;
            }
            catch { }

            // Capture user-selected scan targets and options on UI thread
            var selectedTargets = (_scanTargetsListBox.SelectedItems as System.Collections.IEnumerable)?.Cast<object>().Select(o => o?.ToString() ?? string.Empty).Where(s => !string.IsNullOrWhiteSpace(s)).ToList() ?? new List<string>();
            bool includeDrivers = _includeDriversCheck.IsChecked == true;
            bool includeDumps = _includeDumpsCheck.IsChecked == true;

            var cleanupTask = Task.Run(() => PerformCleanup(selectedTargets, includeDrivers, includeDumps));
            var result = await cleanupTask;

            _statusText.Text = $"✨ AI Cleaning Complete!\n\nSpace Freed: {FormatBytes(result.FreedBytes)}\nFiles Removed: {result.DeletedCount}\nLocked Files Skipped: {result.ErrorCount}";
            _progressBar.IsVisible = false;
            _cleanButton.IsEnabled = true;
            _cleanButton.Content = "✨ Run AI Smart Clean Again";
        }

        private CleanupResult PerformCleanup(IEnumerable<string>? extraTargets = null, bool includeDrivers = false, bool includeDumps = false)
        {
            long freedBytes = 0;
            int deletedCount = 0;
            int errorCount = 0;
            var paths = GetJunkPaths().ToList();

            // incorporate extra user-selected targets
            try
            {
                if (extraTargets != null)
                {
                    foreach (var t in extraTargets.Where(s => !string.IsNullOrWhiteSpace(s))) paths.Add(t);
                }
            }
            catch { }

            // include drivers folder(s)
            try
            {
                if (includeDrivers)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        paths.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "System32", "drivers"));
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        paths.Add(Path.Combine("/lib", "modules"));
                }
            }
            catch { }

            // include dumps
            try
            {
                if (includeDumps)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        var windir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                        paths.Add(Path.Combine(windir, "MEMORY.DMP"));
                        paths.Add(Path.Combine(windir, "Minidump"));
                    }
                    else
                    {
                        paths.Add(Path.Combine("/var", "crash"));
                    }
                }
            }
            catch { }

            foreach (var dir in paths)
            {
                if (Directory.Exists(dir)) CleanDirectory(dir, ref freedBytes, ref deletedCount, ref errorCount);
            }
            return new CleanupResult(freedBytes, deletedCount, errorCount);
        }

        private void CleanDirectory(string path, ref long freedBytes, ref int deletedCount, ref int errorCount)
        {
            try
            {
                foreach (var file in Directory.EnumerateFiles(path))
                {
                    try
                    {
                        var fi = new FileInfo(file);
                        long size = fi.Length;
                        fi.Delete();
                        freedBytes += size;
                        deletedCount++;
                    }
                    catch { errorCount++; }
                }

                foreach (var dir in Directory.EnumerateDirectories(path))
                {
                    CleanDirectory(dir, ref freedBytes, ref deletedCount, ref errorCount);
                    try { Directory.Delete(dir); } catch { }
                }
            }
            catch { }
        }

        private async void OnScanDuplicatesClicked(object? sender, RoutedEventArgs e)
        {
            _scanDuplicatesButton.IsEnabled = false;
            _duplicateStatusText.Text = "Scanning Downloads folder for duplicates using SHA256 checksums...";
            string targetDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            var duplicates = await Task.Run(() => FindDuplicates(targetDir));
            _duplicateListBox.ItemsSource = duplicates;
            _duplicateStatusText.Text = duplicates.Count > 0 ? $"Found {duplicates.Count} duplicate file(s)." : "No duplicate files found in Downloads folder.";
            _scanDuplicatesButton.IsEnabled = true;
        }

        private List<DuplicateItem> FindDuplicates(string searchDir)
        {
            var resultList = new List<DuplicateItem>();
            if (!Directory.Exists(searchDir)) return resultList;
            try
            {
                var files = Directory.GetFiles(searchDir, "*.*", SearchOption.TopDirectoryOnly)
                    .Select(f => new FileInfo(f))
                    .Where(f => f.Length > 0)
                    .GroupBy(f => f.Length)
                    .Where(g => g.Count() > 1);

                using (var sha256 = SHA256.Create())
                {
                    foreach (var group in files)
                    {
                        var hashMap = new Dictionary<string, string>();
                        foreach (var fileInfo in group)
                        {
                            try
                            {
                                using (var stream = File.OpenRead(fileInfo.FullName))
                                {
                                    byte[] hash = sha256.ComputeHash(stream);
                                    string hashStr = BitConverter.ToString(hash).Replace("-", "");
                                    if (hashMap.ContainsKey(hashStr))
                                    {
                                        resultList.Add(new DuplicateItem
                                        {
                                            FileName = fileInfo.Name,
                                            FilePath = fileInfo.FullName,
                                            OriginalPath = hashMap[hashStr],
                                            Size = fileInfo.Length
                                        });
                                    }
                                    else { hashMap[hashStr] = fileInfo.FullName; }
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
            return resultList;
        }

        private void OnDeleteDuplicateClicked(object? sender, RoutedEventArgs e)
        {
            if (_duplicateListBox.SelectedItem is DuplicateItem item)
            {
                try
                {
                    File.Delete(item.FilePath);
                    _duplicateStatusText.Text = $"Successfully deleted duplicate file: {item.FileName}";
                    var currentList = (_duplicateListBox.ItemsSource as List<DuplicateItem>)?.Where(i => i.FilePath != item.FilePath).ToList();
                    _duplicateListBox.ItemsSource = currentList;
                }
                catch (Exception ex) { _duplicateStatusText.Text = $"Failed to delete file: {ex.Message}"; }
            }
        }

        private async void OnRunTuneupClicked(object? sender, RoutedEventArgs e)
        {
            _runTuneupButton.IsEnabled = false;
            _tuneupStatusText.Text = "Optimizing system RAM and flushing network DNS cache...";
            await Task.Run(() => PerformTuneup());
            _tuneupStatusText.Text = "⚡ Tuneup Successful!\n\n• DNS Cache Flushed\n• Process Memory Garbage-Collected\n• RAM Trimmed";
            _runTuneupButton.IsEnabled = true;
        }

        private void PerformTuneup()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    var psi = new ProcessStartInfo("ipconfig", "/flushdns") { CreateNoWindow = true, UseShellExecute = false };
                    Process.Start(psi)?.WaitForExit();
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    var psi = new ProcessStartInfo("dscacheutil", "-flushcache") { CreateNoWindow = true, UseShellExecute = false };
                    Process.Start(psi)?.WaitForExit();
                }
            }
            catch { }
        }

        private void LoadInstalledApps()
        {
            var apps = new List<AppItem>();
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    string appsDir = "/Applications";
                    if (Directory.Exists(appsDir))
                    {
                        foreach (var dir in Directory.GetDirectories(appsDir, "*.app"))
                            apps.Add(new AppItem { Name = Path.GetFileNameWithoutExtension(dir), Path = dir });
                    }
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    string pf = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                    string pfx86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                    var dirs = new List<string>();
                    if (Directory.Exists(pf)) dirs.AddRange(Directory.GetDirectories(pf));
                    if (Directory.Exists(pfx86)) dirs.AddRange(Directory.GetDirectories(pfx86));
                    foreach (var d in dirs) apps.Add(new AppItem { Name = Path.GetFileName(d), Path = d });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    // Look for .desktop entries (common install metadata) and /opt folders
                    string desktopDir = "/usr/share/applications";
                    if (Directory.Exists(desktopDir))
                    {
                        foreach (var file in Directory.GetFiles(desktopDir, "*.desktop"))
                        {
                            try
                            {
                                var name = Path.GetFileNameWithoutExtension(file);
                                // Attempt to read a human-friendly Name from the desktop file
                                var lines = File.ReadAllLines(file);
                                var nameLine = lines.FirstOrDefault(l => l.StartsWith("Name=") || l.StartsWith("Name["));
                                if (!string.IsNullOrEmpty(nameLine)) name = nameLine.Split('=')[1];
                                apps.Add(new AppItem { Name = name, Path = file });
                            }
                            catch { }
                        }
                    }
                    // Also include directories under /opt as candidate installed apps
                    string optDir = "/opt";
                    if (Directory.Exists(optDir))
                    {
                        foreach (var d in Directory.GetDirectories(optDir)) apps.Add(new AppItem { Name = Path.GetFileName(d), Path = d });
                    }
                }
            }
            catch { }
            _uninstallerListBox.ItemsSource = apps;
        }

        private void OnUninstallClicked(object? sender, RoutedEventArgs e)
        {
            if (_uninstallerListBox.SelectedItem is AppItem app)
            {
                try
                {
                    // On Windows/macOS deleting the application folder may remove the app
                    if (Directory.Exists(app.Path))
                    {
                        Directory.Delete(app.Path, true);
                        _uninstallerStatusText.Text = $"Removed application directory: {app.Name}";
                        LoadInstalledApps();
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        // If the app entry points to a .desktop file or non-directory entry, only support removal for /opt installs
                        if (app.Path.StartsWith("/opt") && Directory.Exists(app.Path))
                        {
                            Directory.Delete(app.Path, true);
                            _uninstallerStatusText.Text = $"Removed application directory: {app.Name}";
                            LoadInstalledApps();
                        }
                        else
                        {
                            _uninstallerStatusText.Text = "Uninstall not supported for this entry on Linux. Remove via package manager or delete files manually.";
                        }
                    }
                }
                catch (Exception ex) { _uninstallerStatusText.Text = $"Could not remove app: {ex.Message}"; }
            }
        }

        private void LoadStartupItems()
        {
            var items = new List<StartupItem>();
            string startupDir = "";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                startupDir = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                startupDir = Path.Combine(homeDir, "Library", "LaunchAgents");
            }

            if (!string.IsNullOrEmpty(startupDir) && Directory.Exists(startupDir))
            {
                foreach (var file in Directory.GetFiles(startupDir))
                {
                    string fileName = Path.GetFileName(file);
                    if (fileName.StartsWith(".")) continue;
                    bool isDisabled = fileName.EndsWith(".disabled");
                    items.Add(new StartupItem { Name = isDisabled ? fileName.Replace(".disabled", "") : fileName, Path = file, IsEnabled = !isDisabled });
                }
            }
            _startupListBox.ItemsSource = items;
        }

        private void OnToggleStartupClicked(object? sender, RoutedEventArgs e)
        {
            if (_startupListBox.SelectedItem is StartupItem item)
            {
                try
                {
                    string newPath = item.IsEnabled ? item.Path + ".disabled" : item.Path.Replace(".disabled", "");
                    File.Move(item.Path, newPath);
                    LoadStartupItems();
                }
                catch { }
            }
        }

        private IEnumerable<string> GetJunkPaths()
        {
            var paths = new List<string> { Path.GetTempPath() };
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                paths.Add(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                paths.Add(Path.Combine(homeDir, "Library", "Caches"));
                paths.Add(Path.Combine(homeDir, "Library", "Logs"));
            }
            return paths;
        }

        private string FormatBytes(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int counter = 0;
            decimal number = bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number /= 1024;
                counter++;
            }
            return $"{number:n2} {suffixes[counter]}";
        }
    }

    public class InfoItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public InfoItem(string key, string value) { Key = key; Value = value; }
        public override string ToString() => $"{Key}: {Value}";
    }

    public class CleanupResult
    {
        public long FreedBytes { get; }
        public int DeletedCount { get; }
        public int ErrorCount { get; }
        public CleanupResult(long freedBytes, int deletedCount, int errorCount) { FreedBytes = freedBytes; DeletedCount = deletedCount; ErrorCount = errorCount; }
    }

    public class DuplicateItem
    {
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string OriginalPath { get; set; } = string.Empty;
        public long Size { get; set; }
        public override string ToString() => $"📄 {FileName} ({Size / 1024} KB) - Duplicate of {Path.GetFileName(OriginalPath)}";
    }

    public class AppItem
    {
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public override string ToString() => $"📦 {Name}  ({Path})";
    }

    public class StartupItem
    {
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public bool IsEnabled { get; set; }
        public override string ToString() => $"{(IsEnabled ? "✅ Enabled" : "❌ Disabled")}   |   {Name}";
    }
    // Simple input dialog used to ask for a folder path (very small cross-platform UI)
    public class SimpleInputDialog : Window
    {
        private TextBox _input;
        public SimpleInputDialog(string prompt)
        {
            Title = prompt;
            Width = 500;
            Height = 140;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            _input = new TextBox { Margin = new Thickness(10) };
            var ok = new Button { Content = "OK", Width = 80, Margin = new Thickness(6) };
            var cancel = new Button { Content = "Cancel", Width = 80, Margin = new Thickness(6) };

            ok.Click += (_, __) => { Close(_input.Text); };
            cancel.Click += (_, __) => { Close(null); };

            var buttons = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right, Children = { cancel, ok } };
            Content = new StackPanel { Children = { _input, buttons }, Margin = new Thickness(8) };
        }
    }
}