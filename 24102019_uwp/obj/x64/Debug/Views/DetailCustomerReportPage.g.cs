﻿#pragma checksum "C:\Users\VB Yoshara\Desktop\backupC-new\backupC-new\24102019_uwp\Views\DetailCustomerReportPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0576C29FBF51CE447BD3C2641A144399"
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
    partial class DetailCustomerReportPage : 
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
            case 2: // Views\DetailCustomerReportPage.xaml line 15
                {
                    this.btnAddToDo = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.btnAddToDo).Click += this.BtnAddToDo_Click;
                }
                break;
            case 3: // Views\DetailCustomerReportPage.xaml line 28
                {
                    this.Name = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // Views\DetailCustomerReportPage.xaml line 36
                {
                    this.Phone = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // Views\DetailCustomerReportPage.xaml line 44
                {
                    this.Address = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Views\DetailCustomerReportPage.xaml line 52
                {
                    this.TotalDiskOut = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Views\DetailCustomerReportPage.xaml line 60
                {
                    this.TotalPrice = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // Views\DetailCustomerReportPage.xaml line 67
                {
                    this.lvDisk = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 9: // Views\DetailCustomerReportPage.xaml line 115
                {
                    this.lvAllDiskOverDue = (global::Windows.UI.Xaml.Controls.ListView)(target);
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

