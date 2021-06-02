using ProjekatBaze2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.DAO
{
    public class PsenicaDAO
    {
        public Psenica FindById(int id)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Psenicas.Find(id);
            }
        }


        public List<Psenica> GetListPsenice()
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Psenicas.ToList();
            }
        }

        public bool Insert(Psenica psenica)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Psenica ps = db.Psenicas.Find(psenica.IdPsenice);
                if (ps == null)
                {
                    db.Psenicas.Add(psenica);
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
                Psenica psenica = db.Psenicas.Find(id);

                if (psenica != null)
                {
                    db.Entry(psenica).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Update(Psenica psenica)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Psenica ps = db.Psenicas.Find(psenica.IdPsenice);
                if (ps != null)
                {
                    ps.KolicinaPsenice = psenica.KolicinaPsenice;
                    ps.Kvalitet = psenica.Kvalitet;

                    db.Entry(ps).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }

}
