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
    public class AddEditTestKvalitetaViewModel : BindableBase
    {
		private double kapacitetTestera;
		private TestKvaliteta testKvaliteta;
		private bool editMode;
		public TestKvalitetaDAO testKvalitetaDAO = new TestKvalitetaDAO();
		public ICommand SaveTestKvalitetaCommand { get; set; }

		public AddEditTestKvalitetaViewModel()
		{
			SaveTestKvalitetaCommand = new MyICommand(SaveTestKvaliteta, CanSaveTestKvaliteta);
			kapacitetTestera = 0;
			testKvaliteta = new TestKvaliteta();

			editMode = false;
		}

		public AddEditTestKvalitetaViewModel(TestKvaliteta ps)
		{
			SaveTestKvalitetaCommand = new MyICommand(SaveTestKvaliteta, CanSaveTestKvaliteta);
			this.testKvaliteta = ps;
			KapacitetTestera = ps.KapacitetTestera;
			editMode = true;
		}

		private bool CanSaveTestKvaliteta()
		{
			return KapacitetTestera != 0;
		}

		private void SaveTestKvaliteta()
		{
			testKvaliteta.KapacitetTestera = KapacitetTestera;

			if (!editMode)
			{
				if (!testKvalitetaDAO.Insert(testKvaliteta))
				{
					MessageBox.Show(string.Format("TestKvaliteta not added."));
					return;
				}
				MessageBox.Show(string.Format("TestKvaliteta added."));
				KapacitetTestera = 0;
			}
			else
			{
				if (!testKvalitetaDAO.Update(testKvaliteta))
				{
					MessageBox.Show(string.Format("TestKvaliteta not updated."));
					return;
				}
				MessageBox.Show(string.Format("TestKvaliteta updated."));
			}

			TestKvalitetaViewModel.Refresh();
		}

		public double KapacitetTestera
		{
			get
			{
				return kapacitetTestera;
			}
			set
			{
				kapacitetTestera = value;
				OnPropertyChanged("KapacitetTestera");
			}
		}
	}
}
