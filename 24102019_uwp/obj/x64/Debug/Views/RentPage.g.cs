﻿#pragma checksum "C:\Users\nguye\Desktop\backupC-\24102019_uwp\Views\RentPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2DDF6159D3ED47DE2E742D755123785F"
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
    partial class RentPage : 
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
            case 2: // Views\RentPage.xaml line 13
                {
                    this.uID = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // Views\RentPage.xaml line 20
                {
                    this.autobox = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.autobox).TextChanged += this.Autobox_TextChanged;
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.autobox).SuggestionChosen += this.Autobox_SuggestionChosen;
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.autobox).QuerySubmitted += this.Autobox_QuerySubmitted;
                }
                break;
            case 4: // Views\RentPage.xaml line 38
                {
                    this.productFind = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.productFind).TextChanged += this.AutoSuggestBox_TextChanged;
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.productFind).SuggestionChosen += this.AutoSuggestBox_SuggestionChosen;
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.productFind).QuerySubmitted += this.AutoSuggestBox_QuerySubmitted;
                }
                break;
            case 5: // Views\RentPage.xaml line 60
                {
                    this.lvFruits = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 6: // Views\RentPage.xaml line 78
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.Payment_Click;
                }
                break;
            case 7: // Views\RentPage.xaml line 82
                {
                    this.totalMoney = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // Views\RentPage.xaml line 53
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element9 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element9).Tapped += this.AppBarButton_Tapped;
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

