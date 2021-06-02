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
    public class PrijemniciViewModel : BindableBase
    {
        public ICommand AddPrijemnikCommand { get; set; }
        public ICommand EditPrijemnikCommand { get; set; }
        public ICommand RemovePrijemnikCommand { get; set; }
        public static ObservableCollection<Radnik> Prijemnici { get; set; }
        public Prijemnik SelectedPrijemnik { get; set; }

        public static RadnikDAO radnikDAO = new RadnikDAO();

        public PrijemniciViewModel()
        {
            Prijemnici = new ObservableCollection<Radnik>(radnikDAO.GetPrijemnike());
            AddPrijemnikCommand = new MyICommand(AddPrijemnik);
            EditPrijemnikCommand = new MyICommand(EditPrijemnik, CanEditRemovePrijemnik);
            RemovePrijemnikCommand = new MyICommand(RemovePrijemnik, CanEditRemovePrijemnik);
        }

        private void AddPrijemnik()
        {
            var s = new AddEditPrijemnikView();
            s.DataContext = new AddEditPrijemnikViewModel();
            s.ShowDialog();
        }

        private void EditPrijemnik()
        {
            var s = new AddEditPrijemnikView();
            s.DataContext = new AddEditPrijemnikViewModel(SelectedPrijemnik);
            s.ShowDialog();
        }

        private bool CanEditRemovePrijemnik()
        {
            return SelectedPrijemnik == null ? false : true;

        }

        private void RemovePrijemnik()
        {
            if (SelectedPrijemnik != null)
            {
                if (radnikDAO.DeleteRadnik(SelectedPrijemnik.JMBG))
                {
                    MessageBox.Show(string.Format("Prijemnik {0} obrisan.", SelectedPrijemnik.Ime));
                    Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Prijemnik {0} nije obrisan..", SelectedPrijemnik.Ime));
                }
            }

        }

        public static void Refresh()
        {
            if (Prijemnici != null)
            {
                Prijemnici.Clear();
                foreach (Prijemnik pr in radnikDAO.GetPrijemnike())
                {
                    Prijemnici.Add(pr);
                }
            }
        }
    }
}
