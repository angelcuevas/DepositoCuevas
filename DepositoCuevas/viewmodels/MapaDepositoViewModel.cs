using DepositoCuevas.classes;
using DepositoCuevas.viewmodels.helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DepositoCuevas.viewmodels
{
    public class MapaDepositoViewModel//: INotifyPropertyChanged
    {
        private Canvas canvas;
        private DepositoMedidasHelper medidasHelper;
        private CanvasHelper canvasHelper;

        private MapaDepositoTextHelper textHelper;

        public MapaDepositoTextHelper TextHelper
        {
            get { return textHelper; }
            set { textHelper = value; NotifyPropertyChanged("TextHelper"); }
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

        public MapaDepositoViewModel(Canvas myCanvas)
        {
            this.canvas = myCanvas;
            this.canvasHelper = new CanvasHelper(this.canvas);
            this.medidasHelper = new DepositoMedidasHelper(myCanvas.Height, myCanvas.Width);
            drawDeposito();
        }

        private void drawDeposito()
        {
            drawDepositoBackground();
            drawEstanterias();
        }

        private void drawDepositoBackground()
        {
            SolidColorBrush colorFondo = new SolidColorBrush(Color.FromArgb(20, (byte)150, (byte)150, (byte)150));
            canvasHelper.drawRectangle(new RectangleArguments() { Height = medidasHelper.Heigth, Width = medidasHelper.Width, Fill = colorFondo, Left = 0, Top = 0 });
        }

        private void drawEstanterias()
        {
            SolidColorBrush colorEstanterias = new SolidColorBrush(Color.FromArgb(150, (byte)80, (byte)150, (byte)85));

            medidasHelper.ubicacionesEstanterias.ForEach(ubicacion =>
            {
                canvasHelper.drawRectangle(new RectangleArguments() { Height = ubicacion.alto, Width = ubicacion.ancho, Fill = colorEstanterias, Left = ubicacion.x, Top = ubicacion.y });
                EstanteriaVisualHandler handler = new EstanteriaVisualHandler(ubicacion, canvas);
                handler.OnHover += handleEstanteriaHover;
            });
            
        }

        private void handleEstanteriaHover(EstanteriaUbicacion ubicacion)
        {
            TextHelper.ModuloHoverDescripcion = ubicacion.name;
        }



  
    }
}
