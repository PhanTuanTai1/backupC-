﻿#pragma checksum "C:\Users\nguye\Desktop\New folder (5)\backupC\24102019_uwp\Views\Dialogs\PayLateChargeDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AD61297F7CDF42EF984B99276BA25E6F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _24102019_uwp.Views.Dialogs
{
    partial class PayLateChargeDialog : 
        global::Windows.UI.Xaml.Controls.ContentDialog, 
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
            case 1: // Views\Dialogs\PayLateChargeDialog.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).PrimaryButtonClick += this.ContentDialog_PrimaryButtonClick;
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).SecondaryButtonClick += this.ContentDialog_SecondaryButtonClick;
                }
                break;
            case 2: // Views\Dialogs\PayLateChargeDialog.xaml line 16
                {
                    this.inputMoney = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.inputMoney).TextChanged += this.TextBox_TextChanged;
                }
                break;
            case 3: // Views\Dialogs\PayLateChargeDialog.xaml line 17
                {
                    this.txtReturn = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

