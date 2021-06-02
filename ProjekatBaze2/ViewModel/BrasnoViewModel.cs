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
    public class BrasnoViewModel : BindableBase
    {
        public ICommand AddBrasnoCommand { get; set; }
        public ICommand EditBrasnoCommand { get; set; }
        public ICommand RemoveBrasnoCommand { get; set; }
        public static ObservableCollection<Brasno> Brasna { get; set; }
        public Brasno SelectedBrasno { get; set; }

        public static BrasnoDAO brasnoDAO = new BrasnoDAO();

        public BrasnoViewModel()
        {
            Brasna = new ObservableCollection<Brasno>(brasnoDAO.GetListBrasna());
            AddBrasnoCommand = new MyICommand(AddBrasno);
            EditBrasnoCommand = new MyICommand(EditBrasno, CanEditRemoveBrasno);
            RemoveBrasnoCommand = new MyICommand(RemoveBrasno, CanEditRemoveBrasno);
        }

        private void AddBrasno()
        {
            var s = new AddEditBrasnoView();
            s.DataContext = new AddEditBrasnoViewModel();
            s.ShowDialog();
        }

        private void EditBrasno()
        {
            var s = new AddEditBrasnoView();
            s.DataContext = new AddEditBrasnoViewModel(SelectedBrasno);
            s.ShowDialog();
        }

        private bool CanEditRemoveBrasno()
        {
            return SelectedBrasno == null ? false : true;

        }

        private void RemoveBrasno()
        {
            if (SelectedBrasno != null)
            {
                if (brasnoDAO.Delete(SelectedBrasno.IdBrasna))
                {
                    MessageBox.Show(string.Format("Brasno sa id {0} obrisan.", SelectedBrasno.IdBrasna));
                    Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Brasno sa id {0} nije obrisan..", SelectedBrasno.IdBrasna));
                }
            }

        }

        public static void Refresh()
        {
            if (Brasna != null)
            {
                Brasna.Clear();
                foreach (Brasno ps in brasnoDAO.GetListBrasna())
                {
                    Brasna.Add(ps);
                }
            }
        }
    }
}
