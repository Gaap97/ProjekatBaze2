using ProjekatBaze2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.DAO
{
    public class SkladisteDAO
    {
        public Skladiste FindById(int id)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Skladistes.Find(id);
            }
        }


        public List<Skladiste> GetListSkladiste()
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Skladistes.ToList();
            }
        }

        public bool Insert(Skladiste skladiste)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Skladiste ps = db.Skladistes.Find(skladiste.IdSkladista);
                if (ps == null)
                {
                    db.Skladistes.Add(skladiste);
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
                Skladiste skladiste = db.Skladistes.Find(id);

                if (skladiste != null)
                {
                    db.Entry(skladiste).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Update(Skladiste skladiste)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Skladiste ps = db.Skladistes.Find(skladiste.IdSkladista);
                if (ps != null)
                {
                    ps.KapacitetSkladista = skladiste.KapacitetSkladista;

                    db.Entry(ps).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
