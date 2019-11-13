using _24102019_uwp.Data;
using _24102019_uwp.Models;
using _24102019_uwp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using static _24102019_uwp.Views.DetailCustomerReportPage;

namespace _24102019_uwp.Business
{
    public class ReportBS
    {
        public List<CustomCustomer> getAll()
        {
            //using (ApplicationDBContext db = new ApplicationDBContext())
            //{
            //    var ls1 = db.Rentals
            //        .Join(db.Rentail_Detail, p => p.RentalID, m => m.RentalID, (p, m) => new { Rental = p, Rentail_Detail = m })
            //        .Select(n => new
            //        {
            //            CusID = n.Rental.CusID,
            //            dateEnd = n.Rentail_Detail.DueDate,
            //            dateCurrent = n.Rentail_Detail.ReturnDate,
            //            lateFee = n.Rentail_Detail.OwnedMoney
            //        });

            //    var ls2 = ls1.GroupBy(n => n.CusID).Select(n => new { key = n.Key, fee = n.Sum(m => m.lateFee), diskOverDue = n.Where(m => m.lateFee > 0).Count(), totalDisk = n.Count() });


            //    return db.Customers.Select(n => new CustomCustomer()
            //    {
            //        Address = n.Address,
            //        DiskOverdue = ls2.SingleOrDefault(m => m.key == n.CusID) != null ? ls2.SingleOrDefault(m => m.key == n.CusID).diskOverDue : 0,
            //        ID = n.CusID,
            //        LateFees = ls2.SingleOrDefault(m => m.key == n.CusID) != null ? decimal.Parse(ls2.SingleOrDefault(m => m.key == n.CusID).fee.ToString()) : 0,
            //        Name = n.Name,
            //        TotalDisk = ls2.SingleOrDefault(m => m.key == n.CusID) != null ? ls2.SingleOrDefault(m => m.key == n.CusID).totalDisk : 0
            //    }).ToList();
            //}
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var ls1 = db.Rentals
                    .Join(db.Rentail_Detail, p => p.RentalID, m => m.RentalID, (p, m) => new { Rental = p, Rentail_Detail = m })
                    .Select(n => new
                    {
                        CusID = n.Rental.CusID,
                        dateEnd = n.Rentail_Detail.DueDate,
                        dateCurrent = n.Rentail_Detail.ReturnDate,
                        lateFee = n.Rentail_Detail.OwnedMoney
                    });

                var ls2 = ls1.GroupBy(n => n.CusID).Select(n => new { key = n.Key, fee = n.Sum(m => m.lateFee), diskOverDue = n.Where(m => m.dateCurrent == null?m.dateEnd < DateTime.Now:m.dateCurrent>m.dateEnd).Count(), totalDisk = n.Count() });


                return db.Customers.Select(n => new CustomCustomer()
                {
                    Address = n.Address,
                    DiskOverdue = ls2.SingleOrDefault(m => m.key == n.CusID) != null ? ls2.SingleOrDefault(m => m.key == n.CusID).diskOverDue : 0,
                    ID = n.CusID,
                    LateFees = ls2.SingleOrDefault(m => m.key == n.CusID) != null ? decimal.Parse(ls2.SingleOrDefault(m => m.key == n.CusID).fee.ToString()) : 0,
                    Name = n.Name,
                    TotalDisk = ls2.SingleOrDefault(m => m.key == n.CusID) != null ? ls2.SingleOrDefault(m => m.key == n.CusID).totalDisk : 0
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
                return db.Titles.Join(db.Disks, n => n.TitleID, m => m.TitleID, (n, m) => new { Title = n, Disk = m })
                    .GroupBy(n => n.Title.TitleID)
                    .Select(n => new customTitleReport()
                    {
                        CopyInStock = n.Count(m => m.Disk.ChkOutStatus == (short)Checkout.DiskStatus.INSTOCK),
                        CopyOnHold = n.Count(m => m.Disk.ChkOutStatus == (short)Checkout.DiskStatus.ONHOLD),
                        CopyRent = n.Count(m => m.Disk.ChkOutStatus == (short)Checkout.DiskStatus.RENTED),
                        CopyReservation = db.Reservations.Where(m => m.TitleID == n.Key && m.Status != (short)Checkout.ReservationStatus.COMPLETE && m.Deleted == false).Count(),
                        ID = n.Key,
                        Name = db.Titles.SingleOrDefault(m => m.TitleID == n.Key).Name
                    }).ToList();
            }

        }

        public Customer getCustomer(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Customers.SingleOrDefault(n => n.CusID == id);
            }
        }

        public int getCountDisk(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Rentals.Join(db.Rentail_Detail, n => n.RentalID, m => m.RentalID, (n, m) => new { Rental = n, Rentail_Detail = m }).Where(n => n.Rental.CusID == id).Count();
            }
        }

        public decimal getLateFeeCustomer(int id)
        {
            return getAll().Single(n => n.ID == id).LateFees;
        }

        public List<reportDisk> getAllDiskNotPayByCusId(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var ls1 = db.Rentals.Where(n => n.CusID == id).Join(db.Rentail_Detail, p => p.RentalID, m => m.RentalID, (p, m) => new { Rental = p, Rentail_Detail = m }).Where(n => n.Rentail_Detail.ReturnDate != null && n.Rentail_Detail.OwnedMoney > 0 && n.Rentail_Detail.Paid == false);
                if (ls1.ToList().Count != 0)
                {
                    var ls2 = ls1.Select(n => new reportDisk()
                    {
                        DiskID = n.Rentail_Detail.DiskID,
                        TitleName = db.Titles.Single(m => m.TitleID == db.Disks.Single(p => p.DiskID == n.Rentail_Detail.DiskID).TitleID).Name,
                        DueDate = ((DateTime)(n.Rentail_Detail.DueDate)).ToString("dd/MM/yyyy"),
                        ReturnDate = ((DateTime)(n.Rentail_Detail.ReturnDate)).ToString("dd/MM/yyyy"),
                        Price = decimal.Parse(n.Rentail_Detail.OwnedMoney.ToString())
                    }).ToList();
                    return ls2;
                }

                return new List<reportDisk>();
            }
        }

        public List<reportDisk> getAllDiskOverDue(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //var ls1 = db.Rentals.Where(n => n.CusID == id).Join(db.Rentail_Detail, p => p.RentalID, m => m.RentalID, (p, m) => new { Rental = p, Rentail_Detail = m }).Where(n => n.Rentail_Detail.ReturnDate != null && n.Rentail_Detail.OwnedMoney > 0);
                //if (ls1.ToList().Count != 0)
                //{
                //    var ls2 = ls1.Select(n => new reportDisk()
                //    {
                //        DiskID = n.Rentail_Detail.DiskID,
                //        TitleName = db.Titles.Single(m => m.TitleID == db.Disks.Single(p => p.DiskID == n.Rentail_Detail.DiskID).TitleID).Name,
                //        DueDate = ((DateTime)(n.Rentail_Detail.DueDate)).ToString("dd/MM/yyyy"),
                //        ReturnDate = ((DateTime)(n.Rentail_Detail.ReturnDate)).ToString("dd/MM/yyyy"),
                //        Price = decimal.Parse(n.Rentail_Detail.OwnedMoney.ToString())
                //    }).ToList();
                //    return ls2;
                //}

                var ls1 = db.Rentals
                   .Join(db.Rentail_Detail, p => p.RentalID, m => m.RentalID, (p, m) => new { Rental = p, Rentail_Detail = m })
                   .Where(n => n.Rental.CusID == id)
                   .Where(n=> n.Rentail_Detail.ReturnDate == null ? n.Rentail_Detail.DueDate < DateTime.Now : n.Rentail_Detail.ReturnDate > n.Rentail_Detail.DueDate)
                   .ToList();
                   
                if (ls1.Count != 0)
                {
                    var ls2 = ls1.Select(n => new reportDisk()
                    {
                        DiskID = n.Rentail_Detail.DiskID,
                        TitleName = db.Titles.Single(m => m.TitleID == db.Disks.Single(p => p.DiskID == n.Rentail_Detail.DiskID).TitleID).Name,
                        DueDate = ((DateTime)(n.Rentail_Detail.DueDate)).ToString("dd/MM/yyyy"),
                        ReturnDate = n.Rentail_Detail.ReturnDate!=null?((DateTime)(n.Rentail_Detail.ReturnDate)).ToString("dd/MM/yyyy"):"-",
                        Price = decimal.Parse(n.Rentail_Detail.OwnedMoney.ToString())
                    }).ToList();
                    return ls2;
                }
                return new List<reportDisk>();
            }
        }
    }
}
