using _24102019_uwp.Data;
using _24102019_uwp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Business
{
    public class TypeBS
    {
        public List<Models.Type> getTypes()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Types.ToList();
            }
        }
        public bool AddType(Models.Type t)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                db.Types.Add(t);
                db.SaveChanges();
                return true;
            }
        }
        public bool RemoveType(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //db.Types.SingleOrDefault(x => x.TypeID == id).Deleted = true;
                db.SaveChanges();
                return true;
            }
        }
        public bool ModifyType(Models.Type t)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                Models.Type temp = db.Types.Single(x => x.TypeID == t.TypeID);
                temp.RentCharge = t.RentCharge;
                temp.RentPeriod = t.RentPeriod;
                temp.TypeName = t.TypeName;
                db.SaveChanges();
                return true;
            }

        }
        public bool CheckIDExists(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                if (db.Types.SingleOrDefault(x => x.TypeID == id) != null) return true;
                return false;
            }
        }
        public string getName(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                Models.Type c = db.Types.SingleOrDefault(x => x.TypeID == id);
                if (c != null) return c.TypeName;
                return "";
            }
        }
    }
}
