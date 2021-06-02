using ProjekatBaze2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.DAO
{
    public class SilosDAO
    {
        public Silos FindById(int id)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Silos.Find(id);
            }
        }


        public List<Silos> GetListSilos()
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Silos.ToList();
            }
        }

        public bool Insert(Silos silos)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Silos ps = db.Silos.Find(silos.IdSilosa);
                if (ps == null)
                {
                    db.Silos.Add(silos);
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
                Silos silos = db.Silos.Find(id);

                if (silos != null)
                {
                    db.Entry(silos).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Update(Silos silos)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Silos ps = db.Silos.Find(silos.IdSilosa);
                if (ps != null)
                {
                    ps.KapacitetSilosa = silos.KapacitetSilosa;

                    db.Entry(ps).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
