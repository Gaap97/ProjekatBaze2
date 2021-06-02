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
    public class PrekrupacViewModel : BindableBase
    {
        public ICommand AddPrekrupacCommand { get; set; }
        public ICommand EditPrekrupacCommand { get; set; }
        public ICommand RemovePrekrupacCommand { get; set; }
        public static ObservableCollection<Prekrupac> Prekrupaci { get; set; }
        public Prekrupac SelectedPrekrupac { get; set; }

        public static PrekrupacDAO prekrupacDAO = new PrekrupacDAO();

        public PrekrupacViewModel()
        {
            Prekrupaci = new ObservableCollection<Prekrupac>(prekrupacDAO.GetListPrekrupac());
            AddPrekrupacCommand = new MyICommand(AddPrekrupac);
            EditPrekrupacCommand = new MyICommand(EditPrekrupac, CanEditRemovePrekrupac);
            RemovePrekrupacCommand = new MyICommand(RemovePrekrupac, CanEditRemovePrekrupac);
        }

        private void AddPrekrupac()
        {
            var s = new AddEditPrekrupacView();
            s.DataContext = new AddEditPrekrupacViewModel();
            s.ShowDialog();
        }

        private void EditPrekrupac()
        {
            var s = new AddEditPrekrupacView();
            s.DataContext = new AddEditPrekrupacViewModel(SelectedPrekrupac);
            s.ShowDialog();
        }

        private bool CanEditRemovePrekrupac()
        {
            return SelectedPrekrupac == null ? false : true;

        }

        private void RemovePrekrupac()
        {
            if (SelectedPrekrupac != null)
            {
                if (prekrupacDAO.Delete(SelectedPrekrupac.IdPrekrupaca))
                {
                    MessageBox.Show(string.Format("Prekrupac sa id {0} obrisan.", SelectedPrekrupac.IdPrekrupaca));
                    Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Prekrupac sa id {0} nije obrisan..", SelectedPrekrupac.IdPrekrupaca));
                }
            }

        }

        public static void Refresh()
        {
            if (Prekrupaci != null)
            {
                Prekrupaci.Clear();
                foreach (Prekrupac ps in prekrupacDAO.GetListPrekrupac())
                {
                    Prekrupaci.Add(ps);
                }
            }
        }
    }
}
