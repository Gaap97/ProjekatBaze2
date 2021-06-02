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
    public class SilosViewModel : BindableBase
    {
        public ICommand AddSilosCommand { get; set; }
        public ICommand EditSilosCommand { get; set; }
        public ICommand RemoveSilosCommand { get; set; }
        public static ObservableCollection<Silos> Silosi { get; set; }
        public Silos SelectedSilos { get; set; }

        public static SilosDAO silosDAO = new SilosDAO();

        public SilosViewModel()
        {
            Silosi = new ObservableCollection<Silos>(silosDAO.GetListSilos());
            AddSilosCommand = new MyICommand(AddSilos);
            EditSilosCommand = new MyICommand(EditSilos, CanEditRemoveSilos);
            RemoveSilosCommand = new MyICommand(RemoveSilos, CanEditRemoveSilos);
        }

        private void AddSilos()
        {
            var s = new AddEditSilosView();
            s.DataContext = new AddEditSilosViewModel();
            s.ShowDialog();
        }

        private void EditSilos()
        {
            var s = new AddEditSilosView();
            s.DataContext = new AddEditSilosViewModel(SelectedSilos);
            s.ShowDialog();
        }

        private bool CanEditRemoveSilos()
        {
            return SelectedSilos == null ? false : true;

        }

        private void RemoveSilos()
        {
            if (SelectedSilos != null)
            {
                if (silosDAO.Delete(SelectedSilos.IdSilosa))
                {
                    MessageBox.Show(string.Format("Silos sa id {0} obrisan.", SelectedSilos.IdSilosa));
                    Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Silos sa id {0} nije obrisan..", SelectedSilos.IdSilosa));
                }
            }

        }

        public static void Refresh()
        {
            if (Silosi != null)
            {
                Silosi.Clear();
                foreach (Silos ps in silosDAO.GetListSilos())
                {
                    Silosi.Add(ps);
                }
            }
        }
    }
}
