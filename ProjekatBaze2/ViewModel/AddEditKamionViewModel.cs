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
    public class AddEditKamionViewModel : BindableBase
    {
		private double kapacitetKamiona;
		private Kamion kamion;
		private bool editMode;
		public KamionDAO kamionDAO = new KamionDAO();
		public ICommand SaveKamionCommand { get; set; }

		public AddEditKamionViewModel()
		{
			SaveKamionCommand = new MyICommand(SaveKamion, CanSaveKamion);
			kapacitetKamiona = 0;
			kamion = new Kamion();

			editMode = false;
		}

		public AddEditKamionViewModel(Kamion ps)
		{
			SaveKamionCommand = new MyICommand(SaveKamion, CanSaveKamion);
			this.kamion = ps;
			KapacitetKamiona = ps.KapacitetKamiona;
			editMode = true;
		}

		private bool CanSaveKamion()
		{
			return KapacitetKamiona != 0;
		}

		private void SaveKamion()
		{
			kamion.KapacitetKamiona = KapacitetKamiona;

			if (!editMode)
			{
				if (!kamionDAO.Insert(kamion))
				{
					MessageBox.Show(string.Format("Kamion not added."));
					return;
				}
				MessageBox.Show(string.Format("Kamion added."));
				KapacitetKamiona = 0;
			}
			else
			{
				if (!kamionDAO.Update(kamion))
				{
					MessageBox.Show(string.Format("Kamion not updated."));
					return;
				}
				MessageBox.Show(string.Format("Kamion updated."));
			}

			KamionViewModel.Refresh();
		}

		public double KapacitetKamiona
		{
			get
			{
				return kapacitetKamiona;
			}
			set
			{
				kapacitetKamiona = value;
				OnPropertyChanged("KapacitetKamiona");
			}
		}
	}
}
