using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Models
{
    public class Disk
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DiskID { get; set; }

        public short ChkOutStatus { get; set; }

        public int TitleID { get; set; }

        public bool Deleted { get; set; }

        public virtual ICollection<Rentail_Detail> Rentail_Detail { get; set; }

        public virtual Title Title { get; set; }
    }
}
