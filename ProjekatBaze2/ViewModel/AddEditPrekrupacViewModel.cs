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
    public class AddEditPrekrupacViewModel : BindableBase
    {
		private double kapacitetPrekrupaca;
		private Prekrupac prekrupac;
		private bool editMode;
		public PrekrupacDAO prekrupacDAO = new PrekrupacDAO();
		public ICommand SavePrekrupacCommand { get; set; }

		public AddEditPrekrupacViewModel()
		{
			SavePrekrupacCommand = new MyICommand(SavePrekrupac, CanSavePrekrupac);
			kapacitetPrekrupaca = 0;
			prekrupac = new Prekrupac();

			editMode = false;
		}

		public AddEditPrekrupacViewModel(Prekrupac ps)
		{
			SavePrekrupacCommand = new MyICommand(SavePrekrupac, CanSavePrekrupac);
			this.prekrupac = ps;
			KapacitetPrekrupaca = ps.KapacitetPrekrupaca;
			editMode = true;
		}

		private bool CanSavePrekrupac()
		{
			return KapacitetPrekrupaca != 0;
		}

		private void SavePrekrupac()
		{
			prekrupac.KapacitetPrekrupaca = KapacitetPrekrupaca;

			if (!editMode)
			{
				if (!prekrupacDAO.Insert(prekrupac))
				{
					MessageBox.Show(string.Format("Prekrupac not added."));
					return;
				}
				MessageBox.Show(string.Format("Prekrupac added."));
				KapacitetPrekrupaca = 0;
			}
			else
			{
				if (!prekrupacDAO.Update(prekrupac))
				{
					MessageBox.Show(string.Format("Prekrupac not updated."));
					return;
				}
				MessageBox.Show(string.Format("Prekrupac updated."));
			}

			PrekrupacViewModel.Refresh();
		}

		public double KapacitetPrekrupaca
		{
			get
			{
				return kapacitetPrekrupaca;
			}
			set
			{
				kapacitetPrekrupaca = value;
				OnPropertyChanged("KapacitetPrekrupaca");
			}
		}
	}
}
