using _24102019_uwp.Business;
using _24102019_uwp.Models;
using _24102019_uwp.Views.Dialogs;
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
    public sealed partial class RentPage : Page
    {
        ObservableCollection<Title> Titles;
        List<Disk> disks;
        List<Customer> customers;
        Customer customer;

        List<int> selected;
       // List<int> selectedDiskIds;

        public RentPage()
        {
            this.InitializeComponent();
            Titles = new ObservableCollection<Title>();
            disks = new RentBS().Disks();
            customers = new RentBS().GetCustomers();
            

            selected = new List<int>();
           // selectedDiskIds = new List<int>();
            lvFruits.ItemsSource = Titles;

            totalMoney.Text = "Total: " + CalculateMoney();
        }

        public void SetToDefault()
        {
            Titles = new ObservableCollection<Title>();
            disks = new RentBS().Disks();
            customers = new RentBS().GetCustomers();


            selected = new List<int>();
            // selectedDiskIds = new List<int>();
            lvFruits.ItemsSource = Titles;

            totalMoney.Text = "Total: " + CalculateMoney();

            autobox.Text = "";
        }

        public decimal CalculateMoney()
        {
            return Titles.Sum(p => p.Price);
        }

        private async void Payment_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(autobox.Text,out int a))
            {
                CalculatorDialog calculatorDialog = new CalculatorDialog(CalculateMoney(),a,selected);
                var result = await calculatorDialog.ShowAsync();

                if(result == ContentDialogResult.Primary)
                {
                    SetToDefault();

                    if(new PayLateChargeBS().HaveLateCharge(customer.CusID))
                    {
                        ContentDialog completeDialog = new ContentDialog
                        {
                            Title = "Pay late charge",
                            Content = "You are having unpaid late charge, would you like to pay?",
                            CloseButtonText = "Maybe next time",
                            PrimaryButtonText = "OK"
                        };

                        ContentDialogResult dialogResult = await completeDialog.ShowAsync();

                        if (dialogResult == ContentDialogResult.Primary)
                        {
                            MainPage.mainFrame.Navigate(typeof(LateChargePage), customer.CusID);
                        }
                    }
                }
                else
                {
                    DisplayDialog("Error","There are errors happened in payment, please try again","OK");
                }
            }
        }

        private async void DisplayDialog(string title, string content, string button)
        {
            ContentDialog completeDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = button,
            };

            ContentDialogResult result = await completeDialog.ShowAsync();
        }

        private void Autobox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                //Set the ItemsSource to be your filtered dataset
                if(string.IsNullOrWhiteSpace(sender.Text))
                {
                    SetToDefault();
                    return;
                }

                sender.ItemsSource = customers.Where(p => p.CusID.ToString().Contains(sender.Text)).ToList();

            }
        }

        private void Autobox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            customer = (Customer)args.SelectedItem;

            uID.Text = "Hello " + customer.Name;

            uID.Visibility = Visibility.Visible;
            uID.Margin = new Thickness(0, 0, 0, 24);
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                sender.ItemsSource = disks.Where(p => p.DiskID.ToString().Contains(sender.Text) && p.ChkOutStatus == (short)Checkout.CheckoutStatus.SHELF);
            }
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var disk = (Disk)args.SelectedItem;

            if (selected.Contains(disk.DiskID)) return;

            selected.Add(disk.DiskID);

            var Title = new RentBS().GetTitleByID(disk.TitleID);

            Titles.Add(Title);

            totalMoney.Text = "Total: " + CalculateMoney();
        }

        private void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var index = lvFruits.SelectedIndex;

            if (index < 0) return;

            Titles.RemoveAt(index);

            selected.RemoveAt(index);

            totalMoney.Text = "Total: " + CalculateMoney();
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion == null && !string.IsNullOrEmpty(productFind.Text))
            {
                var disk = productFind.Items.SingleOrDefault(p => (p as Disk).DiskID.ToString() == productFind.Text) as Disk;

                if (disk == null) return;

                if (selected.Contains(disk.DiskID)) return;

                selected.Add(disk.DiskID);

                var Title = new RentBS().GetTitleByID(disk.TitleID);

                Titles.Add(Title);

                totalMoney.Text = "Total: " + CalculateMoney();
            }
        }

        private void Autobox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (customer == null) return;
          
            var titles = new RentBS().GetTitlesOnHoldByCus(customer.CusID);

            if (titles == null) return;

            foreach (var title in titles)
            {
                if (Titles.Where(p => p.TitleID == title.TitleID).Count() <= 0)
                {
                    var disk = new RentBS().getFirstDiskOnHold(title.TitleID);

                    if (disk == null) return;

                    if (selected.Contains(disk.DiskID)) return;

                    selected.Add(disk.DiskID);

                    Titles.Add(title);
                }
            }

            totalMoney.Text = "Total: " + CalculateMoney();
        }
    }
}
