using _24102019_uwp.Data;
using _24102019_uwp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Business
{
    public class RentBS
    {
        public List<Customer> GetCustomers()
        {
            using(ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Customers.ToList();
            }
        }

        public List<Disk> Disks()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Disks.ToList();
            }
        }

        public Title GetTitleByID(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Titles.SingleOrDefault(p => p.TitleID == id);
            }
        }

        public List<Title> GetTitlesOnHoldByCus(int cusID)
        {
            using(ApplicationDBContext db = new ApplicationDBContext())
            {
                var reservations = db.Reservations.Where(p => p.CusID == cusID && p.Status == (short)Checkout.ReservationStatus.HOLDING).ToList();

                if (reservations.Count <= 0) return null;

                var titles = new List<Title>();

                foreach(var reservation in reservations)
                {
                    var title = db.Titles.SingleOrDefault(p => p.TitleID == reservation.TitleID);
                    titles.Add(title);
                }

                return titles;
            }
        }

        public Disk getFirstDiskOnHold(int titleID)
        {
            using(ApplicationDBContext db = new ApplicationDBContext())
            {
                var disk = db.Disks.FirstOrDefault(p => p.TitleID == titleID && p.ChkOutStatus == (short)Checkout.DiskStatus.ONHOLD);

                return disk;
            }
        }
    }
}
