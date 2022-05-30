using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoCuevas.viewmodels.helpers
{
    public  class MapaDepositoTextHelper : INotifyPropertyChanged
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

        private string moduloHoverDescripcion = "F";

        public string ModuloHoverDescripcion
        {
            get { return moduloHoverDescripcion; }
            set { moduloHoverDescripcion = value; NotifyPropertyChanged("ModuloHoverDescripcion"); }
        }

    }
}
