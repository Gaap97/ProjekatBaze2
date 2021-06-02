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
    public class AddEditPrevoznikViewModel : BindableBase
    {
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private double zarada;
        private double prosecanBrPrevoza;
        private Prevoznik prevoznik;
        private bool editMode;
        public RadnikDAO radnikDAO = new RadnikDAO();
        public ICommand SavePrevoznikCommand { get; set; }

        public AddEditPrevoznikViewModel()
        {
            SavePrevoznikCommand = new MyICommand(SavePrevoznik, CanSavePrevoznik);
            ime = string.Empty;
            prezime = string.Empty;
            datumRodjenja = DateTime.Now;
            zarada = 0;
            prosecanBrPrevoza = 0;
            prevoznik = new Prevoznik();

            editMode = false;
        }

        public AddEditPrevoznikViewModel(Prevoznik pr)
        {
            SavePrevoznikCommand = new MyICommand(SavePrevoznik, CanSavePrevoznik);
            this.prevoznik = pr;
            Ime = pr.Ime;
            Prezime = pr.Prezime;
            DatumRodjenja = pr.DatumRodjenja;
            Zarada = pr.Zarada;
            ProsecanBrPrevoza = pr.ProsecanBrPrevoza;
            editMode = true;
        }

        private bool CanSavePrevoznik()
        {
            return !string.IsNullOrEmpty(Ime) && !string.IsNullOrEmpty(Prezime) && Zarada != 0 && ProsecanBrPrevoza != 0;
        }

        private void SavePrevoznik()
        {
            prevoznik.Ime = Ime;
            prevoznik.Prezime = Prezime;
            prevoznik.DatumRodjenja = DatumRodjenja.Date;
            prevoznik.Zarada = Zarada;
            prevoznik.ProsecanBrPrevoza = ProsecanBrPrevoza;

            if (!editMode)
            {
                if (!radnikDAO.InsertPrevoznik(prevoznik))
                {
                    MessageBox.Show(string.Format("Prevoznik not added."));
                    return;
                }
                MessageBox.Show(string.Format("Prevoznik added."));
                Ime = string.Empty;
                Prezime = string.Empty;
                DatumRodjenja = DateTime.Now;
                Zarada = 0;
                ProsecanBrPrevoza = 0;
            }
            else
            {
                if (!radnikDAO.UpdatePrevoznik(prevoznik))
                {
                    MessageBox.Show(string.Format("Prevoznik not updated."));
                    return;
                }
                MessageBox.Show(string.Format("Prevoznik updated."));
            }

            PrevozniciViewModel.Refresh();
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

        public double ProsecanBrPrevoza
        {
            get
            {
                return prosecanBrPrevoza;
            }
            set
            {
                prosecanBrPrevoza = value;
                OnPropertyChanged("ProsecanBrPrevoza");
            }
        }
    }
}
