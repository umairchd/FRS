﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FRS.Implementation.Resources.EmployeeManagement {
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
    public class Designation {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Designation() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FRS.Implementation.Resources.EmployeeManagement.Designation", typeof(Designation).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Designation with same code already exists! Try different code!.
        /// </summary>
        public static string DesignationCodeDuplicationCheck {
            get {
                return ResourceManager.GetString("DesignationCodeDuplicationCheck", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Designation is associated with Employee Job Info !.
        /// </summary>
        public static string DesignationIsAssociatedWithEmpJobInfoError {
            get {
                return ResourceManager.GetString("DesignationIsAssociatedWithEmpJobInfoError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Designation is associated with Employee Job Progress !.
        /// </summary>
        public static string DesignationIsAssociatedWithEmpJobProgError {
            get {
                return ResourceManager.GetString("DesignationIsAssociatedWithEmpJobProgError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Designation with not found in database!.
        /// </summary>
        public static string DesignationNotFound {
            get {
                return ResourceManager.GetString("DesignationNotFound", resourceCulture);
            }
        }
    }
}
