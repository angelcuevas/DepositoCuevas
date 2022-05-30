using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DepositoCuevas.classes
{
    public class MapaDepositoVisibilityHelper : INotifyPropertyChanged
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

        private Visibility mapa = Visibility.Visible;

        public Visibility Mapa
        {
            get { return mapa; }
            set { mapa = value; NotifyPropertyChanged("Mapa"); }
        }

        private Visibility estanteria = Visibility.Collapsed;

        public Visibility Estanteria
        {
            get { return estanteria; }
            set { estanteria = value; NotifyPropertyChanged("Estanteria"); }
        }

        private Visibility bancales = Visibility.Collapsed;

        public Visibility Bancales
        {
            get { return bancales; }
            set { bancales = value; NotifyPropertyChanged("Bancales"); }
        }

        public void showMapa()
        {
            this.Mapa = Visibility.Visible;
            this.Estanteria = Visibility.Collapsed;
            this.Bancales = Visibility.Collapsed;
        }

        public void showEstanteria()
        {
            this.Mapa = Visibility.Collapsed;
            this.Estanteria = Visibility.Visible;
            this.Bancales = Visibility.Collapsed;
        }

        public void showBancales()
        {
            this.Mapa = Visibility.Collapsed;
            this.Estanteria = Visibility.Collapsed;
            this.Bancales = Visibility.Visible;
        }


    }
}
