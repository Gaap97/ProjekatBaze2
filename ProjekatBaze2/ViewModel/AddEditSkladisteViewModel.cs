using ProjekatBaze2.DAO;
using ProjekatBaze2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjekatBaze2.ViewModel
{
    public class AddEditSkladisteViewModel : BindableBase
    {
		private double kapacitetSkladista;
		private Skladiste skladiste;
		private bool editMode;
		public SkladisteDAO skladisteDAO = new SkladisteDAO();
		public ICommand SaveSkladisteCommand { get; set; }

		public AddEditSkladisteViewModel()
		{
			SaveSkladisteCommand = new MyICommand(SaveSkladiste, CanSaveSkladiste);
			kapacitetSkladista = 0;
			skladiste = new Skladiste();

			editMode = false;
		}

		public AddEditSkladisteViewModel(Skladiste ps)
		{
			SaveSkladisteCommand = new MyICommand(SaveSkladiste, CanSaveSkladiste);
			this.skladiste = ps;
			editMode = true;
		}

		private bool CanSaveSkladiste()
		{
			return KapacitetSkladista != 0;
		}

		private void SaveSkladiste()
		{
			skladiste.KapacitetSkladista = true;

			if (!editMode)
			{
				if (!skladisteDAO.Insert(skladiste))
				{
					MessageBox.Show(string.Format("Skladiste not added."));
					return;
				}
				MessageBox.Show(string.Format("Skladiste added."));
				KapacitetSkladista = 0;
			}
			else
			{
				if (!skladisteDAO.Update(skladiste))
				{
					MessageBox.Show(string.Format("Skladiste not updated."));
					return;
				}
				MessageBox.Show(string.Format("Skladiste updated."));
			}

			SkladisteViewModel.Refresh();
		}

		public double KapacitetSkladista
		{
			get
			{
				return kapacitetSkladista;
			}
			set
			{
				kapacitetSkladista = value;
				OnPropertyChanged("KapacitetSkladista");
			}
		}
	}
}
