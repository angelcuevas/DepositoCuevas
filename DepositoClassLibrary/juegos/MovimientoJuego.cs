using DepositoClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoClassLibrary.juegos
{
    public class MovimientoJuego :INotifyPropertyChanged
    {

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

        private JuegoDTO juegoDTO;
        public JuegoDTO JuegoDTO
        {
            get { return juegoDTO; }
            set { juegoDTO = value; }
        }

        private MovimientoJuegoDTO movimientoJuegoDTO;
        public MovimientoJuegoDTO MovimientoJuegoDTO
        {
            get { return movimientoJuegoDTO; }
            set { movimientoJuegoDTO = value; NotifyPropertyChanged("MovimientoJuegoDTO"); }
        }

        private UbicacionDTO ubicacionOrigenDTO; 
        public UbicacionDTO UbicacionOrigenDTO
        {
            get { return ubicacionOrigenDTO; }
            set { ubicacionOrigenDTO = value; NotifyPropertyChanged("UbicacionOrigenDTO"); }
        }

        private UbicacionDTO ubicacionDestinoDTO;
        public UbicacionDTO UbicacionDestinoDTO
        {
            get { return ubicacionDestinoDTO; }
            set { ubicacionDestinoDTO = value; NotifyPropertyChanged("UbicacionDestinoDTO"); }
        }

        private MovimientoDTO movimientoDTO;
        public MovimientoDTO MovimientoDTO
        {
            get { return movimientoDTO; }
            set { movimientoDTO = value; NotifyPropertyChanged("MovimientoDTO"); }
        }

    }
}
