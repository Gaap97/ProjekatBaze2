using ProjekatBaze2.DAO;
using ProjekatBaze2.Model;
using ProjekatBaze2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjekatBaze2.ViewModel
{
    public class RadniciViewModel : BindableBase
    {
        public ICommand GoToPrijemniciCommand { get; set; }
        public ICommand GoToPrevozniciCommand { get; set; }
        public ICommand GoToOdrzavateljiCommand { get; set; }
        public ICommand GoToMagacioneriCommand { get; set; }
        public ICommand RefreshRadnikCommand { get; set; }
        public static ObservableCollection<Radnik> Radnici { get; set; }
        public Radnik SelectedRadnik { get; set; }

        public static RadnikDAO radnikDAO = new RadnikDAO();

        public RadniciViewModel()
        {
            Radnici = new ObservableCollection<Radnik>(radnikDAO.GetListRadniks());
            GoToPrijemniciCommand = new MyICommand(GoToPrijemnici);
            GoToPrevozniciCommand = new MyICommand(GoToPrevoznici);
            GoToOdrzavateljiCommand = new MyICommand(GoToOdrzavatelji);
            GoToMagacioneriCommand = new MyICommand(GoToMagacioneri);
            RefreshRadnikCommand = new MyICommand(RefreshRadnik);
        }

        private void GoToPrijemnici()
        {
            var s = new PrijemniciView();
            s.DataContext = new PrijemniciViewModel();
            s.ShowDialog();
        }

        private void GoToPrevoznici()
        {
            var s = new PrevozniciView();
            s.DataContext = new PrevozniciViewModel();
            s.ShowDialog();
        }

        private void GoToOdrzavatelji()
        {
            var s = new OdrzavateljiView();
            s.DataContext = new OdrzavateljiViewModel();
            s.ShowDialog();
        }

        private void GoToMagacioneri()
        {
            var s = new MagacioneriView();
            s.DataContext = new MagacioneriViewModel();
            s.ShowDialog();
        }

        private void RefreshRadnik()
        {
            Refresh();
        }

        public static void Refresh()
        {
            if (Radnici != null)
            {
                Radnici.Clear();
                foreach (Radnik r in radnikDAO.GetListRadniks())
                {
                    Radnici.Add(r);
                }
            }
        }
    }
}
