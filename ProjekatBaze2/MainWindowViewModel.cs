using ProjekatBaze2.ViewModel;
using ProjekatBaze2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjekatBaze2
{
    public class MainWindowViewModel : BindableBase
    {
        public ICommand PseniceShowCommand { get; set; }
        public ICommand RadniciShowCommand { get; set; }
        public ICommand TestKvalitetaShowCommand { get; set; }
        public ICommand MlinShowCommand { get; set; }
        public ICommand BrasnoShowCommand { get; set; }
        public ICommand SilosShowCommand { get; set; }
        public ICommand PrekrupacShowCommand { get; set; }
        public ICommand SkladisteShowCommand { get; set; }
        public ICommand KamionShowCommand { get; set; }

        public MainWindowViewModel()
        {
            PseniceShowCommand = new MyICommand(PseniceShow);
            RadniciShowCommand = new MyICommand(RadniciShow);
            TestKvalitetaShowCommand = new MyICommand(TestKvalitetaShow);
            MlinShowCommand = new MyICommand(MlinShow);
            BrasnoShowCommand = new MyICommand(BrasnoShow);
            SilosShowCommand = new MyICommand(SilosShow);
            PrekrupacShowCommand = new MyICommand(PrekrupacShow);
            SkladisteShowCommand = new MyICommand(SkladisteShow);
            KamionShowCommand = new MyICommand(KamionShow);
        }
        private void PseniceShow()
        {
            var view = new PsenicaView();
            view.DataContext = new PsenicaViewModel();
            view.ShowDialog();
        }

        private void RadniciShow()
        {
            var view = new RadniciView();
            view.DataContext = new RadniciViewModel();
            view.ShowDialog();
        }

        private void TestKvalitetaShow()
        {
            var view = new TestKvalitetaView();
            view.DataContext = new TestKvalitetaViewModel();
            view.ShowDialog();
        }

        private void MlinShow()
        {
            var view = new MlinView();
            view.DataContext = new MlinViewModel();
            view.ShowDialog();
        }

        private void BrasnoShow()
        {
            var view = new BrasnoView();
            view.DataContext = new BrasnoViewModel();
            view.ShowDialog();
        }

        private void SilosShow()
        {
            var view = new SilosView();
            view.DataContext = new SilosViewModel();
            view.ShowDialog();
        }

        private void PrekrupacShow()
        {
            var view = new PrekrupacView();
            view.DataContext = new PrekrupacViewModel();
            view.ShowDialog();
        }

        private void SkladisteShow()
        {
            var view = new SkladisteView();
            view.DataContext = new SkladisteViewModel();
            view.ShowDialog();
        }

        private void KamionShow()
        {
            var view = new KamionView();
            view.DataContext = new KamionViewModel();
            view.ShowDialog();
        }
    }
}