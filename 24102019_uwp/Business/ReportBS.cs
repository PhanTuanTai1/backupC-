using _24102019_uwp.Data;
using _24102019_uwp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Business
{
    public class ReportBS
    {
        public List<CustomCustomer> getAll()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {

                return db.Customers.Select(n => new CustomCustomer()
                {
                    Address = "asd",
                    DiskOverdue = "asd",
                    ID = "asd",
                    LateFees = "asd",
                    Name = n.Name,
                    TotalDisk = 500
                }).ToList();
            }
        }
    }
}
