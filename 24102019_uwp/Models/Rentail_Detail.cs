using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Models
{
    public class Rentail_Detail
    {
        public int RentalID { get; set; }

        public int DiskID { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? OwnedMoney { get; set; }

        public bool? Deleted { get; set; }

        public bool Paid { get; set; }

        public virtual Disk Disk { get; set; }

        public virtual Rental Rental { get; set; }
    }
}
