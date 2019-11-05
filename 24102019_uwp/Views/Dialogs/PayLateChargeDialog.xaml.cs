using _24102019_uwp.Business;
using _24102019_uwp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _24102019_uwp.Views.Dialogs
{
    public sealed partial class PayLateChargeDialog : ContentDialog
    {
        List<DisplayPayLateCharge> displayPayLateCharges;
        decimal total;

        public PayLateChargeDialog(List<DisplayPayLateCharge> displayPayLateCharges)
        {
            this.InitializeComponent();
            this.displayPayLateCharges = displayPayLateCharges;

            total = displayPayLateCharges.Sum(p => p.lateCharge);

            Title = "Total owned money: " + total;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var MoneyText = inputMoney.Text;

            if (string.IsNullOrWhiteSpace(MoneyText))
            {
                return;
            }

            if (decimal.TryParse(MoneyText, out decimal a))
            {
                new PayLateChargeBS().PayLateCharge(a, displayPayLateCharges);
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var MoneyText = (sender as TextBox).Text;

            if (string.IsNullOrWhiteSpace(MoneyText))
            {
                txtReturn.Text = "Return money: ---";
                return;
            }


            if(decimal.TryParse(MoneyText, out decimal a)) {
                txtReturn.Text = "Return money: " + new PayLateChargeBS().CalcLateCharge(a, displayPayLateCharges);
            }
        }
    }
}
