using _24102019_uwp.Business;
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
    public sealed partial class TitleReportPage : Page
    {
        ObservableCollection<customTitleReport> lsTitle;
        ReportBS rp;

        public TitleReportPage()
        {
            this.InitializeComponent();
            rp = new ReportBS();
            lsTitle = new ObservableCollection<customTitleReport>(rp.getAllTitleReport());
            lvTitle.ItemsSource = lsTitle;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            lsTitle = new ObservableCollection<customTitleReport>(rp.getAllTitleReport());
            lvTitle.ItemsSource = lsTitle;
        }

    }

    public class customTitleReport
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CopyRent { get; set; }
        public int CopyOnHold { get; set; }
        public int CopyInStock { get; set; }
        public int CopyReservation { get; set; }

        public customTitleReport(int iD, string name, int copyRent, int copyOnHold, int copyInStock, int copyReservation)
        {
            ID = iD;
            this.Name = name;
            CopyRent = copyRent;
            CopyOnHold = copyOnHold;
            CopyInStock = copyInStock;
            CopyReservation = copyReservation;
        }
        public customTitleReport() { }
    }

    
}
