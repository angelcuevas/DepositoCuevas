using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DepositoCuevas.classes
{
    public class ViewsVisivility : INotifyPropertyChanged
    {

        private Visibility juegosPage = Visibility.Collapsed;

        public Visibility JuegosPage
        {
            get { return juegosPage; }
            set { juegosPage = value; NotifyPropertyChanged("JuegosPage"); }
        }

        private Visibility juegosList = Visibility.Visible;

        public Visibility JuegosList
        {
            get { return juegosList; }
            set { juegosList = value; NotifyPropertyChanged("JuegosList"); }
        }



        #region InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


    }
}
