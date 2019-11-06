using _24102019_uwp.Business;
using _24102019_uwp.Views;
using _24102019_uwp.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;




namespace _24102019_uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Frame mainFrame;
        public static NavigationView navigation;

        public MainPage()
        {
            this.InitializeComponent();

            mainFrame = contentFrame;
            navigation = nvTopLevelNav;
        }

        private void nvTopLevelNav_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (NavigationViewItemBase item in nvTopLevelNav.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "Home_Page")
                {
                    nvTopLevelNav.SelectedItem = item;
                    break;
                }
            }
            nvTopLevelNav.Header = "Home Page";
            contentFrame.Navigate(typeof(HomePage));
        }

        private void nvTopLevelNav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem selectedItem = nvTopLevelNav.SelectedItem as NavigationViewItem;

            string selectedTag = selectedItem.Tag as string;

            switch (selectedTag)
            {
                case "Rent_Page":
                    contentFrame.Navigate(typeof(RentPage));
                    nvTopLevelNav.Header = "Rent Page";
                    break;
                case "Return_Page":
                    contentFrame.Navigate(typeof(ReturnPage));
                    nvTopLevelNav.Header = "Return Page";
                    break;
                case "LateCharge_Page":
                    contentFrame.Navigate(typeof(LateChargePage));
                    nvTopLevelNav.Header = "Late Charge Page";
                    break;
                case "Reservation_Page":
                    contentFrame.Navigate(typeof(ReservationPage));
                    nvTopLevelNav.Header = "Reservation Page";
                    break;
                case "Customer_Page":
                    contentFrame.Navigate(typeof(CustomerPage));
                    nvTopLevelNav.Header = "Customer Page";
                    break;
                case "Title_Page":
                    contentFrame.Navigate(typeof(TitlePage));
                    nvTopLevelNav.Header = "Title Page";
                    break;
                case "Individual_Page":
                    //if(!Login.IsLogin)
                    //{
                    //    DisplayDialog("Not logged in yet", "To use this function, you need to login.");
                    //    return;
                    //}
                    contentFrame.Navigate(typeof(IndividualPage));
                    nvTopLevelNav.Header = "Individual Page";
                    break;
                case "Miscellaneous_Page":
                    //if (!Login.IsLogin)
                    //{
                    //    DisplayDialog("Not logged in yet", "To use this function, you need to login.");
                    //    return;
                    //}
                    contentFrame.Navigate(typeof(MiscellaneousPage));
                    nvTopLevelNav.Header = "Individual Page";
                    break;
                case "Report_Page":
                    //if (!Login.IsLogin)
                    //{
                    //    return;
                    //}
                    contentFrame.Navigate(typeof(ReportPage));
                    nvTopLevelNav.Header = "Report Page";
                    break;
            }
                
                    
        }

        private async void NavigationViewItem_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if(!Login.IsLogin)
            {
                var dialog = new LoginDialog();
                var result = await dialog.ShowAsync();

                if(result == ContentDialogResult.Primary)
                {
                    DisplayCompleteDialog();

                    btnLogin.Content = "Logout";
                }
            }
            else
            {
                DisplayNoWifiDialog();
                Login.Logout();
                btnLogin.Content = "Login";
            }
        }

        public static async void DisplayDialog(string title, string content)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }

        private async void DisplayCompleteDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Login successfully",
                Content = "Hello " + Login.User.Name,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }

        private async void DisplayNoWifiDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Logout successfully",
                Content = "Come back any time :)",
                CloseButtonText = "Bye"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }

        private void NavPageReprt_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (!Login.IsLogin)
            {
                DisplayDialog("Not logged in yet", "To use this function, you need to login.");
                return;
            }

            contentFrame.Navigate(typeof(ReportPage));
            nvTopLevelNav.Header = "Report Page";
        }
    }
}
