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
    public class AddEditOdrzavateljViewModel : BindableBase
    {
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private double zarada;
        private string brojOdrzavanihPrekrupaca;
        private Odrzavatelj odrzavatelj;
        private bool editMode;
        public RadnikDAO radnikDAO = new RadnikDAO();
        public ICommand SaveOdrzavateljCommand { get; set; }

        public AddEditOdrzavateljViewModel()
        {
            SaveOdrzavateljCommand = new MyICommand(SaveOdrzavatelj, CanSaveOdrzavatelj);
            ime = string.Empty;
            prezime = string.Empty;
            datumRodjenja = DateTime.Now;
            zarada = 0;
            brojOdrzavanihPrekrupaca = string.Empty;
            odrzavatelj = new Odrzavatelj();
            odrzavatelj.TrenutnoZauzet = false;

            editMode = false;
        }

        public AddEditOdrzavateljViewModel(Odrzavatelj pr)
        {
            SaveOdrzavateljCommand = new MyICommand(SaveOdrzavatelj, CanSaveOdrzavatelj);
            this.odrzavatelj = pr;
            Ime = pr.Ime;
            Prezime = pr.Prezime;
            DatumRodjenja = pr.DatumRodjenja;
            Zarada = pr.Zarada;
            BrojOdrzavanihPrekrupaca = pr.BrojOdrzavanihPrekrupaca;
            editMode = true;
        }

        private bool CanSaveOdrzavatelj()
        {
            return !string.IsNullOrEmpty(Ime) && !string.IsNullOrEmpty(Prezime) && Zarada != 0 && !string.IsNullOrEmpty(BrojOdrzavanihPrekrupaca);
        }

        private void SaveOdrzavatelj()
        {
            odrzavatelj.Ime = Ime;
            odrzavatelj.Prezime = Prezime;
            odrzavatelj.DatumRodjenja = DatumRodjenja.Date;
            odrzavatelj.Zarada = Zarada;
            odrzavatelj.BrojOdrzavanihPrekrupaca = BrojOdrzavanihPrekrupaca;
            odrzavatelj.TrenutnoZauzet = true;

            if (!editMode)
            {
                if (!radnikDAO.InsertOdrzavatelj(odrzavatelj))
                {
                    MessageBox.Show(string.Format("Odrzavatelj not added."));
                    return;
                }
                MessageBox.Show(string.Format("Odrzavatelj added."));
                Ime = string.Empty;
                Prezime = string.Empty;
                DatumRodjenja = DateTime.Now;
                Zarada = 0;
                BrojOdrzavanihPrekrupaca = string.Empty;
            }
            else
            {
                if (!radnikDAO.UpdateOdrzavatelj(odrzavatelj))
                {
                    MessageBox.Show(string.Format("Odrzavatelj not updated."));
                    return;
                }
                MessageBox.Show(string.Format("Odrzavatelj updated."));
            }

            OdrzavateljiViewModel.Refresh();
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

        public string BrojOdrzavanihPrekrupaca
        {
            get
            {
                return brojOdrzavanihPrekrupaca;
            }
            set
            {
                brojOdrzavanihPrekrupaca = value;
                OnPropertyChanged("BrojOdrzavanihPrekrupaca");
            }
        }
    }
}
