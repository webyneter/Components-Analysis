using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;


namespace Webyneter.ComponentsAnalysis.Miscellaneous
{
    public static class Utilities
    {
        /// <summary>
        /// Contains all existing application cultures. Being updated on every single enumeration. 
        /// Use to avoid creating multiple instances of the same culture.
        /// </summary>
        public static IEnumerable<CultureInfo> SupportedAppDomainCultures
        {
            get
            {
                if (supportedCultures == null)
                {
                    supportedCultures = EnumerateAppDomainCultures();
                }
                return supportedCultures;
            }
        }
        private static IEnumerable<CultureInfo> supportedCultures;
        #region http://stackoverflow.com/questions/5112828/loop-through-embedded-resources-of-different-languages-cultures-in-c-sharp
        
        /// <summary>
        /// Enumerate cultures.
        /// </summary>
        /// <returns>Enumeration of cultures.</returns>
        private static IEnumerable<CultureInfo> EnumerateAppDomainCultures()
        {
            var baseDirs = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory);
            var cultures = new List<CultureInfo>(baseDirs.Length);
            foreach (var dir in baseDirs)
            {
                string dirName = Path.GetFileNameWithoutExtension(dir);
                if (dirName.Length < 2
                    || dirName.Length > 2 && dirName[2] != '-')
                {
                    continue;
                }

                CultureInfo culture;
                try
                {
                    culture = CultureInfo.GetCultureInfo(dirName);
                }
                catch
                {
                    continue;
                }
                cultures.Add(culture);
                
                string resName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location)
                                 + ".resources.dll";
                if (File.Exists(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dirName), resName)))
                {
                    yield return culture;
                }
            }
            supportedCultures = cultures;
        }

        /// <summary>
        /// Enumerate cultures.
        /// </summary>
        /// <param name="baseName">Basename.</param>
        /// <returns>Enumeration of cultures.</returns>
        //public static IEnumerable<CultureInfo> EnumerateAppDomainCultures(string baseName)
        //{
        //    if (baseName == null)
        //    {
        //        throw new ArgumentNullException("baseName");   
        //    }

        //    var rm = new ResourceManager(baseName, Assembly.GetExecutingAssembly());
        //    if (rm.GetResourceSet(CultureInfo.InvariantCulture, true, false) != null)
        //    {
        //        yield return CultureInfo.InvariantCulture;     
        //    }
        //    foreach (var ci in EnumerateAppDomainCultures())
        //    {
        //        if (rm.GetResourceSet(ci, true, false) != null)
        //        {
        //            yield return ci;
        //        }
        //    }
        //}
        #endregion
    }
}
