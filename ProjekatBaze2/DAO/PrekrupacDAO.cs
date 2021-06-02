using ProjekatBaze2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.DAO
{
    public class PrekrupacDAO
    {
        public Prekrupac FindById(int id)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Prekrupacs.Find(id);
            }
        }


        public List<Prekrupac> GetListPrekrupac()
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Prekrupacs.ToList();
            }
        }

        public bool Insert(Prekrupac prekrupac)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Prekrupac ps = db.Prekrupacs.Find(prekrupac.IdPrekrupaca);
                if (ps == null)
                {
                    db.Prekrupacs.Add(prekrupac);
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
                Prekrupac prekrupac = db.Prekrupacs.Find(id);

                if (prekrupac != null)
                {
                    db.Entry(prekrupac).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Update(Prekrupac prekrupac)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Prekrupac ps = db.Prekrupacs.Find(prekrupac.IdPrekrupaca);
                if (ps != null)
                {
                    ps.KapacitetPrekrupaca = prekrupac.KapacitetPrekrupaca;

                    db.Entry(ps).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
