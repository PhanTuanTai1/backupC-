using _24102019_uwp.Business;
using _24102019_uwp.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _24102019_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerReportPage : Page
    {
        ObservableCollection<CustomCustomer> lsCustomer;
        ReportBS rp;

        public CustomerReportPage()
        {
            this.InitializeComponent();
            rp = new ReportBS();
            lsCustomer = new ObservableCollection<CustomCustomer>(rp.getAll());
            lvCustomer.ItemsSource = lsCustomer;
        }

        private void BtnViewDetail_Click(object sender, RoutedEventArgs e)
        {
            MainPage.mainFrame.Navigate(typeof(DetailCustomerReportPage));
        }
    }

    public class CustomCustomer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int TotalDisk { get; set; }
        public string DiskOverdue { get; set; }
        public string LateFees { get; set; }

        public CustomCustomer() { }

        public CustomCustomer(string iD, string name, string address, int totalDisk, string diskOverdue, string lateFees)
        {
            ID = iD;
            Name = name;
            Address = address;
            TotalDisk = totalDisk;
            DiskOverdue = diskOverdue;
            LateFees = lateFees;
        }
    }
}
