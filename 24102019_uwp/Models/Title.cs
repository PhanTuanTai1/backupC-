using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Models
{
    public class Title
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TitleID { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public bool Deleted { get; set; }

        public int TypeID { get; set; }

        public virtual ICollection<Disk> Disks { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual Type Type { get; set; }
    }
}
