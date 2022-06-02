using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DepositoCuevas.classes
{
    public enum depositoMapaVistas
    {
        mapa,
        estanteria,
        contenido,
        ingresoDeLinea
    }
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

        private Visibility contenido = Visibility.Collapsed;

        public Visibility Contenido
        {
            get { return contenido; }
            set { contenido = value; NotifyPropertyChanged("Contenido"); }
        }

        private Visibility ingresoDeLinea = Visibility.Collapsed;

        public Visibility IngresoDeLinea
        {
            get { return ingresoDeLinea; }
            set { ingresoDeLinea = value; NotifyPropertyChanged("IngresoDeLinea"); }
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

        private List<depositoMapaVistas> breadCrums = new List<depositoMapaVistas>();

        public MapaDepositoVisibilityHelper()
        {
            breadCrums.Add(depositoMapaVistas.mapa);
        }
        
        public void goToView(depositoMapaVistas vista)
        {
            breadCrums.Add(vista);
            showLastOne();
        }

        public void goToPrevious()
        {

            if(breadCrums.Count == 1)
            {
                return;
            }

            hide(breadCrums[breadCrums.Count - 1]);
            breadCrums.RemoveAt(breadCrums.Count - 1);
            showLastOne();
        }

        private void showLastOne()
        {
            for (int i = 0; i < breadCrums.Count; i++)
            {
                if(i == breadCrums.Count - 1)
                {
                    show(breadCrums[i]);
                }
                else
                {
                    hide(breadCrums[i]);
                }
                
            }
        }

        private void setVisibility(depositoMapaVistas vista, Visibility visibility)
        {
            switch (vista)
            {
                case depositoMapaVistas.mapa:
                    Mapa = visibility;
                    break;
                case depositoMapaVistas.estanteria:
                    Estanteria = visibility;
                    break;
                case depositoMapaVistas.contenido:
                    Contenido = visibility;
                    break;
                case depositoMapaVistas.ingresoDeLinea:
                    IngresoDeLinea = visibility;
                    break;
                    
                default:
                    break;
            }
        }
        private void hide(depositoMapaVistas vista)
        {
            setVisibility(vista, Visibility.Collapsed);
        }

        private void show(depositoMapaVistas vista)
        {
            setVisibility(vista, Visibility.Visible);
        }

    }
}
