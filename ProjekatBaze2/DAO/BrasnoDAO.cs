using ProjekatBaze2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.DAO
{
    public class BrasnoDAO
    {
        public Brasno FindById(int id)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Brasnoes.Find(id);
            }
        }


        public List<Brasno> GetListBrasna()
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Brasnoes.ToList();
            }
        }

        public bool Insert(Brasno brasno)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Brasno ps = db.Brasnoes.Find(brasno.IdBrasna);
                if (ps == null)
                {
                    db.Brasnoes.Add(brasno);
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
                Brasno brasno = db.Brasnoes.Find(id);

                if (brasno != null)
                {
                    db.Entry(brasno).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Update(Brasno brasno)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Brasno ps = db.Brasnoes.Find(brasno.IdBrasna);
                if (ps != null)
                {
                    ps.KolicinaBrasna = brasno.KolicinaBrasna;

                    db.Entry(ps).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
