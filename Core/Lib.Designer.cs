﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webyneter.ComponentsAnalysis.Core {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Lib {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Lib() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Webyneter.ComponentsAnalysis.Core.Lib", typeof(Lib).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified file is expected to be an Excel file.
        /// </summary>
        internal static string ExcelFileExpected {
            get {
                return ResourceManager.GetString("ExcelFileExpected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Excel worksheet with specified name does not exist.
        /// </summary>
        internal static string ExcelWorksheetDoesNotExist {
            get {
                return ResourceManager.GetString("ExcelWorksheetDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified file is not a valid project file.
        /// </summary>
        internal static string InvalidProjectFile {
            get {
                return ResourceManager.GetString("InvalidProjectFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No input data to analyze.
        /// </summary>
        internal static string NoInputDataToAnalyze {
            get {
                return ResourceManager.GetString("NoInputDataToAnalyze", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified file is expected to be an XML file.
        /// </summary>
        internal static string XmlFileExpected {
            get {
                return ResourceManager.GetString("XmlFileExpected", resourceCulture);
            }
        }
    }
}
