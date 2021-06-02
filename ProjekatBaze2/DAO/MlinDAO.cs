using ProjekatBaze2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.DAO
{
    public class MlinDAO
    {
        public Mlin FindById(int id)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Mlins.Find(id);
            }
        }


        public List<Mlin> GetListPsenice()
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Mlins.ToList();
            }
        }

        public bool Insert(Mlin mlin)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Mlin ps = db.Mlins.Find(mlin.IdMlina);
                if (ps == null)
                {
                    db.Mlins.Add(mlin);
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
                Mlin mlin = db.Mlins.Find(id);

                if (mlin != null)
                {
                    db.Entry(mlin).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Update(Mlin mlin)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Mlin ps = db.Mlins.Find(mlin.IdMlina);
                if (ps != null)
                {
                    ps.NazivMlina = mlin.NazivMlina;
                    ps.VlasnikMlina = mlin.VlasnikMlina;

                    db.Entry(ps).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
