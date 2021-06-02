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
    public class KamionViewModel : BindableBase
    {
        public ICommand AddKamionCommand { get; set; }
        public ICommand EditKamionCommand { get; set; }
        public ICommand RemoveKamionCommand { get; set; }
        public static ObservableCollection<Kamion> Kamioni { get; set; }
        public Kamion SelectedKamion { get; set; }

        public static KamionDAO kamionDAO = new KamionDAO();

        public KamionViewModel()
        {
            Kamioni = new ObservableCollection<Kamion>(kamionDAO.GetListKamion());
            AddKamionCommand = new MyICommand(AddKamion);
            EditKamionCommand = new MyICommand(EditKamion, CanEditRemoveKamion);
            RemoveKamionCommand = new MyICommand(RemoveKamion, CanEditRemoveKamion);
        }

        private void AddKamion()
        {
            var s = new AddEditKamionView();
            s.DataContext = new AddEditKamionViewModel();
            s.ShowDialog();
        }

        private void EditKamion()
        {
            var s = new AddEditKamionView();
            s.DataContext = new AddEditKamionViewModel(SelectedKamion);
            s.ShowDialog();
        }

        private bool CanEditRemoveKamion()
        {
            return SelectedKamion == null ? false : true;

        }

        private void RemoveKamion()
        {
            if (SelectedKamion != null)
            {
                if (kamionDAO.Delete(SelectedKamion.IdKamiona))
                {
                    MessageBox.Show(string.Format("Kamion sa id {0} obrisan.", SelectedKamion.IdKamiona));
                    Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Kamion sa id {0} nije obrisan..", SelectedKamion.IdKamiona));
                }
            }

        }

        public static void Refresh()
        {
            if (Kamioni != null)
            {
                Kamioni.Clear();
                foreach (Kamion ps in kamionDAO.GetListKamion())
                {
                    Kamioni.Add(ps);
                }
            }
        }
    }
}
