using _24102019_uwp.Data;
using _24102019_uwp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Business
{
    public class CustomerBS
    {
        public List<Customer> GetCustomers()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Customers.ToList();
            }
        }
        public bool AddCustomer(Customer c)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                db.Customers.Add(c);
                db.SaveChanges();
                return true;
            }           
        }
        public bool RemoveCustomer(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                db.Customers.SingleOrDefault(x => x.CusID == id).Deleted = true;
                db.SaveChanges();
                return true;
            }
        }
        public bool ModifyCustomer(Customer c)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                Customer temp = db.Customers.Single(x => x.CusID == c.CusID);
                temp.Name = c.Name;
                temp.Phone = c.Phone;
                temp.Address = c.Address;
                db.SaveChanges();
                return true;
            }

        }
        public bool CheckIDExists(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                if (db.Customers.SingleOrDefault(x => x.CusID == id) != null) return true;
                return false;
            }
        }
        public string getName(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                Customer c = db.Customers.SingleOrDefault(x => x.CusID == id);
                if (c != null) return c.Name;
                return "";
            }
        }
    }
}
