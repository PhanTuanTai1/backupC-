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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _24102019_uwp.Views.Dialogs
{
    public sealed partial class CalculatorDialog : ContentDialog
    {
        decimal totalMoney;
        int cusID;
        List<int> discIDs;

        public CalculatorDialog(decimal totalMoney, int cusID, List<int> discIDs)
        {
            this.InitializeComponent();

            this.totalMoney = totalMoney;

            total.Text = totalMoney.ToString();
            this.cusID = cusID;
            this.discIDs = discIDs;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            DateTime dateTime = DateTime.Now;

            Rental rental = new Rental() { CusID = cusID, Deleted = false, StartRentDate = dateTime, Status = (short)RentalInformation.RentalStatus.RENTED };

            int rentalID = -1;

            using (var db = new ApplicationDBContext())
            {
                db.Rentals.Add(rental);
                db.SaveChanges();

                rentalID = (db.Rentals.ToList().Count > 0) ? db.Rentals.Last().RentalID : 1;

                if (rentalID != -1)
                {
                    foreach (var id in discIDs)
                    {
                        var title = db.Disks.SingleOrDefault(p => p.DiskID == id).TitleID;
                        var typeID = db.Titles.SingleOrDefault(p => p.TitleID == title).TypeID;
                        var rentPeriod = db.Types.SingleOrDefault(p => p.TypeID == typeID).RentPeriod;
                        Rentail_Detail rentail_Detail = new Rentail_Detail() { RentalID = rentalID, DiskID = id, DueDate = dateTime.AddDays(rentPeriod) };

                        db.Rentail_Detail.Add(rentail_Detail);
                        db.Disks.Single(p => p.DiskID == id).ChkOutStatus = (short)Checkout.CheckoutStatus.RENTED;

                        var reservation = db.Reservations.FirstOrDefault(p => p.TitleID == title && p.Status == (short)Checkout.ReservationStatus.HOLDING);

                        if (reservation != null) reservation.Status = (short)Checkout.ReservationStatus.COMPLETE;
                    }

                    db.SaveChanges();
                }
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(decimal.TryParse(inputMoney.Text, out decimal a))
            {
                if (a - totalMoney > 0)
                    returnMoney.Text = (a - totalMoney).ToString();
                else returnMoney.Text = "---";
            }
        }
    }
}
