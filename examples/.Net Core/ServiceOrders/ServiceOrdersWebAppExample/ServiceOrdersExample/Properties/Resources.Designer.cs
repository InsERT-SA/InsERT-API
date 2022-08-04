﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceOrdersExample.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ServiceOrdersExample.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Pole {0} nie jest poprawnym adresem e-mail..
        /// </summary>
        public static string EmailAddressAttribute {
            get {
                return ResourceManager.GetString("EmailAddressAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pole {0} nie jest poprawnym numerem NIP..
        /// </summary>
        public static string NIPAttribute {
            get {
                return ResourceManager.GetString("NIPAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pole {0} nie jest poprawnym numerem telefonu..
        /// </summary>
        public static string PhoneAttribute {
            get {
                return ResourceManager.GetString("PhoneAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pole {0} jest wymagane..
        /// </summary>
        public static string RequiredAttribute {
            get {
                return ResourceManager.GetString("RequiredAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zgłoszenie serwisowe nie może zostać wysłane bez wyrażenia zgody na przetwarzanie danych osobowych..
        /// </summary>
        public static string RequiredConsentMessage {
            get {
                return ResourceManager.GetString("RequiredConsentMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pole {0} jest wymagane..
        /// </summary>
        public static string RequiredIfAttribute {
            get {
                return ResourceManager.GetString("RequiredIfAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Oświadczam, że zapoznałam/-em się z poniższymi informacjami i wyrażam zgodę na przetwarzanie moich danych osobowych we wskazanych poniżej celach i zakresie:.
        /// </summary>
        public static string ServiceRegistrationClientConsent {
            get {
                return ResourceManager.GetString("ServiceRegistrationClientConsent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Informujemy, że administratorem Pani/Pana danych osobowych jest {0} z siedzibą: {1}. Podane przez Panią/Pana dane osobowe będą przetwarzane przez Administratora w celu świadczenia przez Administratora usług serwisowych. Podanie danych osobowych jest dobrowolne, jednak niezbędne do wykonywania w/w czynności. Pomimo dobrowolności, konsekwencją niepodania danych osobowych będzie brak możliwości wykonywania w/w czynności.
        ///
        ///W związku z udzieloną przez Panią/Pana zgodą, podstawą prawną przetwarzania podanych prze [rest of string was truncated]&quot;;.
        /// </summary>
        public static string ServiceRegistrationClientConsentMore {
            get {
                return ResourceManager.GetString("ServiceRegistrationClientConsentMore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pole {0} musi zawierać {1} znaków..
        /// </summary>
        public static string StringConstantLengthAttribute {
            get {
                return ResourceManager.GetString("StringConstantLengthAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Liczba znaków w polu {0} musi zawierać się w przedziale {2}-{1}..
        /// </summary>
        public static string StringMinAndMaxLengthAttribute {
            get {
                return ResourceManager.GetString("StringMinAndMaxLengthAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Maksymalna długość w polu {0} wynosi {1} znaków..
        /// </summary>
        public static string StringOnlyMaxLengthAttribute {
            get {
                return ResourceManager.GetString("StringOnlyMaxLengthAttribute", resourceCulture);
            }
        }
    }
}
