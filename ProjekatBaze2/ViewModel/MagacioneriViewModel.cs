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
    public class MagacioneriViewModel : BindableBase
    {
        public ICommand AddMagacionerCommand { get; set; }
        public ICommand EditMagacionerCommand { get; set; }
        public ICommand RemoveMagacionerCommand { get; set; }
        public static ObservableCollection<Radnik> Magacioneri { get; set; }
        public Magacioner SelectedMagacioner { get; set; }

        public static RadnikDAO radnikDAO = new RadnikDAO();

        public MagacioneriViewModel()
        {
            Magacioneri = new ObservableCollection<Radnik>(radnikDAO.GetMagacionere());
            AddMagacionerCommand = new MyICommand(AddMagacioner);
            EditMagacionerCommand = new MyICommand(EditMagacioner, CanEditRemoveMagacioner);
            RemoveMagacionerCommand = new MyICommand(RemoveMagacioner, CanEditRemoveMagacioner);
        }

        private void AddMagacioner()
        {
            var s = new AddEditMagacionerView();
            s.DataContext = new AddEditMagacionerViewModel();
            s.ShowDialog();
        }

        private void EditMagacioner()
        {
            var s = new AddEditMagacionerView();
            s.DataContext = new AddEditMagacionerViewModel(SelectedMagacioner);
            s.ShowDialog();
        }

        private bool CanEditRemoveMagacioner()
        {
            return SelectedMagacioner == null ? false : true;

        }

        private void RemoveMagacioner()
        {
            if (SelectedMagacioner != null)
            {
                if (radnikDAO.DeleteRadnik(SelectedMagacioner.JMBG))
                {
                    MessageBox.Show(string.Format("Magacioner {0} obrisan.", SelectedMagacioner.Ime));
                    Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Magacioner {0} nije obrisan..", SelectedMagacioner.Ime));
                }
            }

        }

        public static void Refresh()
        {
            if (Magacioneri != null)
            {
                Magacioneri.Clear();
                foreach (Magacioner ma in radnikDAO.GetMagacionere())
                {
                    Magacioneri.Add(ma);
                }
            }
        }
    }
}
