using ProjekatBaze2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.DAO
{
    public class KamionDAO
    {
        public Kamion FindById(int id)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Kamions.Find(id);
            }
        }


        public List<Kamion> GetListKamion()
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Kamions.ToList();
            }
        }

        public bool Insert(Kamion kamion)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Kamion ps = db.Kamions.Find(kamion.IdKamiona);
                if (ps == null)
                {
                    db.Kamions.Add(kamion);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Kamion kamion = db.Kamions.Find(id);

                if (kamion != null)
                {
                    db.Entry(kamion).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Update(Kamion kamion)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Kamion ps = db.Kamions.Find(kamion.IdKamiona);
                if (ps != null)
                {
                    ps.KapacitetKamiona = kamion.KapacitetKamiona;

                    db.Entry(ps).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
