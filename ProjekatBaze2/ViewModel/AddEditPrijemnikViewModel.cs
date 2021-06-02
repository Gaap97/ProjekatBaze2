using ProjekatBaze2.DAO;
using ProjekatBaze2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjekatBaze2.ViewModel
{
    public class AddEditPrijemnikViewModel : BindableBase
    {
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private double zarada;
        private double prosecanBrPrijema;
        private Prijemnik prijemnik;
        private bool editMode;
        public RadnikDAO radnikDAO = new RadnikDAO();
        public ICommand SavePrijemnikCommand { get; set; }

        public AddEditPrijemnikViewModel()
        {
            SavePrijemnikCommand = new MyICommand(SavePrijemnik, CanSavePrijemnik);
            ime = string.Empty;
            prezime = string.Empty;
            datumRodjenja = DateTime.Now;
            zarada = 0;
            prosecanBrPrijema = 0;
            prijemnik = new Prijemnik();

            editMode = false;
        }

        public AddEditPrijemnikViewModel(Prijemnik pr)
        {
            SavePrijemnikCommand = new MyICommand(SavePrijemnik, CanSavePrijemnik);
            this.prijemnik = pr;
            Ime = pr.Ime;
            Prezime = pr.Prezime;
            DatumRodjenja = pr.DatumRodjenja;
            Zarada = pr.Zarada;
            ProsecanBrPrijema = pr.ProsecanBrPrijema;
            editMode = true;
        }

        private bool CanSavePrijemnik()
        {
            return !string.IsNullOrEmpty(Ime) && !string.IsNullOrEmpty(Prezime) && Zarada != 0 && ProsecanBrPrijema != 0;
        }

        private void SavePrijemnik()
        {
            prijemnik.Ime = Ime;
            prijemnik.Prezime = Prezime;
            prijemnik.DatumRodjenja = DatumRodjenja;
            prijemnik.Zarada = Zarada;
            prijemnik.ProsecanBrPrijema = ProsecanBrPrijema;

            if (!editMode)
            {
                if (!radnikDAO.InsertPrijemnik(prijemnik))
                {
                    MessageBox.Show(string.Format("Prijemnik not added."));
                    return;
                }
                MessageBox.Show(string.Format("Prijemnik added."));
                Ime = string.Empty;
                Prezime = string.Empty;
                DatumRodjenja = DateTime.Now;
                Zarada = 0;
                ProsecanBrPrijema = 0;
            }
            else
            {
                if (!radnikDAO.UpdatePrijemnik(prijemnik))
                {
                    MessageBox.Show(string.Format("Prijemnik not updated."));
                    return;
                }
                MessageBox.Show(string.Format("Prijemnik updated."));
            }

            PrijemniciViewModel.Refresh();
            RadniciViewModel.Refresh();
        }

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        public DateTime DatumRodjenja
        {
            get
            {
                return datumRodjenja;
            }
            set
            {
                datumRodjenja = value;
                OnPropertyChanged("DatumRodjenja");
            }
        }

        public double Zarada
        {
            get
            {
                return zarada;
            }
            set
            {
                zarada = value;
                OnPropertyChanged("Zarada");
            }
        }

        public double ProsecanBrPrijema
        {
            get
            {
                return prosecanBrPrijema;
            }
            set
            {
                prosecanBrPrijema = value;
                OnPropertyChanged("ProsecanBrPrijema");
            }
        }
    }
}
