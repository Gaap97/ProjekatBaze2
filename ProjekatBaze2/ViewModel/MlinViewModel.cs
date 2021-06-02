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
    public class MlinViewModel : BindableBase
    {
        public ICommand AddMlinCommand { get; set; }
        public ICommand EditMlinCommand { get; set; }
        public ICommand RemoveMlinCommand { get; set; }
        public static ObservableCollection<Mlin> Mlinovi { get; set; }
        public Mlin SelectedMlin { get; set; }

        public static MlinDAO mlinDAO = new MlinDAO();

        public MlinViewModel()
        {
            Mlinovi = new ObservableCollection<Mlin>(mlinDAO.GetListPsenice());
            AddMlinCommand = new MyICommand(AddMlin);
            EditMlinCommand = new MyICommand(EditMlin, CanEditRemoveMlin);
            RemoveMlinCommand = new MyICommand(RemoveMlin, CanEditRemoveMlin);
        }

        private void AddMlin()
        {
            var s = new AddEditMlinView();
            s.DataContext = new AddEditMlinViewModel();
            s.ShowDialog();
        }

        private void EditMlin()
        {
            var s = new AddEditMlinView();
            s.DataContext = new AddEditMlinViewModel(SelectedMlin);
            s.ShowDialog();
        }

        private bool CanEditRemoveMlin()
        {
            return SelectedMlin == null ? false : true;

        }

        private void RemoveMlin()
        {
            if (SelectedMlin != null)
            {
                if (mlinDAO.Delete(SelectedMlin.IdMlina))
                {
                    MessageBox.Show(string.Format("Mlin sa id {0} obrisan.", SelectedMlin.IdMlina));
                    Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Mlin sa id {0} nije obrisan..", SelectedMlin.IdMlina));
                }
            }

        }

        public static void Refresh()
        {
            if (Mlinovi != null)
            {
                Mlinovi.Clear();
                foreach (Mlin ps in mlinDAO.GetListPsenice())
                {
                    Mlinovi.Add(ps);
                }
            }
        }
    }
}
