using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Models
{
    public class Type
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeName { get; set; }

        [Column(TypeName = "money")]
        public decimal RentCharge { get; set; }

        public short RentPeriod { get; set; }

        public virtual ICollection<Title> Titles { get; set; }
    }
}
