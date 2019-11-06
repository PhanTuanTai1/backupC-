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
    public class ReportBS
    {
        public List<CustomCustomer> getAll()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var ls1 = db.Rentals
                    .Join(db.Rentail_Detail, p => p.RentalID, m => m.RentalID, (p, m) => new { Rental = p, Rentail_Detail = m })
                    .Select(n=>new {
                    CusID = n.Rental.CusID,
                    dateEnd = n.Rentail_Detail.DueDate,
                    dateCurrent = n.Rentail_Detail.ReturnDate,
                    lateFee = n.Rentail_Detail.OwnedMoney
                });

                var ls2 = ls1.GroupBy(n=>n.CusID).Select(n=>new { key = n.Key, fee = n.Sum(m=>m.lateFee),diskOverDue = n.Where(m=>m.lateFee>0).Count(),totalDisk = n.Count()});


                return db.Customers.Select(n => new CustomCustomer()
                {
                    Address = n.Address,
                    DiskOverdue = ls2.SingleOrDefault(m => m.key == n.CusID)!=null? ls2.SingleOrDefault(m => m.key == n.CusID).diskOverDue:0,
                    ID = n.CusID,
                    LateFees = ls2.SingleOrDefault(m=>m.key==n.CusID)!=null? decimal.Parse(ls2.SingleOrDefault(m => m.key == n.CusID).fee.ToString()):0,
                    Name = n.Name,
                    TotalDisk = ls2.SingleOrDefault(m => m.key == n.CusID)!=null? ls2.SingleOrDefault(m => m.key == n.CusID).totalDisk:0
                }).ToList();
            }
        }

        public List<CustomCustomer> getAllOverDueCustomer()
        {
            return getAll().Where(n => n.DiskOverdue > 0).ToList();
        }

        public List<CustomCustomer> getAllLateFeeCustomer()
        {
            return getAll().Where(n => n.LateFees > 0).ToList();
        }

        public List<customTitleReport> getAllTitleReport()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //var ls1 = db.Disks
                //    .Join(db.Rentail_Detail, n => n.DiskID, m => m.DiskID, (n, m) => new { Disk = n, Rentail_Detail = m })
                //    .Select(n => new customTitleReport() {
                //        CopyInStock = 0,
                //        CopyOnHold = ,
                //        CopyRent = ,
                //        CopyReservation = ,
                //        ID = ,
                //        Name
                //    })
                return db.Titles.Select(n => new customTitleReport()
                {
                    CopyInStock = db.Disks.Where(m => m.TitleID == n.TypeID && m.ChkOutStatus == (short)Checkout.DiskStatus.SHELF).Count(),
                    CopyOnHold = db.Disks.Where(m => m.TitleID == n.TypeID && m.ChkOutStatus == (short)Checkout.DiskStatus.ONHOLD).Count(),
                    CopyRent = db.Disks.Where(m => m.TitleID == n.TypeID && m.ChkOutStatus == (short)Checkout.DiskStatus.RENTED).Count(),
                    CopyReservation = db.Reservations.Where(m => m.TitleID == n.TitleID && m.Deleted == false).Count(),
                    ID = n.TitleID,
                    Name = n.Name
                }).ToList();
            }
             
        }
    }
}
