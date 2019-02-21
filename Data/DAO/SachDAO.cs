using Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public class SachDAO
    {
        private DBContext db = null;
        public SachDAO()
        {
            db = new DBContext();
        }
        public int Insert(Sach s)
        {
            try
            {
                db.Saches.Add(s);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public bool Edit(int id, Sach s)
        {
            try
            {
                var res = db.Saches.Find(id);
                res.TenSach = s.TenSach;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
            
            
    }
}
