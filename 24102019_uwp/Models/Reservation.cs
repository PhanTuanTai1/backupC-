using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResID { get; set; }

        public int CusID { get; set; }

        public int TitleID { get; set; }

        public short Status { get; set; }

        public bool Deleted { get; set; }

        public DateTime StartResDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Title Title { get; set; }
    }
}
