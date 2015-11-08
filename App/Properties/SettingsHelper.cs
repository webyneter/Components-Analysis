using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Infralution.Localization;


namespace Webyneter.ComponentsAnalysis.App.Properties
{
    internal static class SettingsHelper
    {
        private static bool wasInitialized;

        public static bool Initialize()
        {
            if (wasInitialized)
            {
                return false;
            }
            var startPathSep = Application.StartupPath + Path.DirectorySeparatorChar;
            Settings.Default.ProjectFilesDir = startPathSep + Settings.Default.ProjectFilesDirNameDefault;
            Settings.Default.InputFilesDir = startPathSep + Settings.Default.InputFilesDirNameDefault;
            Settings.Default.OutputFilesDir = startPathSep + Settings.Default.OutputFilesDirNameDefault;
            CultureManager.ApplicationUICulture = Settings.Default.AppCurrentCulture;
            CultureManager.ApplicationUICultureChanged += ci => Settings.Default.AppCurrentCulture = ci;
            wasInitialized = true;
            return true;
        }

        public static string ProjectsDirDefault(this Settings settings)
        {
            return Path.Combine(Application.StartupPath, Settings.Default.ProjectFilesDirNameDefault);
        }

        public static string InputFilesDirDefault(this Settings settings)
        {
            return Path.Combine(Application.StartupPath, Settings.Default.InputFilesDirNameDefault);
        }

        public static string OutputFilesDirDefault(this Settings settings)
        {
            return Path.Combine(Application.StartupPath, Settings.Default.OutputFilesDirNameDefault);
        }

        public static void CloneUserScopedSettingsTo<TSettings>(this TSettings newSettings, TSettings originalSettings)
            where TSettings : ApplicationSettingsBase
        {
            if (originalSettings == null)
            {
                throw new ArgumentNullException("originalSettings");
            }
            PropertyInfo[] propsInfo = typeof(TSettings).GetProperties(BindingFlags.Instance
                | BindingFlags.Public
                | BindingFlags.SetProperty);
            foreach (var propInfo in propsInfo)
            {
                propInfo.SetValue(originalSettings, propInfo.GetValue(newSettings, null), null);
            }
        }
    }
}
