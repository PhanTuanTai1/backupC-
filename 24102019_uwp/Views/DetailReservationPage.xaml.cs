using _24102019_uwp.Business;
using _24102019_uwp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class DetailReservationPage : Page
    {
        ObservableCollection<DisplayReservation> displays;
        List<Customer> customers;
        Customer customer;

        public DetailReservationPage()
        {
            this.InitializeComponent();

            displays = new ObservableCollection<DisplayReservation>(new ReservationBS().displayReservations());

            customers = new RentBS().GetCustomers();

            lvReservation.ItemsSource = displays;
        }

        private void BtnAddToDo_Click(object sender, RoutedEventArgs e)
        {
            MainPage.mainFrame.Navigate(typeof(ReservationPage));
        }

        private void Autobox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if(string.IsNullOrWhiteSpace(sender.Text))
            {
                displays = new ObservableCollection<DisplayReservation>(new ReservationBS().displayReservations());
                lvReservation.ItemsSource = displays;
            }

            if(int.TryParse(sender.Text, out int a))
            {
                sender.ItemsSource = customers.Where(p => p.CusID.ToString().Contains(sender.Text)).ToList();

                autobox.DisplayMemberPath = "CusID";
                autobox.TextMemberPath = "CusID";
            }
            else
            {
                sender.ItemsSource = customers.Where(p => p.Name.Contains(sender.Text)).ToList();

                autobox.DisplayMemberPath = "Name";
                autobox.TextMemberPath = "Name";
            }
        }

        private void Autobox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            customer = args.SelectedItem as Customer;
        }

        private void Autobox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            displays = new ObservableCollection<DisplayReservation>(displays.Where(p => p.cusID == customer.CusID).ToList());
            lvReservation.ItemsSource = displays;
        }

        private void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var index = lvReservation.SelectedIndex;

            var res = lvReservation.SelectedItem as DisplayReservation;

            displays.RemoveAt(index);

            new ReservationBS().cancelReservation(res.resID);

            displays = new ObservableCollection<DisplayReservation>(new ReservationBS().displayReservations());
            lvReservation.ItemsSource = displays;
        }
    }
}
