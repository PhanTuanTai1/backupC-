﻿#pragma checksum "C:\Users\VB Yoshara\Desktop\backupC-new\backupC-new\24102019_uwp\Views\LateChargePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1C15DADB722FDE413675C2BA296E5B06"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _24102019_uwp.Views
{
    partial class LateChargePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\LateChargePage.xaml line 13
                {
                    this.btnAddToDo = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.btnAddToDo).Click += this.BtnAddToDo_Click;
                }
                break;
            case 3: // Views\LateChargePage.xaml line 24
                {
                    this.autobox = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.autobox).TextChanged += this.Autobox_TextChanged;
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.autobox).SuggestionChosen += this.Autobox_SuggestionChosen;
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.autobox).QuerySubmitted += this.Autobox_QuerySubmitted;
                }
                break;
            case 4: // Views\LateChargePage.xaml line 39
                {
                    this.lvLateCharges = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 5: // Views\LateChargePage.xaml line 116
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Payment_Click;
                }
                break;
            case 6: // Views\LateChargePage.xaml line 120
                {
                    this.txtTotal = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

