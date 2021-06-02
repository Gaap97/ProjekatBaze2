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
    public class PrevozniciViewModel : BindableBase
    {
        public ICommand AddPrevoznikCommand { get; set; }
        public ICommand EditPrevoznikCommand { get; set; }
        public ICommand RemovePrevoznikCommand { get; set; }
        public static ObservableCollection<Radnik> Prevoznici { get; set; }
        public Prevoznik SelectedPrevoznik { get; set; }

        public static RadnikDAO radnikDAO = new RadnikDAO();

        public PrevozniciViewModel()
        {
            Prevoznici = new ObservableCollection<Radnik>(radnikDAO.GetPrevoznike());
            AddPrevoznikCommand = new MyICommand(AddPrevoznik);
            EditPrevoznikCommand = new MyICommand(EditPrevoznik, CanEditRemovePrevoznik);
            RemovePrevoznikCommand = new MyICommand(RemovePrevoznik, CanEditRemovePrevoznik);
        }

        private void AddPrevoznik()
        {
            var s = new AddEditPrevoznikView();
            s.DataContext = new AddEditPrevoznikViewModel();
            s.ShowDialog();
        }

        private void EditPrevoznik()
        {
            var s = new AddEditPrevoznikView();
            s.DataContext = new AddEditPrevoznikViewModel(SelectedPrevoznik);
            s.ShowDialog();
        }

        private bool CanEditRemovePrevoznik()
        {
            return SelectedPrevoznik == null ? false : true;

        }

        private void RemovePrevoznik()
        {
            if (SelectedPrevoznik != null)
            {
                if (radnikDAO.DeleteRadnik(SelectedPrevoznik.JMBG))
                {
                    MessageBox.Show(string.Format("Prevoznik {0} obrisan.", SelectedPrevoznik.Ime));
                    Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Prevoznik {0} nije obrisan..", SelectedPrevoznik.Ime));
                }
            }

        }

        public static void Refresh()
        {
            if (Prevoznici != null)
            {
                Prevoznici.Clear();
                foreach (Prevoznik pr in radnikDAO.GetPrevoznike())
                {
                    Prevoznici.Add(pr);
                }
            }
        }
    }
}
