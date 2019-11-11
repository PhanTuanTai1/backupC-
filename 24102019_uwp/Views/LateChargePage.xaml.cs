using _24102019_uwp.Business;
using _24102019_uwp.Models;
using _24102019_uwp.Views.Dialogs;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _24102019_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LateChargePage : Page
    {
        List<Customer> customers;
        Customer customer;
        List<DisplayPayLateCharge> displayPayLateCharges;

        public LateChargePage()
        {
            this.InitializeComponent();

            customers = new RentBS().GetCustomers();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter == null) return;

            var cusID = (int)e.Parameter;

            autobox.Text = cusID.ToString();

            customer = new Customer() { CusID = cusID };

            displayPayLateCharges = new PayLateChargeBS().GetDisplayPayLateChargesByCusID(cusID);

            lvLateCharges.ItemsSource = displayPayLateCharges;

            CalculateMoney();
        }

        private async void Payment_Click(object sender, RoutedEventArgs e)
        {
            if (displayPayLateCharges == null) return;

            if (displayPayLateCharges.Count <= 0) return;

            PayLateChargeDialog payLateChargeDialog = new PayLateChargeDialog(displayPayLateCharges);
            var result = await payLateChargeDialog.ShowAsync();

            if(result == ContentDialogResult.Primary)
            {
                displayPayLateCharges = new PayLateChargeBS().GetDisplayPayLateChargesByCusID(customer.CusID);

                lvLateCharges.ItemsSource = displayPayLateCharges;
            }
        }

        private void CalculateMoney()
        {
            if (displayPayLateCharges == null) return;

            var total = displayPayLateCharges.Sum(p => p.lateCharge);

            txtTotal.Text = "Total late charge: " + total;
        }

        private void Autobox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                //Set the ItemsSource to be your filtered dataset
                if (string.IsNullOrWhiteSpace(sender.Text))
                {
                    txtTotal.Text = "Total late charge: 0";
                    lvLateCharges.ItemsSource = null;
                    return;
                }

                sender.ItemsSource = customers.Where(p => p.CusID.ToString().Contains(sender.Text)).ToList();

            }
        }

        private void Autobox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            customer = (Customer)args.SelectedItem;
        }

        private void Autobox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (customer == null) return;

            displayPayLateCharges = new PayLateChargeBS().GetDisplayPayLateChargesByCusID(customer.CusID);

            lvLateCharges.ItemsSource = displayPayLateCharges;

            CalculateMoney();
        }

        private void BtnAddToDo_Click(object sender, RoutedEventArgs e)
        {
            MainPage.mainFrame.Navigate(typeof(DetailLateChargePage));
        }
    }
}
