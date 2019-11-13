using _24102019_uwp.Data;
using _24102019_uwp.Models;
using _24102019_uwp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Business
{
    public class DiskBS
    {
        public List<customDisk> getDisks()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Disks.Where(n => n.Deleted == false).ToList().Select(n => new customDisk
                {
                    DiskID = n.DiskID,
                    TitleName = db.Titles.Single(m => m.TitleID == n.TitleID).Name,
                    ChkOutStatus = status(n.ChkOutStatus),
                    Deleted = n.Deleted,
                    IsAvailable = db.Titles.Single(m => m.TitleID == n.TitleID).IsAvailable ? "Có sẵn" : "Hết hàng",
                    Price = db.Titles.Single(m => m.TitleID == n.TitleID).Price
                }).ToList();
            }
        }
        public bool AddDisk(Disk d)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                db.Disks.Add(d);
                db.SaveChanges();
                return true;
            }
        }
        public bool RemoveDisk(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                db.Disks.SingleOrDefault(x => x.DiskID == id).Deleted = true;
                db.SaveChanges();
                return true;
            }
        }
        public bool ModifyDisk(Disk t)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                Disk temp = db.Disks.Single(x => x.DiskID == t.DiskID);
                temp.ChkOutStatus = t.ChkOutStatus;
                temp.Deleted = t.Deleted;
                temp.DiskID = t.DiskID;
                db.SaveChanges();
                return true;
            }

        }
        public bool CheckIDExists(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                if (db.Disks.SingleOrDefault(x => x.DiskID == id) != null) return true;
                return false;
            }
        }
        public string getUserRent(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    return db.Customers.SingleOrDefault(n => n.CusID == db.Rentals.SingleOrDefault(m => m.RentalID == db.Rentail_Detail.SingleOrDefault(a => a.DiskID == id && a.ReturnDate == null).RentalID).CusID).Name;
                }
                catch (Exception)
                {
                    return "None";
                }

            }
        }
        public string getDueDate(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                try
                {
                    return ((DateTime)db.Rentail_Detail.SingleOrDefault(a => a.DiskID == id && a.ReturnDate == null).DueDate).ToString("dd/MM/yyyy");
                }
                catch (Exception)
                {
                    return "None";
                }

            }
        }

        public string status(short t)
        {
            switch (t)
            {
                case (short)Checkout.DiskStatus.ONHOLD:
                    return "On Hold";
                case (short)Checkout.DiskStatus.RENTED:
                    return "Rented";
                case (short)Checkout.DiskStatus.SHELF:
                    return "On Shelf";
                case (short)Checkout.DiskStatus.INSTOCK:
                    return "In Stock";
                default:
                    return "";
            }
        }
    }
}
