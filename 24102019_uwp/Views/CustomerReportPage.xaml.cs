using _24102019_uwp.Business;
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
            if (lvCustomer.SelectedItem != null)
            {
                MainPage.mainFrame.Navigate(typeof(DetailCustomerReportPage), (CustomCustomer)lvCustomer.SelectedItem);
            }
            else
            {
                ContentDialog cd = new ContentDialog();
                cd.Content = "Please Choose One Customer in list below";
                cd.Title = "Notification";
                cd.PrimaryButtonText = "Close";
                cd.ShowAsync();
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            lsCustomer = new ObservableCollection<CustomCustomer>(rp.getAll());
            lvCustomer.ItemsSource = lsCustomer;
            lvCustomer.SelectedItem = null;
            cbCustomReport.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbCustomReport.SelectedIndex)
            {
                case 0:
                    lsCustomer = new ObservableCollection<CustomCustomer>(rp.getAll());
                    break;
                case 1:
                    lsCustomer = new ObservableCollection<CustomCustomer>(rp.getAllOverDueCustomer());
                    break;
                case 2:
                    lsCustomer = new ObservableCollection<CustomCustomer>(rp.getAllLateFeeCustomer());
                    break;
                default:
                    break;
            }
            lvCustomer.ItemsSource = lsCustomer;
        }

    }

    public class CustomCustomer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int TotalDisk { get; set; }
        public int DiskOverdue { get; set; }
        public decimal LateFees { get; set; }

        public CustomCustomer() { }

        public CustomCustomer(int iD, string name, string address, int totalDisk, int diskOverdue, decimal lateFees)
        {
            ID = iD;
            Name = name;
            Address = address;
            TotalDisk = totalDisk;
            DiskOverdue = diskOverdue;
            LateFees = lateFees;
        }
    }

    public class customTitle
    {
        public int TitleID { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public bool Deleted { get; set; }

        public string TypeName { get; set; }

        public customTitle() { }

        public customTitle(int titleID, string description, string name, decimal price, bool isAvailable, bool deleted, string typeName)
        {
            TitleID = titleID;
            Description = description;
            Name = name;
            Price = price;
            IsAvailable = isAvailable;
            Deleted = deleted;
            TypeName = typeName;
        }
    }
}
