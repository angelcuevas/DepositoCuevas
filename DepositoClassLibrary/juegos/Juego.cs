using DepositoClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DepositoClassLibrary.juegos
{
    public class Juego : INotifyPropertyChanged
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

        public Juego(JuegoDTO juego)
        {
            this.juegoDTO = juego;
        }

        public JuegoDTO getJuego()
        {
            return this.juegoDTO;
        }

        public int getCantidad()
        {
            return this.juegoDTO.Cantidad;
        }
        public void setCantidad(int cantidad)
        {
            this.juegoDTO.Cantidad = cantidad;
        }

        public JuegoDTO JuegoDTO
        {
            get { return this.juegoDTO; }
            set { this.juegoDTO = value; NotifyPropertyChanged("JuegoDTO"); }
        }
    }
}
