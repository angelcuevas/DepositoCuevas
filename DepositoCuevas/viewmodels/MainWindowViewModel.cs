using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoCuevas.viewmodels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private String fecha ;


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
        }
    }
}
