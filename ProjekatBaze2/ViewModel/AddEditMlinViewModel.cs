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
    public class AddEditMlinViewModel : BindableBase
    {
		private string nazivMlina;
		private string vlasnikMlina;
		private Mlin mlin;
		private bool editMode;
		public MlinDAO mlinDAO = new MlinDAO();
		public ICommand SaveMlinCommand { get; set; }

		public AddEditMlinViewModel()
		{
			SaveMlinCommand = new MyICommand(SaveMlin, CanSaveMlin);
			nazivMlina = string.Empty;
			vlasnikMlina = string.Empty;
			mlin = new Mlin();

			editMode = false;
		}

		public AddEditMlinViewModel(Mlin ps)
		{
			SaveMlinCommand = new MyICommand(SaveMlin, CanSaveMlin);
			this.mlin = ps;
			NazivMlina = ps.NazivMlina;
			VlasnikMlina = ps.VlasnikMlina;
			editMode = true;
		}

		private bool CanSaveMlin()
		{
			return !string.IsNullOrEmpty(NazivMlina) && !string.IsNullOrEmpty(VlasnikMlina);
		}

		private void SaveMlin()
		{
			mlin.NazivMlina = NazivMlina;
			mlin.VlasnikMlina = VlasnikMlina;

			if (!editMode)
			{
				if (!mlinDAO.Insert(mlin))
				{
					MessageBox.Show(string.Format("Mlin not added."));
					return;
				}
				MessageBox.Show(string.Format("Mlin added."));
				NazivMlina = string.Empty;
				VlasnikMlina = string.Empty;
			}
			else
			{
				if (!mlinDAO.Update(mlin))
				{
					MessageBox.Show(string.Format("Mlin not updated."));
					return;
				}
				MessageBox.Show(string.Format("Mlin updated."));
			}

			MlinViewModel.Refresh();
		}

		public string NazivMlina
		{
			get
			{
				return nazivMlina;
			}
			set
			{
				nazivMlina = value;
				OnPropertyChanged("NazivMlina");
			}
		}
		public string VlasnikMlina
		{
			get
			{
				return vlasnikMlina;
			}
			set
			{
				vlasnikMlina = value;
				OnPropertyChanged("VlasnikMlina");
			}
		}
	}
}
