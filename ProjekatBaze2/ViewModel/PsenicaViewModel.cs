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
    public class PsenicaViewModel : BindableBase
    {
        public ICommand AddPsenicaCommand { get; set; }
        public ICommand EditPsenicaCommand { get; set; }
        public ICommand RemovePsenicaCommand { get; set; }
        public static ObservableCollection<Psenica> Psenice { get; set; }
        public Psenica SelectedPsenica { get; set; }

        public static PsenicaDAO psenicaDAO = new PsenicaDAO();

        public PsenicaViewModel()
        {
            Psenice = new ObservableCollection<Psenica>(psenicaDAO.GetListPsenice());
            AddPsenicaCommand = new MyICommand(AddPsenica);
            EditPsenicaCommand = new MyICommand(EditPsenica, CanEditRemovePsenica);
            RemovePsenicaCommand = new MyICommand(RemovePsenica, CanEditRemovePsenica);
        }

        private void AddPsenica()
        {
            var s = new AddEditPsenicaView();
            s.DataContext = new AddEditPsenicaViewModel();
            s.ShowDialog();
        }

        private void EditPsenica()
        {
            var s = new AddEditPsenicaView();
            s.DataContext = new AddEditPsenicaViewModel(SelectedPsenica);
            s.ShowDialog();
        }

        private bool CanEditRemovePsenica()
        {
            return SelectedPsenica == null ? false : true;

        }

        private void RemovePsenica()
        {
            if (SelectedPsenica != null)
            {
                if (psenicaDAO.Delete(SelectedPsenica.IdPsenice))
                {
                    MessageBox.Show(string.Format("Psenica sa id {0} obrisana.", SelectedPsenica.IdPsenice));
                    Refresh();
                }
                else
                {
                    MessageBox.Show(string.Format("Psenica sa id {0} nije obrisana..", SelectedPsenica.IdPsenice));
                }
            }

        }

        public static void Refresh()
        {
            if (Psenice != null)
            {
                Psenice.Clear();
                foreach (Psenica ps in psenicaDAO.GetListPsenice())
                {
                    Psenice.Add(ps);
                }
            }
        }
    }
}
