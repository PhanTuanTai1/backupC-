using _24102019_uwp.Data;
using _24102019_uwp.Models;
using _24102019_uwp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24102019_uwp.Business
{
    public class TitleBS
    {
        public List<customTitle> getTitles()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Titles.Select(n => new customTitle()
                {
                    Deleted = n.Deleted,
                    Description = n.Description,
                    IsAvailable = n.IsAvailable ? "Available" : "-",
                    Name = n.Name,
                    Price = n.Price,
                    TitleID = n.TitleID,
                    TypeName = db.Types.Single(m => m.TypeID == n.TypeID).TypeName
                }).ToList();
            }

        }
        public List<Title> getTitlesMain()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                return db.Titles.ToList();
            }
        }
        public bool AddTitle(Title t)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                db.Titles.Add(t);
                db.SaveChanges();
                return true;
            }
        }
        public bool RemoveTitle(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                db.Titles.SingleOrDefault(x => x.TitleID == id).Deleted = true;
                db.SaveChanges();
                return true;
            }
        }
        public bool ModifyTitle(Title t)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                Title temp = db.Titles.Single(x => x.TitleID == t.TitleID);
                temp.IsAvailable = t.IsAvailable;
                temp.Name = t.Name;
                temp.Price = t.Price;
                temp.TypeID = t.TypeID;
                temp.Deleted = t.Deleted;
                temp.Description = t.Description;
                db.SaveChanges();
                return true;
            }

        }
        public bool CheckIDExists(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                if (db.Titles.SingleOrDefault(x => x.TitleID == id) != null) return true;
                return false;
            }
        }
        public Title getTitle(int id)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                Title c = db.Titles.SingleOrDefault(x => x.TitleID == id);
                if (c != null) return null;
                return c;
            }
        }
    }
}
