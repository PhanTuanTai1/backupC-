using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24102019_uwp.Models
{
    public class DetailReturnDisk
    {
        private int cusID;
        private int titleID;
        private int diskID;
        private DateTime startDate;
        private DateTime dueDate;
        private DateTime returnDate;
        private int totalDateLate;
        private decimal lateCharge;
        private string cusName;
        private string titleName;
        private decimal price;
        public int CusID { get => cusID; set => cusID = value; }
        public int TitleID { get => titleID; set => titleID = value; }
        public int DiskID { get => diskID; set => diskID = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }

        public decimal LateCharge { get => lateCharge; set => lateCharge = value; }
        public string CusName { get => cusName; set => cusName = value; }
        public string TitleName { get => titleName; set => titleName = value; }
        public decimal Price { get => price; set => price = value; }
        public int TotalDateLate { get => totalDateLate; set => totalDateLate = value; }

        public DetailReturnDisk() { }
        public DetailReturnDisk(int cusId,int titleId,int diskID, DateTime startDate, DateTime dueDate, DateTime returnDate, string cusName, string titleName, decimal price)
        {
            this.CusID = cusId;
            this.TitleID = titleId;
            this.DiskID = diskID;
            this.StartDate = startDate.Date;
            this.DueDate = dueDate.Date;
            this.ReturnDate = returnDate.Date;
            this.CusName = cusName;
            this.TitleName = titleName;
            this.Price = price;
            this.lateCharge = CalculateLateCharge();
            this.TotalDateLate = CalculateTotalDateLate();
        }
        private decimal CalculateLateCharge()
        {
            int TotalDateLate = CalculateTotalDateLate();
            return TotalDateLate * this.Price;
        }
        private int CalculateTotalDateLate()
        {
           if(ReturnDate > DueDate)
           {
                return this.ReturnDate.DayOfYear - this.DueDate.DayOfYear;
           }
            return 0;
        }

    }
}
