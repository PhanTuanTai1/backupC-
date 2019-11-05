using _24102019_uwp.Data;
using _24102019_uwp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Business
{
    public class PayLateChargeBS
    {
        public bool HaveLateCharge(int cusID)
        {
            using(var db = new ApplicationDBContext())
            {
                var count = db.Rentals.Where(p => p.CusID == cusID && p.Status != (short)RentalInformation.RentalStatus.COMPLETE).ToList().Count;

                if (count > 0) return true;
            }

            return false;
        }

        public List<DisplayPayLateCharge> GetDisplayPayLateChargesByCusID(int cusID)
        {
            var paylatecharges = new List<DisplayPayLateCharge>();

            using(var db = new ApplicationDBContext())
            {
                var rentals = db.Rentals.Where(p => p.CusID == cusID && p.Status != (short)RentalInformation.RentalStatus.COMPLETE);

                if (rentals.Count() <= 0) return null;

                foreach(var rent in rentals)
                {
                    var rentID = rent.RentalID;

                    var rentDetails = db.Rentail_Detail.Where(p => p.RentalID == rentID && p.OwnedMoney != null && p.OwnedMoney > 0);

                    foreach(var rentDetail in rentDetails)
                    {
                        var titleID = db.Disks.SingleOrDefault(p => p.DiskID == rentDetail.DiskID).TitleID;

                        var title = db.Titles.SingleOrDefault(p => p.TitleID == titleID);

                        var temp = ((DateTime)rentDetail.ReturnDate).Subtract((DateTime)rentDetail.DueDate).TotalDays;

                        var paylatecharge = new DisplayPayLateCharge()
                        {
                            DiskID = rentDetail.DiskID,
                            RentalID = rentDetail.RentalID,
                            dueDate = ((DateTime)rentDetail.DueDate).ToString("dd/MM/yyyy"),
                            returnDate = ((DateTime)rentDetail.ReturnDate).ToString("dd/MM/yyyy"),
                            totalLateDay = ((int)temp).ToString(),
                            Title = title.Name,
                            lateCharge = (decimal)rentDetail.OwnedMoney,
                            startRentDate = rent.StartRentDate.ToString("dd/MM/yyyy")
                        };

                        paylatecharges.Add(paylatecharge);
                    }
                }

                return paylatecharges;
            }
        }

        public decimal PayLateCharge(decimal money, List<DisplayPayLateCharge> displayPayLateCharges)
        {
            using(var db = new ApplicationDBContext())
            {
                foreach (var display in displayPayLateCharges)
                {
                    if (money - display.lateCharge >= 0)
                    {
                        var found = db.Rentail_Detail.SingleOrDefault(p => p.RentalID == display.RentalID && p.DiskID == display.DiskID);

                        if(found != null)
                        {
                            found.OwnedMoney = 0;
                            money -= display.lateCharge;
                        }
                    }

                    if (money <= 0) break;
                }

                foreach(var display in displayPayLateCharges)
                {
                    var rentID = display.RentalID;

                    var rentD = db.Rentail_Detail.Where(p => p.RentalID == rentID);

                    int count = 0;

                    foreach(var rent in rentD)
                    {
                        if (rent.OwnedMoney > 0 || rent.OwnedMoney == null) break;
                        count++;
                    }

                    if(count == rentD.ToList().Count)
                    {
                        var rental = db.Rentals.SingleOrDefault(p => p.RentalID == rentID);

                        if (rental != null) rental.Status = (short)RentalInformation.RentalStatus.COMPLETE;
                    }
                }

                db.SaveChanges();
            }

            return money;
        }

        public decimal CalcLateCharge(decimal money, List<DisplayPayLateCharge> displayPayLateCharges)
        {
            foreach (var display in displayPayLateCharges)
            {
                if (money - display.lateCharge >= 0)
                {
                    money -= display.lateCharge;
                }

                if (money <= 0) break;
            }

            return money;
        }

    }
}
