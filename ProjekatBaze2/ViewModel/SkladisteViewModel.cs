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
    public class SkladisteViewModel : BindableBase
    {
        public ICommand AddSkladisteCommand { get; set; }
        public ICommand EditSkladisteCommand { get; set; }
        public ICommand RemoveSkladisteCommand { get; set; }
        public static ObservableCollection<Skladiste> Skladista { get; set; }
        public Skladiste SelectedSkladiste { get; set; }

        public static SkladisteDAO skladisteDAO = new SkladisteDAO();

        public SkladisteViewModel()
        {
            Skladista = new ObservableCollection<Skladiste>(skladisteDAO.GetListSkladiste());
            AddSkladisteCommand = new MyICommand(AddSkladiste);
            EditSkladisteCommand = new MyICommand(EditSkladiste, CanEditRemoveSkladiste);
            RemoveSkladisteCommand = new MyICommand(RemoveSkladiste, CanEditRemoveSkladiste);
        }

        private void AddSkladiste()
        {
            var s = new AddEditSkladisteView();
            s.DataContext = new AddEditSkladisteViewModel();
            s.ShowDialog();
        }

        private void EditSkladiste()
        {
            var s = new AddEditSkladisteView();
            s.DataContext = new AddEditSkladisteViewModel(SelectedSkladiste);
            s.ShowDialog();
        }

        private bool CanEditRemoveSkladiste()
        {
            return SelectedSkladiste == null ? false : true;

        }

        private void RemoveSkladiste()
        {
            if (SelectedSkladiste != null)
            {
                if (skladisteDAO.Delete(SelectedSkladiste.IdSkladista))
                {
                    MessageBox.Show(string.Format("Skladiste sa id {0} obrisan.", SelectedSkladiste.IdSkladista));
                    Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Skladiste sa id {0} nije obrisan..", SelectedSkladiste.IdSkladista));
                }
            }

        }

        public static void Refresh()
        {
            if (Skladista != null)
            {
                Skladista.Clear();
                foreach (Skladiste ps in skladisteDAO.GetListSkladiste())
                {
                    Skladista.Add(ps);
                }
            }
        }
    }
}
