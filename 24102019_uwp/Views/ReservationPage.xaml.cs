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
    public sealed partial class ReservationPage : Page
    {
        List<Customer> customers;
        Customer customer;

        public ReservationPage()
        {
            this.InitializeComponent();
            customers = new RentBS().GetCustomers();
            cbTitle.ItemsSource = new ReservationBS().titles();
        }


        private void Autobox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                //Set the ItemsSource to be your filtered dataset
                if (string.IsNullOrWhiteSpace(sender.Text))
                {
                    return;
                }

                sender.ItemsSource = customers.Where(p => p.CusID.ToString().Contains(sender.Text)).ToList();

            }
        }

        private void Autobox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            customer = (Customer)args.SelectedItem;

            txtName.Text = customer.Name;
            txtPhone.Text = customer.Phone;
        }

        private async Task<ContentDialogResult> DisplayDialog(string title, string content, string closeText, string primaryText)
        {
            ContentDialog completeDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = closeText,
                PrimaryButtonText = primaryText
            };

            ContentDialogResult result = await completeDialog.ShowAsync();
            return result;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = cbTitle.SelectedIndex;

            if (index == -1) return;

            if (string.IsNullOrWhiteSpace(txtName.Text)) return;
            if (string.IsNullOrWhiteSpace(txtPhone.Text)) return;

            if (customer == null) return;

            var titleID = (cbTitle.SelectedItem as Title).TitleID;

            var resBS = new ReservationBS();
            var result = resBS.checkAlreadyReservation(customer.CusID, titleID);

            if(result)
            {
                var selectedButton = await DisplayDialog("Infomation", "You have already reserved this disk, want to reserve more?","No thanks","Yes");

                if (selectedButton == ContentDialogResult.Secondary || selectedButton == ContentDialogResult.None) return; 
            }

            Reservation reservation = new Reservation() { CusID = customer.CusID, Status = (short)Checkout.ReservationStatus.WAITING, TitleID = titleID, Deleted = false };

            resBS.addNewReservation(reservation);

            setToDefault();
        }

        private void setToDefault()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            customer = null;
            autobox.Text = "";
            cbTitle.SelectedIndex = -1;
        }

        private void BtnAddToDo_Click(object sender, RoutedEventArgs e)
        {
            MainPage.mainFrame.Navigate(typeof(DetailReservationPage));
        }
    }

}
