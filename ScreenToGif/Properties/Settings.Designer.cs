﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScreenToGif.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("500, 400")]
        public global::System.Drawing.Size Setting_gif_area_size {
            get {
                return ((global::System.Drawing.Size)(this["Setting_gif_area_size"]));
            }
            set {
                this["Setting_gif_area_size"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("500, 400")]
        public global::System.Drawing.Point Setting_gif_area_location {
            get {
                return ((global::System.Drawing.Point)(this["Setting_gif_area_location"]));
            }
            set {
                this["Setting_gif_area_location"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int Setting_gif_fps {
            get {
                return ((int)(this["Setting_gif_fps"]));
            }
            set {
                this["Setting_gif_fps"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool Setting_is_full_screen {
            get {
                return ((bool)(this["Setting_is_full_screen"]));
            }
            set {
                this["Setting_is_full_screen"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool Setting_is_catch_mouse {
            get {
                return ((bool)(this["Setting_is_catch_mouse"]));
            }
            set {
                this["Setting_is_catch_mouse"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("600, 500")]
        public global::System.Drawing.Size Setting_form_size {
            get {
                return ((global::System.Drawing.Size)(this["Setting_form_size"]));
            }
            set {
                this["Setting_form_size"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("500, 400")]
        public global::System.Drawing.Point Setting_form_location {
            get {
                return ((global::System.Drawing.Point)(this["Setting_form_location"]));
            }
            set {
                this["Setting_form_location"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int Setting_form_encode_mode {
            get {
                return ((int)(this["Setting_form_encode_mode"]));
            }
            set {
                this["Setting_form_encode_mode"] = value;
            }
        }
    }
}
