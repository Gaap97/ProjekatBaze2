using ProjekatBaze2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze2.DAO
{
    public class RadnikDAO
    {
        public Radnik FindByJmbg(int jmbg)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Radniks.Find(jmbg);
            }
        }

        public List<Radnik> GetListRadniks()
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return db.Radniks.ToList();
            }
        }

        public List<Radnik> FindByName(string name)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                return (from rad in db.Radniks
                        where SqlMethods.Like(rad.Ime, "%" + name + "%")
                        select rad).ToList();
            }
        }

        public ObservableCollection<Radnik> GetPrijemnike()
        {
            ObservableCollection<Radnik> prijemnici = new ObservableCollection<Radnik>();

            using (var db = new PoljoprivrednaFirmaContainer())
            {
                foreach (Radnik r in db.Radniks)
                {
                    if (r is Prijemnik)
                        prijemnici.Add(r);
                }
            }

            return prijemnici;
        }

        public ObservableCollection<Radnik> GetPrevoznike()
        {
            ObservableCollection<Radnik> prijemnici = new ObservableCollection<Radnik>();

            using (var db = new PoljoprivrednaFirmaContainer())
            {
                foreach (Radnik r in db.Radniks)
                {
                    if (r is Prevoznik)
                        prijemnici.Add(r);
                }
            }

            return prijemnici;
        }

        public ObservableCollection<Radnik> GetOdrzavatelje()
        {
            ObservableCollection<Radnik> prijemnici = new ObservableCollection<Radnik>();

            using (var db = new PoljoprivrednaFirmaContainer())
            {
                foreach (Radnik r in db.Radniks)
                {
                    if (r is Odrzavatelj)
                        prijemnici.Add(r);
                }
            }

            return prijemnici;
        }

        public ObservableCollection<Radnik> GetMagacionere()
        {
            ObservableCollection<Radnik> prijemnici = new ObservableCollection<Radnik>();

            using (var db = new PoljoprivrednaFirmaContainer())
            {
                foreach (Radnik r in db.Radniks)
                {
                    if (r is Magacioner)
                        prijemnici.Add(r);
                }
            }

            return prijemnici;
        }

        public bool InsertPrijemnik(Prijemnik prijemnik)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Prijemnik pr = (Prijemnik)db.Radniks.Find(prijemnik.JMBG);
                if (pr == null)
                {
                    db.Radniks.Add(prijemnik);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool InsertOdrzavatelj(Odrzavatelj odrzavatelj)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Odrzavatelj od = (Odrzavatelj)db.Radniks.Find(odrzavatelj.JMBG);
                if (od == null)
                {
                    db.Radniks.Add(odrzavatelj);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool InsertPrevoznik(Prevoznik prevoznik)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Prevoznik pz = (Prevoznik)db.Radniks.Find(prevoznik.JMBG);
                if (pz == null)
                {
                    db.Radniks.Add(prevoznik);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool InsertMagacioner(Magacioner magacioner)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Magacioner ma = (Magacioner)db.Radniks.Find(magacioner.JMBG);
                if (ma == null)
                {
                    db.Radniks.Add(magacioner);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool UpdatePrijemnik(Prijemnik prijemnik)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Prijemnik pr = (Prijemnik)db.Radniks.Find(prijemnik.JMBG);
                if (pr != null)
                {
                    pr.JMBG = prijemnik.JMBG;
                    pr.Ime = prijemnik.Ime;
                    pr.Prezime = prijemnik.Prezime;
                    pr.DatumRodjenja = prijemnik.DatumRodjenja;
                    pr.Zarada = prijemnik.Zarada;
                    pr.ProsecanBrPrijema = prijemnik.ProsecanBrPrijema;

                    db.Entry(pr).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public bool UpdatePrevoznik(Prevoznik prevoznik)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Prevoznik pr = (Prevoznik)db.Radniks.Find(prevoznik.JMBG);
                if (pr != null)
                {
                    pr.JMBG = prevoznik.JMBG;
                    pr.Ime = prevoznik.Ime;
                    pr.Prezime = prevoznik.Prezime;
                    pr.DatumRodjenja = prevoznik.DatumRodjenja;
                    pr.Zarada = prevoznik.Zarada;
                    pr.ProsecanBrPrevoza = prevoznik.ProsecanBrPrevoza;

                    db.Entry(pr).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public bool UpdateMagacioner(Magacioner magacioner)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Magacioner ma = (Magacioner)db.Radniks.Find(magacioner.JMBG);
                if (ma != null)
                {
                    ma.JMBG = magacioner.JMBG;
                    ma.Ime = magacioner.Ime;
                    ma.Prezime = magacioner.Prezime;
                    ma.DatumRodjenja = magacioner.DatumRodjenja;
                    ma.Zarada = magacioner.Zarada;
                    ma.ProsecanBrUzimanja = magacioner.ProsecanBrUzimanja;

                    db.Entry(ma).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public bool UpdateOdrzavatelj(Odrzavatelj odrzavatelj)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                Odrzavatelj od = (Odrzavatelj)db.Radniks.Find(odrzavatelj.JMBG);
                if (od != null)
                {
                    od.JMBG = odrzavatelj.JMBG;
                    od.Ime = odrzavatelj.Ime;
                    od.Prezime = odrzavatelj.Prezime;
                    od.DatumRodjenja = odrzavatelj.DatumRodjenja;
                    od.Zarada = odrzavatelj.Zarada;
                    od.BrojOdrzavanihPrekrupaca = odrzavatelj.BrojOdrzavanihPrekrupaca;
                    od.TrenutnoZauzet = odrzavatelj.TrenutnoZauzet;

                    db.Entry(od).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public bool DeleteRadnik(int jmbg)
        {
            using (var db = new PoljoprivrednaFirmaContainer())
            {
                var retval = from r in db.Radniks
                             where r.JMBG == jmbg
                             select r;

                Radnik radnik = retval.ToList().First();

                if (radnik != null)
                {
                    db.Radniks.Remove(radnik);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
