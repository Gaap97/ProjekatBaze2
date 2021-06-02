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
    public class AddEditBrasnoViewModel : BindableBase
    {
		private double kolicinaBrasna;
		private Brasno brasno;
		private bool editMode;
		public BrasnoDAO brasnoDAO = new BrasnoDAO();
		public ICommand SaveBrasnoCommand { get; set; }

		public AddEditBrasnoViewModel()
		{
			SaveBrasnoCommand = new MyICommand(SaveBrasno, CanSaveBrasno);
			kolicinaBrasna = 0;
			brasno = new Brasno();

			editMode = false;
		}

		public AddEditBrasnoViewModel(Brasno ps)
		{
			SaveBrasnoCommand = new MyICommand(SaveBrasno, CanSaveBrasno);
			this.brasno = ps;
			KolicinaBrasna = ps.KolicinaBrasna;
			editMode = true;
		}

		private bool CanSaveBrasno()
		{
			return KolicinaBrasna != 0;
		}

		private void SaveBrasno()
		{
			brasno.KolicinaBrasna = KolicinaBrasna;

			if (!editMode)
			{
				if (!brasnoDAO.Insert(brasno))
				{
					MessageBox.Show(string.Format("Brasno not added."));
					return;
				}
				MessageBox.Show(string.Format("Brasno added."));
				KolicinaBrasna = 0;
			}
			else
			{
				if (!brasnoDAO.Update(brasno))
				{
					MessageBox.Show(string.Format("Brasno not updated."));
					return;
				}
				MessageBox.Show(string.Format("Brasno updated."));
			}

			BrasnoViewModel.Refresh();
		}

		public double KolicinaBrasna
		{
			get
			{
				return kolicinaBrasna;
			}
			set
			{
				kolicinaBrasna = value;
				OnPropertyChanged("KolicinaBrasna");
			}
		}
	}
}
