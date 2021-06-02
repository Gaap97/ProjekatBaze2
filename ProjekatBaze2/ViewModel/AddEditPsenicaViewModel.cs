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
    public class AddEditPsenicaViewModel : BindableBase
    {
        private double kolicinaPsenice;
        private string kvalitet;
        private Psenica psenica;
        private bool editMode;
        public PsenicaDAO psenicaDAO = new PsenicaDAO();
        public ICommand SavePsenicaCommand { get; set; }

		public AddEditPsenicaViewModel()
        {
			SavePsenicaCommand = new MyICommand(SavePsenica, CanSavePsenica);
			kolicinaPsenice = 0;
			kvalitet = string.Empty;
			psenica = new Psenica();

			editMode = false;
		}

		public AddEditPsenicaViewModel(Psenica ps)
		{
			SavePsenicaCommand = new MyICommand(SavePsenica, CanSavePsenica);
			this.psenica = ps;
			KolicinaPsenice = ps.KolicinaPsenice;
			Kvalitet = ps.Kvalitet;
			editMode = true;
		}

		private bool CanSavePsenica()
		{
			return !string.IsNullOrEmpty(Kvalitet) && KolicinaPsenice != 0;
		}

		private void SavePsenica()
		{
			psenica.KolicinaPsenice = KolicinaPsenice;
			psenica.Kvalitet = Kvalitet;

			if (!editMode)
			{
				if (!psenicaDAO.Insert(psenica))
				{
					MessageBox.Show(string.Format("Psenica not added."));
					return;
				}
				MessageBox.Show(string.Format("Psenica added."));
				KolicinaPsenice = 0;
				Kvalitet = string.Empty;
			}
			else
			{
				if (!psenicaDAO.Update(psenica))
				{
					MessageBox.Show(string.Format("Psenica not updated."));
					return;
				}
				MessageBox.Show(string.Format("Psenica updated."));
			}			

			PsenicaViewModel.Refresh();
		}

		public double KolicinaPsenice
        {
			get
			{
				return kolicinaPsenice;
			}
			set
			{
				kolicinaPsenice = value;
				OnPropertyChanged("KolicinaPsenice");
			}
		}
		public string Kvalitet
		{
			get
			{
				return kvalitet;
			}
			set
			{
				kvalitet = value;
				OnPropertyChanged("Kvalitet");
			}
		}
	}
}
