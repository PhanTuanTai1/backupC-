﻿using _24102019_uwp.Data;
using _24102019_uwp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Business
{
    public class ReturnBS
    {
        public DetailReturnDisk Search(int diskID)
        {
            DetailReturnDisk detail;
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                CustomerBS c = new CustomerBS();
                Disk d = db.Disks.SingleOrDefault(x => x.DiskID == diskID && x.ChkOutStatus == (short)Checkout.DiskStatus.RENTED);
                if (d != null)
                {
                    var query = from rd1 in db.Rentail_Detail
                                join r1 in db.Rentals on rd1.RentalID equals r1.RentalID
                                where rd1.DiskID == diskID && r1.Status == (int)RentalInformation.RentalStatus.RENTED
                                select new
                                {
                                    rd1,
                                    r1
                                };
                    try
                    {
                        Rentail_Detail rd = (Rentail_Detail)query.FirstOrDefault().rd1;
                        Rental r = (Rental)query.FirstOrDefault().r1;
                        Title title = db.Titles.Single(x => x.TitleID == d.TitleID);
                        Models.Type t = db.Types.Single(x => x.TypeID == title.TypeID);
                        detail = new DetailReturnDisk(r.CusID, d.TitleID, d.DiskID, r.StartRentDate, (DateTime)rd.DueDate, DateTime.Now, c.getName(r.CusID), getTitleName(d.TitleID), t.RentCharge);
                        return detail;
                    }
                    catch
                    {
                        return null;
                    }
                    
                }
                return null;
            }
        }
        private string getTitleName(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                Title t = db.Titles.SingleOrDefault(x => x.TitleID == id);
                if (t != null) return t.Name;
                return "";
            }           
        }
        public bool ReturnDisk(int diskID,int cusID,decimal lateCharge,DateTime returnDate)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                Disk d = db.Disks.SingleOrDefault(x => x.DiskID == diskID);
                
                Rentail_Detail rd = db.Rentail_Detail.SingleOrDefault(x => x.DiskID == diskID && x.ReturnDate == null);
                Rental r = db.Rentals.SingleOrDefault(x => x.RentalID == rd.RentalID && x.Status == (int)RentalInformation.RentalStatus.RENTED);
                if (d != null && r != null && rd != null)
                {
                    d.ChkOutStatus = (short)Checkout.DiskStatus.SHELF;
                    rd.ReturnDate = returnDate;
                    AddLateCharge(diskID, r.RentalID, lateCharge);
                    db.SaveChanges();
                    using (ApplicationDBContext db2 = new ApplicationDBContext())
                    {
                        List<Rentail_Detail> lst = db2.Rentail_Detail.Where(x => x.RentalID == r.RentalID && x.ReturnDate == null).ToList();
                        List<Rentail_Detail> lstAll = db2.Rentail_Detail.Where(x => x.RentalID == r.RentalID).ToList();
                        decimal c = (decimal)lstAll.Sum(x => x.OwnedMoney);
                        if (lstAll.Sum(x => x.OwnedMoney) > 0)
                        {
                            r.Status = (int)RentalInformation.RentalStatus.RESERVATION;
                        }
                        else if (lst.Count == 0)
                        {
                            r.Status = (int)RentalInformation.RentalStatus.COMPLETE;
                        }
                        db.SaveChanges();
                        PlaceOnHold(diskID);
                        return true;
                    }                   
                }
                return false;
            }          
        }
        public void AddLateCharge(int diskID,int rentalID,decimal lateCharge)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                Rentail_Detail rd = db.Rentail_Detail.SingleOrDefault(x => x.DiskID == diskID && x.RentalID == rentalID);
                if(rd != null)
                {
                    rd.OwnedMoney = lateCharge;
                }
                db.SaveChanges();
            }
        }
        public void PlaceOnHold(int diskID)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                Disk d = db.Disks.SingleOrDefault(x => x.DiskID == diskID);
                if(d != null)
                {
                    List<Reservation> lstReservationByDiskID = db.Reservations.Where(x => x.TitleID == d.TitleID).ToList();
                    Reservation FirstReservation = lstReservationByDiskID.Where(x=>x.Status == (short)Checkout.ReservationStatus.WAITING && x.Deleted == false).OrderBy(x => x.StartResDate).FirstOrDefault();
                    if(FirstReservation != null)
                    {
                        d.ChkOutStatus = (short)Checkout.DiskStatus.ONHOLD;
                        FirstReservation.Status = (int)Checkout.ReservationStatus.HOLDING;
                        db.SaveChanges();                      
                    }
                }
            }
        }
    }
}
