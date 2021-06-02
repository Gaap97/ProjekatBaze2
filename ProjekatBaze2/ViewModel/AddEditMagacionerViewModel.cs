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
    public class AddEditMagacionerViewModel : BindableBase
    {
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private double zarada;
        private string prosecanBrUzimanja;
        private Magacioner magacioner;
        private bool editMode;
        public RadnikDAO radnikDAO = new RadnikDAO();
        public ICommand SaveMagacionerCommand { get; set; }

        public AddEditMagacionerViewModel()
        {
            SaveMagacionerCommand = new MyICommand(SaveMagacioner, CanSaveMagacioner);
            ime = string.Empty;
            prezime = string.Empty;
            datumRodjenja = DateTime.Now;
            zarada = 0;
            prosecanBrUzimanja = string.Empty;
            magacioner = new Magacioner();

            editMode = false;
        }

        public AddEditMagacionerViewModel(Magacioner ma)
        {
            SaveMagacionerCommand = new MyICommand(SaveMagacioner, CanSaveMagacioner);
            this.magacioner = ma;
            Ime = ma.Ime;
            Prezime = ma.Prezime;
            DatumRodjenja = ma.DatumRodjenja;
            Zarada = ma.Zarada;
            ProsecanBrUzimanja = ma.ProsecanBrUzimanja;
            editMode = true;
        }

        private bool CanSaveMagacioner()
        {
            return !string.IsNullOrEmpty(Ime) && !string.IsNullOrEmpty(Prezime) && Zarada != 0 && !string.IsNullOrEmpty(ProsecanBrUzimanja);
        }

        private void SaveMagacioner()
        {
            magacioner.Ime = Ime;
            magacioner.Prezime = Prezime;
            magacioner.DatumRodjenja = DatumRodjenja.Date;
            magacioner.Zarada = Zarada;
            magacioner.ProsecanBrUzimanja = ProsecanBrUzimanja;

            if (!editMode)
            {
                if (!radnikDAO.InsertMagacioner(magacioner))
                {
                    MessageBox.Show(string.Format("Magacioner not added."));
                    return;
                }
                MessageBox.Show(string.Format("Magacioner added."));
                Ime = string.Empty;
                Prezime = string.Empty;
                DatumRodjenja = DateTime.Now;
                Zarada = 0;
                prosecanBrUzimanja = string.Empty;
            }
            else
            {
                if (!radnikDAO.UpdateMagacioner(magacioner))
                {
                    MessageBox.Show(string.Format("Magacioner not updated."));
                    return;
                }
                MessageBox.Show(string.Format("Magacioner updated."));
            }

            MagacioneriViewModel.Refresh();
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

        public string ProsecanBrUzimanja
        {
            get
            {
                return prosecanBrUzimanja;
            }
            set
            {
                prosecanBrUzimanja = value;
                OnPropertyChanged("ProsecanBrUzimanja");
            }
        }
    }
}
