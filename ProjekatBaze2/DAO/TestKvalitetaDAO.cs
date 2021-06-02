using ProjekatBaze2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.DAO
{
    public class TestKvalitetaDAO
    {
        public TestKvaliteta FindById(int id)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.TestKvalitetas.Find(id);
            }
        }


        public List<TestKvaliteta> GetListTestovi()
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.TestKvalitetas.ToList();
            }
        }

        public bool Insert(TestKvaliteta testKvaliteta)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                TestKvaliteta ps = db.TestKvalitetas.Find(testKvaliteta.IdTesta);
                if (ps == null)
                {
                    db.TestKvalitetas.Add(testKvaliteta);
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
                TestKvaliteta testKvaliteta = db.TestKvalitetas.Find(id);

                if (testKvaliteta != null)
                {
                    db.Entry(testKvaliteta).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Update(TestKvaliteta testKvaliteta)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                TestKvaliteta ps = db.TestKvalitetas.Find(testKvaliteta.IdTesta);
                if (ps != null)
                {
                    ps.KapacitetTestera = testKvaliteta.KapacitetTestera;

                    db.Entry(ps).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
