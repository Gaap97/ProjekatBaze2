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
    public class TestKvalitetaViewModel : BindableBase
    {
        public ICommand AddTestKvalitetaCommand { get; set; }
        public ICommand EditTestKvalitetaCommand { get; set; }
        public ICommand RemoveTestKvalitetaCommand { get; set; }
        public static ObservableCollection<TestKvaliteta> Testovi { get; set; }
        public TestKvaliteta SelectedTestKvaliteta { get; set; }

        public static TestKvalitetaDAO testKvalitetaDAO = new TestKvalitetaDAO();

        public TestKvalitetaViewModel()
        {
            Testovi = new ObservableCollection<TestKvaliteta>(testKvalitetaDAO.GetListTestovi());
            AddTestKvalitetaCommand = new MyICommand(AddTestKvaliteta);
            EditTestKvalitetaCommand = new MyICommand(EditTestKvaliteta, CanEditRemoveTestKvaliteta);
            RemoveTestKvalitetaCommand = new MyICommand(RemoveTestKvaliteta, CanEditRemoveTestKvaliteta);
        }

        private void AddTestKvaliteta()
        {
            var s = new AddEditTestKvalitetaView();
            s.DataContext = new AddEditTestKvalitetaViewModel();
            s.ShowDialog();
        }

        private void EditTestKvaliteta()
        {
            var s = new AddEditTestKvalitetaView();
            s.DataContext = new AddEditTestKvalitetaViewModel(SelectedTestKvaliteta);
            s.ShowDialog();
        }

        private bool CanEditRemoveTestKvaliteta()
        {
            return SelectedTestKvaliteta == null ? false : true;

        }

        private void RemoveTestKvaliteta()
        {
            if (SelectedTestKvaliteta != null)
            {
                if (testKvalitetaDAO.Delete(SelectedTestKvaliteta.IdTesta))
                {
                    MessageBox.Show(string.Format("TestKvaliteta sa id {0} obrisan.", SelectedTestKvaliteta.IdTesta));
                    Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("TestKvaliteta sa id {0} nije obrisan..", SelectedTestKvaliteta.IdTesta));
                }
            }

        }

        public static void Refresh()
        {
            if (Testovi != null)
            {
                Testovi.Clear();
                foreach (TestKvaliteta ps in testKvalitetaDAO.GetListTestovi())
                {
                    Testovi.Add(ps);
                }
            }
        }
    }
}
