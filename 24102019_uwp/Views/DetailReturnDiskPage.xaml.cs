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
using _24102019_uwp.Models;
using _24102019_uwp.Business;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _24102019_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailReturnDiskPage : Page
    {
        DetailReturnDisk drd;
        public string cusName, titleName;
        public DateTime startDate, dueDate, returnDate;
        public int totalDateLate;
        public decimal lateCharge;

        private void Return(object sender, RoutedEventArgs e)
        {
            ReturnBS rb = new ReturnBS();
            bool check =  rb.ReturnDisk(drd.DiskID, drd.CusID, drd.LateCharge, drd.ReturnDate);
            if(check)
            {
                (this.Parent as Frame).Content = null;
                DisplayDialog(check);
                return;
            }
            DisplayDialog(check);
        }

        public DetailReturnDiskPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            drd = (DetailReturnDisk)e.Parameter;
            if(drd != null) setValue(drd);
        }
        private void setValue(DetailReturnDisk drd)
        {
            cusName = drd.CusName;
            titleName = drd.TitleName;
            startDate = drd.StartDate;
            dueDate = drd.DueDate;
            returnDate = drd.ReturnDate;
            totalDateLate = drd.TotalDateLate;
            lateCharge = drd.LateCharge;
            
        }
        public void DisplayDialog(bool type)
        {
            ContentDialog cd = new ContentDialog();
            if (type)
            {
                cd.Content = "Success";
                cd.Title = "Notification";
                cd.PrimaryButtonText = "Close";
            }
            else if (!type)
            {
                cd.Content = "Fail";
                cd.Title = "Notification";
                cd.PrimaryButtonText = "Close";
            }
            cd.ShowAsync();
        }
    }
}
