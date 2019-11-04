using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Models
{
    public class DisplayReservation
    {
        public int resID { get; set; }
        public int cusID { get; set; }
        public string Title { get; set; }
        public string cusName { get; set; }
        public string cusPhone { get; set; }
        public DateTime startResDate { get; set; }
        public string status { get; set; }
    }
}
