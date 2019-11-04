using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Models
{
    public class Rental
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentalID { get; set; }

        public int CusID { get; set; }

        public DateTime StartRentDate { get; set; }

        public short Status { get; set; }

        public bool Deleted { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Rentail_Detail> Rentail_Detail { get; set; }
    }
}
