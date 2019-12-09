using _24102019_uwp.Business;
using _24102019_uwp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class DetailLateChargePage : Page
    {
        List<Customer> customers;
        Customer customer;
        List<DisplayPayLateCharge> displayPayLateCharges;

        public DetailLateChargePage()
        {
            this.InitializeComponent();

            customers = new RentBS().GetCustomers();

            displayPayLateCharges = new PayLateChargeBS().GetAllDisplayPayLateCharges();

            lvLateCharges.ItemsSource = displayPayLateCharges;
        }

        

        private void Autobox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                //Set the ItemsSource to be your filtered dataset
                if (string.IsNullOrWhiteSpace(sender.Text))
                {
                    lvLateCharges.ItemsSource = new PayLateChargeBS().GetAllDisplayPayLateCharges();
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

            displayPayLateCharges = new PayLateChargeBS().GetDisplayPayLateChargesByCusIDNew(customer.CusID);

            lvLateCharges.ItemsSource = displayPayLateCharges;
        }

        private void BtnAddToDo_Click(object sender, RoutedEventArgs e)
        {
            MainPage.mainFrame.Navigate(typeof(LateChargePage));
        }

        private async void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!Login.IsLogin)
            {
                MainPage.DisplayDialog("Not logged in yet", "To use this function, you need to login.");
                return;
            }

            var deleteConfirm = await DisplayDialog("Delete?", "Are you sure to delete this record?");

            if(deleteConfirm == ContentDialogResult.Primary)
            {
                var item = lvLateCharges.SelectedItem as DisplayPayLateCharge;

                var result = new PayLateChargeBS().DeleteLateCharge(item.RentalID, item.DiskID);

                if (result)
                {
                    displayPayLateCharges = new PayLateChargeBS().GetAllDisplayPayLateCharges();

                    lvLateCharges.ItemsSource = displayPayLateCharges;
                }
            }
        }

        private async Task<ContentDialogResult> DisplayDialog(string title, string content)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Cancle",
                PrimaryButtonText = "OK"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
            return result;
        }

    }
}
