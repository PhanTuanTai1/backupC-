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
    public sealed partial class DetailCustomerReportPage : Page
    {
        ObservableCollection<DisplayPayLateCharge> lsLateCharge;
        ObservableCollection<reportDisk> lsDiskDue;
        CustomCustomer c;
        ReportBS b;
        public DetailCustomerReportPage()
        {
            this.InitializeComponent();

            lsLateCharge = new ObservableCollection<DisplayPayLateCharge>();
            lsDiskDue = new ObservableCollection<reportDisk>();

            b = new ReportBS();
        }

        private void BtnAddToDo_Click(object sender, RoutedEventArgs e)
        {
            MainPage.mainFrame.Navigate(typeof(ReportPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            c = (CustomCustomer)e.Parameter;

            if (c == null) return;

            Customer n = b.getCustomer(c.ID);
            Name.Text = n.Name;
            Phone.Text = n.Phone;
            Address.Text = n.Address;
            TotalDiskOut.Text = b.getCountDisk(n.CusID) + "";
            TotalPrice.Text = b.getLateFeeCustomer(n.CusID) + "";

            lvDisk.ItemsSource = b.getAllDiskNotPayByCusId(c.ID);
            lvAllDiskOverDue.ItemsSource = b.getAllDiskOverDue(c.ID);
        }

        public class reportDisk
        {
            public int DiskID { get; set; }
            public string TitleName { get; set; }
            public string DueDate { get; set; }
            public string ReturnDate { get; set; }
            public decimal Price { get; set; }

            public reportDisk() { }
            public reportDisk(int diskID, string titleName, string dueDate, string returnDate, decimal price)
            {
                DiskID = diskID;
                TitleName = titleName;
                DueDate = dueDate;
                ReturnDate = returnDate;
                Price = price;
            }
        }
    }
}
