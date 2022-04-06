using DepositoClassLibrary.DTO;
using DepositoClassLibrary.juegos;
using DepositoServicesLibrary.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DepositoCuevas.viewmodels.Juegos
{
    internal class JuegosListViewModel : INotifyPropertyChanged
    {

        private string mensaje = "Hello world";
        private ObservableCollection<Juego> lista;

        #region InotifyPropertyChanged
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
        #endregion


        public ObservableCollection<Juego> Lista
        {
            get { return lista; }
            set { lista = value; NotifyPropertyChanged("Lista"); }
        }
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; NotifyPropertyChanged("Mensaje"); }
        }


        public JuegosListViewModel()
        {
            lista = new ObservableCollection<Juego>(JuegoController.getAll());
            Mensaje = "son " + lista.Count();
        }
    }
}
