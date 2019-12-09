using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Models
{
    public class DisplayPayLateCharge
    {
        public int RentalID { get; set; }
        public int DiskID { get; set; }

        public string Title { get; set; }
        public string Name { get; set; }
        public string startRentDate { get; set; }
        public string dueDate { get; set; }
        public string returnDate { get; set; }
        public string totalLateDay { get; set; }
        public decimal lateCharge { get; set; }
        public string paid { get; set; }
    }
}
