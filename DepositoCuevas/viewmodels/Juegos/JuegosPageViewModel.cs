using DepositoClassLibrary.DTO;
using DepositoClassLibrary.juegos;
using DepositoCuevas.Commands;
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
    public delegate void NotifyGoBack();  // delegate
    public class JuegosPageViewModel : INotifyPropertyChanged
    {
        private Juego juego; 
        private JuegoDTO juegoDTO;
        
        public JuegoDTO JuegoDTO
        {
            get { return juegoDTO; }
            set { juegoDTO = value; NotifyPropertyChanged("JuegoDTO"); }
        }

        public event NotifyGoBack GoBack; // event

        private ObservableCollection<MovimientoJuegoDTO> movimientos = new ObservableCollection<MovimientoJuegoDTO>(); 
        
        public ObservableCollection<MovimientoJuegoDTO> Movimientos
        {
            get {  return movimientos;}
            set { movimientos = value; NotifyPropertyChanged("Movimientos"); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; NotifyPropertyChanged("Message"); }
        }
            

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

        public JuegosPageViewModel(Juego juego)
        {
            this.juego = juego;
            this.JuegoDTO = juego.getJuego();
            fetchMovimientos();
        }

        public AnotherCommandImplementation MovePrevCommand { 
            get {
                return new AnotherCommandImplementation(_ =>
                {
                    GoBack.Invoke();
                });
            }
        }

        
        private void fetchMovimientos()
        {
            Movimientos = new ObservableCollection<MovimientoJuegoDTO>(JuegoController.getMovimientos(juego));
            Message = "" + Movimientos.Count;
        }
    }
}
