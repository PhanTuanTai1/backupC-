using _24102019_uwp.Data;
using _24102019_uwp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Business
{
    public class ReservationBS
    {
        public List<Title> titles()
        {
            using(ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Titles.ToList();
            }
        }

        public bool checkAlreadyReservation(int cusID, int titleID)
        {
            using(ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Reservations.Where(p => p.CusID == cusID && !p.Deleted && p.TitleID == titleID).Count() > 0;
            }
        }

        public void addNewReservation(Reservation reservation)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
            }
        }

        public bool IsStillOnShelf(int titleID)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var totalOnShelf = db.Disks.Where(p => p.TitleID == titleID && !p.Deleted && p.ChkOutStatus == (short)Checkout.DiskStatus.SHELF).Count();

                if (totalOnShelf > 0) return true;
            }
            return false;
        }

        public List<DisplayReservation> displayReservations()
        {
            List<DisplayReservation> ls = new List<DisplayReservation>();

            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var reservations = db.Reservations.Where(p => !p.Deleted).ToList();

                foreach(var res in reservations)
                {
                    DisplayReservation displayReservation = new DisplayReservation();

                    Customer customer = db.Customers.SingleOrDefault(p => p.CusID == res.CusID);

                    Title title = db.Titles.SingleOrDefault(p => p.TitleID == res.TitleID);

                    displayReservation.resID = res.ResID;
                    displayReservation.cusID = customer.CusID;
                    displayReservation.cusName = customer.Name;
                    displayReservation.cusPhone = customer.Phone;
                    displayReservation.startResDate = res.StartResDate;
                    displayReservation.Title = title.Name;
                    switch(res.Status)
                    {
                        case 0:
                            displayReservation.status = "Waiting for disk";
                            break;
                        case 1:
                            displayReservation.status = "Have disk";
                            break;
                        case 2:
                            displayReservation.status = "Complete";
                            break;
                    }

                    ls.Add(displayReservation);

                }
            }

            return ls;
        }

        public void cancelReservation(int resID)
        {
            using (var db = new ApplicationDBContext())
            {
                var res = db.Reservations.SingleOrDefault(p => p.ResID == resID);

                if (res != null)
                {
                    res.Deleted = true;
                    db.SaveChanges();
                }
            }
        }
    }
}
