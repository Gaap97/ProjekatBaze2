using ProjekatBaze2.DAO;
using ProjekatBaze2.Model;
using ProjekatBaze2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjekatBaze2.ViewModel
{
    public class OdrzavateljiViewModel : BindableBase
    {
        public ICommand AddOdrzavateljCommand { get; set; }
        public ICommand EditOdrzavateljCommand { get; set; }
        public ICommand RemoveOdrzavateljCommand { get; set; }
        public static ObservableCollection<Radnik> Odrzavatelji { get; set; }
        public Odrzavatelj SelectedOdrzavatelj { get; set; }

        public static RadnikDAO radnikDAO = new RadnikDAO();

        public OdrzavateljiViewModel()
        {
            Odrzavatelji = new ObservableCollection<Radnik>(radnikDAO.GetOdrzavatelje());
            AddOdrzavateljCommand = new MyICommand(AddOdrzavatelj);
            EditOdrzavateljCommand = new MyICommand(EditOdrzavatelj, CanEditRemoveOdrzavatelj);
            RemoveOdrzavateljCommand = new MyICommand(RemoveOdrzavatelj, CanEditRemoveOdrzavatelj);
        }

        private void AddOdrzavatelj()
        {
            var s = new AddEditOdrzavateljView();
            s.DataContext = new AddEditOdrzavateljViewModel();
            s.ShowDialog();
        }

        private void EditOdrzavatelj()
        {
            var s = new AddEditOdrzavateljView();
            s.DataContext = new AddEditOdrzavateljViewModel(SelectedOdrzavatelj);
            s.ShowDialog();
        }

        private bool CanEditRemoveOdrzavatelj()
        {
            return SelectedOdrzavatelj == null ? false : true;

        }

        private void RemoveOdrzavatelj()
        {
            if (SelectedOdrzavatelj != null)
            {
                if (radnikDAO.DeleteRadnik(SelectedOdrzavatelj.JMBG))
                {
                    MessageBox.Show(string.Format("Odrzavatelj {0} obrisan.", SelectedOdrzavatelj.Ime));
                    Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Odrzavatelj {0} nije obrisan..", SelectedOdrzavatelj.Ime));
                }
            }

        }

        public static void Refresh()
        {
            if (Odrzavatelji != null)
            {
                Odrzavatelji.Clear();
                foreach (Odrzavatelj od in radnikDAO.GetOdrzavatelje())
                {
                    Odrzavatelji.Add(od);
                }
            }
        }
    }
}
