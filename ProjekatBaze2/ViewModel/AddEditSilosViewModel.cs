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
    public class AddEditSilosViewModel : BindableBase
    {
		private double kapacitetSilosa;
		private Silos silos;
		private bool editMode;
		public SilosDAO silosDAO = new SilosDAO();
		public ICommand SaveSilosCommand { get; set; }

		public AddEditSilosViewModel()
		{
			SaveSilosCommand = new MyICommand(SaveSilos, CanSaveSilos);
			kapacitetSilosa = 0;
			silos = new Silos();

			editMode = false;
		}

		public AddEditSilosViewModel(Silos ps)
		{
			SaveSilosCommand = new MyICommand(SaveSilos, CanSaveSilos);
			this.silos = ps;
			KapacitetSilosa = ps.KapacitetSilosa;
			editMode = true;
		}

		private bool CanSaveSilos()
		{
			return KapacitetSilosa != 0;
		}

		private void SaveSilos()
		{
			silos.KapacitetSilosa = KapacitetSilosa;

			if (!editMode)
			{
				if (!silosDAO.Insert(silos))
				{
					MessageBox.Show(string.Format("Silos not added."));
					return;
				}
				MessageBox.Show(string.Format("Silos added."));
				KapacitetSilosa = 0;
			}
			else
			{
				if (!silosDAO.Update(silos))
				{
					MessageBox.Show(string.Format("Silos not updated."));
					return;
				}
				MessageBox.Show(string.Format("Silos updated."));
			}

			SilosViewModel.Refresh();
		}

		public double KapacitetSilosa
		{
			get
			{
				return kapacitetSilosa;
			}
			set
			{
				kapacitetSilosa = value;
				OnPropertyChanged("KapacitetSilosa");
			}
		}
	}
}
