using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DepositoClassLibrary.DTO
{
    public class JuegoDTO : INotifyPropertyChanged
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


        private int id;
        private string codigo = "";
        private string descripcion = "";
        private int cantidad; 

        public int Id { get; set; }
        public string Codigo { get { return this.codigo; } set { this.codigo = value; } }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public int Cantidad { get; set;  }
    }
}
