using DepositoClassLibrary.juegos;
using DepositoCuevas.classes;
using DepositoCuevas.viewmodels.Juegos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoCuevas.viewmodels
{
    public delegate void Notify(Juego juego);  // delegate
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private String fecha ;
        private JuegosListViewModel juegoListViewModel = new JuegosListViewModel();
        private JuegosPageViewModel juegosPageViewModel;
        public JuegosPageViewModel JuegosPageViewModel
        {
            get { return juegosPageViewModel; }
            set { juegosPageViewModel = value; NotifyPropertyChanged("JuegosPageViewModel"); }
        }

        public event Notify GoToJuegoPage; // event

        private ViewsVisivility viewsVisibility = new ViewsVisivility();

        public ViewsVisivility ViewsVisibility
        {
            get { return viewsVisibility; }
            set { viewsVisibility = value; }
        }


        public JuegosListViewModel JuegoListViewModel
        {
            get { return juegoListViewModel; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string Fecha {
            set
            {
                this.fecha = value;
                NotifyPropertyChanged();
            }
            get {
                return this.fecha;

            }
        }

        public MainWindowViewModel()
        {
            this.Fecha = DateTime.Now.ToString("D");

            juegoListViewModel.GoToJuegoPage += onJuegoPage;
        }

        public void onJuegoPage(Juego juego)
        {
            //Console.WriteLine("LCDTM " + juego.getJuego().Descripcion);
            //GoToJuegoPage?.Invoke(juego);
            JuegosPageViewModel = new JuegosPageViewModel(juego);

            JuegosPageViewModel.GoBack += goBackToJuegosListPage;

            ViewsVisibility.JuegosList = System.Windows.Visibility.Collapsed;
            ViewsVisibility.JuegosPage = System.Windows.Visibility.Visible;

        }

        public void goBackToJuegosListPage()
        {
            ViewsVisibility.JuegosList = System.Windows.Visibility.Visible;
            ViewsVisibility.JuegosPage = System.Windows.Visibility.Collapsed;
        }
    }
}
