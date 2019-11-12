using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Models
{
    public class Checkout
    {
        public enum CheckoutStatus
        {
            RENTED, SHELF
        }

        public enum DiskStatus
        {
            RENTED, SHELF, ONHOLD, INSTOCK
        }

        public enum ReservationStatus
        {
            WAITING, HOLDING, COMPLETE
        }
    }
}
