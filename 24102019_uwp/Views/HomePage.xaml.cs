using _24102019_uwp.Business;
using _24102019_uwp.Data;
using _24102019_uwp.Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _24102019_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //using (var db = new ApplicationDBContext())
            //{
            //    db.Types.Add(new Models.Type()
            //    {
            //        TypeID = 123,
            //        RentCharge = 10000,
            //        RentPeriod = 5000,
            //        TypeName = "Phim"
            //    });
            //    db.Types.Add(new Models.Type()
            //    {
            //        TypeID = 124,
            //        RentCharge = 10000,
            //        RentPeriod = 5000,
            //        TypeName = "Game"
            //    });
            //    db.Titles.Add(new Title()
            //    {
            //        Deleted = false,
            //        Description = "Phim Hanh Dong",
            //        IsAvailable = true,
            //        Name = "Merval 1",
            //        Price = 10000,
            //        TitleID = 123,
            //        TypeID = 123
            //    });
            //    db.Titles.Add(new Title()
            //    {
            //        Deleted = false,
            //        Description = "Phim Hanh Dong",
            //        IsAvailable = true,
            //        Name = "Merval 2",
            //        Price = 10000,
            //        TitleID = 124,
            //        TypeID = 123
            //    });
            //    db.Disks.Add(new Disk()
            //    {
            //        ChkOutStatus = 0,
            //        Deleted = false,
            //        DiskID = 123,
            //        TitleID = 123
            //    });
            //    db.Disks.Add(new Disk()
            //    {
            //        ChkOutStatus = 0,
            //        Deleted = false,
            //        DiskID = 124,
            //        TitleID = 123
            //    });
            //    db.Disks.Add(new Disk()
            //    {
            //        ChkOutStatus = 0,
            //        Deleted = false,
            //        DiskID = 125,
            //        TitleID = 123
            //    });
            //    db.Customers.Add(new Customer()
            //    {
            //        Address = "17/350 F15",
            //        CusID = 12345,
            //        Deleted = false,
            //        Name = "Việt",
            //        Phone = "01647297306"
            //    });
            //    db.Rentals.Add(new Rental()
            //    {
            //        CusID = 12345,
            //        Deleted = false,
            //        RentalID = 987,
            //        StartRentDate = DateTime.Now,
            //        Status = 0
            //    });
            //    db.Rentail_Detail.Add(new Rentail_Detail()
            //    {
            //        DiskID = 123,
            //        DueDate = DateTime.Now,
            //        OwnedMoney = 0,
            //        RentalID = 987,
            //        ReturnDate = null
            //    });
            //    db.SaveChanges();
            //}
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
