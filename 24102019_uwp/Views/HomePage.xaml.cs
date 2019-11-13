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
            addDataBase();   
            //SeedTitle();
        }

        private void SeedTitle()
        {
            using(var db = new ApplicationDBContext())
            {
                db.Types.Add(new Models.Type()
                {
                    TypeID = 123,
                    RentCharge = 10000,
                    RentPeriod = 3,
                    TypeName = "DVD"
                });
                db.Types.Add(new Models.Type()
                {
                    TypeID = 124,
                    RentCharge = 10000,
                    RentPeriod = 1,
                    TypeName = "Game"
                });
                db.SaveChanges();
            }
        }

        private void addDataBase()
        {
            using (var db = new ApplicationDBContext())
            {
                db.Types.Add(new Models.Type()
                {
                    TypeID = 123,
                    RentCharge = 10000,
                    RentPeriod = 5000,
                    TypeName = "Phim"
                });
                db.Types.Add(new Models.Type()
                {
                    TypeID = 124,
                    RentCharge = 10000,
                    RentPeriod = 5000,
                    TypeName = "Game"
                });
                db.Titles.Add(new Title()
                {
                    Deleted = false,
                    Description = "Phim Hanh Dong",
                    IsAvailable = true,
                    Name = "Merval 1",
                    Price = 10000,
                    TitleID = 123,
                    TypeID = 123
                });
                db.Titles.Add(new Title()
                {
                    Deleted = false,
                    Description = "Phim Hanh Dong",
                    IsAvailable = true,
                    Name = "Merval 2",
                    Price = 10000,
                    TitleID = 124,
                    TypeID = 123
                });
                db.Disks.Add(new Disk()
                {
                    ChkOutStatus = (int)Checkout.DiskStatus.RENTED,
                    Deleted = false,
                    DiskID = 100,
                    TitleID = 123
                });
                db.Disks.Add(new Disk()
                {
                    ChkOutStatus = (int)Checkout.DiskStatus.RENTED,
                    Deleted = false,
                    DiskID = 101,
                    TitleID = 123
                });
                db.Disks.Add(new Disk()
                {
                    ChkOutStatus = (int)Checkout.DiskStatus.SHELF,
                    Deleted = false,
                    DiskID = 102,
                    TitleID = 123
                });
                db.Disks.Add(new Disk()
                {
                    ChkOutStatus = (int)Checkout.DiskStatus.SHELF,
                    Deleted = false,
                    DiskID = 103,
                    TitleID = 123
                });
                db.Disks.Add(new Disk()
                {
                    ChkOutStatus = (int)Checkout.DiskStatus.RENTED,
                    Deleted = false,
                    DiskID = 104,
                    TitleID = 123
                });
                db.Disks.Add(new Disk()
                {
                    ChkOutStatus = (int)Checkout.DiskStatus.INSTOCK,
                    Deleted = false,
                    DiskID = 105,
                    TitleID = 123
                });
                db.Disks.Add(new Disk()
                {
                    ChkOutStatus = (int)Checkout.DiskStatus.ONHOLD,
                    Deleted = false,
                    DiskID = 106,
                    TitleID = 124
                });
                db.Customers.Add(new Customer()
                {
                    Address = "17/350 F15",
                    CusID = 12345,
                    Deleted = false,
                    Name = "Việt",
                    Phone = "01647297306"
                });
                db.Customers.Add(new Customer()
                {
                    Address = "17/350 F15",
                    CusID = 11111,
                    Deleted = false,
                    Name = "Nam Anh",
                    Phone = "01647297306"
                });
                db.Customers.Add(new Customer()
                {
                    Address = "17/350 F15",
                    CusID = 11122,
                    Deleted = false,
                    Name = "Tai",
                    Phone = "01612345678"
                });
                //Cu việt mượn
                db.Rentals.Add(new Rental()
                {
                    CusID = 12345,
                    Deleted = false,
                    RentalID = 100,
                    StartRentDate = DateTime.Now,
                    Status = 0
                });
                //quá hạn-đã trả-phát sinh phí-chưa thanh toán
                db.Rentail_Detail.Add(new Rentail_Detail()
                {
                    DiskID = 101,
                    DueDate = DateTime.Now.AddDays(-30),
                    OwnedMoney = 5000,
                    RentalID = 100,
                    ReturnDate = DateTime.Now,
                    Paid = false
                });
                //Quá hạn - đã trả - phát sinh phí- chưa thanh toán
                db.Rentail_Detail.Add(new Rentail_Detail()
                {
                    DiskID = 102,
                    DueDate = DateTime.Now.AddDays(-30),
                    OwnedMoney = 5000,
                    RentalID = 100,
                    ReturnDate = DateTime.Now,
                    Paid = true
                });
                //Đúng hạn, đã trả, đã thanh toán
                db.Rentail_Detail.Add(new Rentail_Detail()
                {
                    DiskID = 103,
                    DueDate = DateTime.Now,
                    OwnedMoney = 0,
                    RentalID = 100,
                    ReturnDate = DateTime.Now.AddDays(-10),
                    Paid = true
                });

                //Cu Tài mượn
                db.Rentals.Add(new Rental()
                {
                    CusID = 11122,
                    Deleted = false,
                    RentalID = 101,
                    StartRentDate = DateTime.Now.AddDays(-30),
                    Status = 0
                });
                //Not trễ hẹn
                db.Rentail_Detail.Add(new Rentail_Detail()
                {
                    DiskID = 104,
                    DueDate = DateTime.Now.AddDays(10),
                    OwnedMoney = 0,
                    RentalID = 101,
                    ReturnDate = null,
                    Paid = false
                });
                //Trễ hẹn - chưa trả - chưa phát sinh phí
                db.Rentail_Detail.Add(new Rentail_Detail()
                {
                    DiskID = 100,
                    DueDate = DateTime.Now.AddDays(-15),
                    OwnedMoney = 0,
                    RentalID = 101,
                    ReturnDate = null,
                    Paid = false
                });
                ////Đã trả, phát sinh phí, chưa thanh toán
                //db.Rentail_Detail.Add(new Rentail_Detail()
                //{
                //    DiskID = 101,
                //    DueDate = DateTime.Now.AddDays(-30),
                //    OwnedMoney = 5000,
                //    RentalID = 101,
                //    ReturnDate = DateTime.Now,
                //    Paid = false
                //});

                db.Reservations.Add(new Reservation()
                {
                    CusID = 11111,
                    Deleted = false,
                    ResID = 100,
                    StartResDate = DateTime.Now,
                    Status = (short)Checkout.ReservationStatus.HOLDING,
                    TitleID = 124
                });
                db.Reservations.Add(new Reservation()
                {
                    CusID = 11111,
                    Deleted = false,
                    ResID = 101,
                    StartResDate = DateTime.Now,
                    Status = (short)Checkout.ReservationStatus.WAITING,
                    TitleID = 124
                });
                db.SaveChanges();
            }
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
