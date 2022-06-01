using DepositoClassLibrary.DTO;
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
    public class MapaDepositoViewModel : INotifyPropertyChanged
    {
        private Canvas canvas;
        private Canvas estanteriaCanvas;
        private DepositoMedidasHelper medidasHelper;
        private CanvasHelper canvasHelper;

        private MapaDepositoTextHelper textHelper = new MapaDepositoTextHelper();
        public MapaDepositoTextHelper TextHelper
        {
            get { return textHelper; }
            set { textHelper = value; NotifyPropertyChanged("TextHelper"); }
        }

        private MapaDepositoVisibilityHelper visibilityHelper = new MapaDepositoVisibilityHelper();

        public MapaDepositoVisibilityHelper VisibilityHelper
        {
            get { return visibilityHelper; }
            set {  visibilityHelper = value; NotifyPropertyChanged("VisibilityHelper"); }          
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

        public MapaDepositoViewModel(Canvas myCanvas, Canvas estanteriaCanvas)
        {
            this.canvas = myCanvas;
            this.estanteriaCanvas = estanteriaCanvas; 
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
            SolidColorBrush colorFondo = new SolidColorBrush(Color.FromArgb(100, (byte)150, (byte)150, (byte)150));
            canvasHelper.drawRectangle(new RectangleArguments() { Height = medidasHelper.Heigth, Width = medidasHelper.Width, Fill = colorFondo, Left = 0, Top = 0, showBorder = true });
        }

        private void drawEstanterias()
        {
            SolidColorBrush colorEstanterias = new SolidColorBrush(Color.FromArgb(150, (byte)80, (byte)150, (byte)85));

            medidasHelper.ubicacionesEstanterias.ForEach(ubicacion =>
            {
                canvasHelper.drawRectangle(new RectangleArguments() { Height = ubicacion.alto, Width = ubicacion.ancho, Fill = colorEstanterias, Left = ubicacion.x, Top = ubicacion.y });
                DrawEstanteriaNumber(ubicacion);
                EstanteriaVisualHandler handler = new EstanteriaVisualHandler(ubicacion, canvas);
                handler.OnHover += handleEstanteriaHover;
                handler.OnClick += handleEstanteriaClick;
            });
            
        }

        private void DrawEstanteriaNumber(EstanteriaUbicacion ubicacion)
        {
            double x = 0;

            if (ubicacion.orientacion == orientacion.HACIA_IZQUIERDA)
            {
                x = ubicacion.x + ubicacion.ancho;
            }

            if (ubicacion.orientacion == orientacion.HACIA_DERECHA)
            {
                x = ubicacion.x - medidasHelper.anchoEstanterias /25 ;
            }

            canvasHelper.WriteText(new CanvasTextArguments()
            {
                x = x,
                y = ubicacion.y,
                text = ""+ubicacion.numero,
                isBold = true
            });
        }

        private void handleEstanteriaHover(ModuloUbicacion ubicacion)
        {
            TextHelper.ModuloHoverDescripcion = ubicacion.getDescripcion();
        }

        private void handleEstanteriaClick(ModuloUbicacion ubicacion)
        {
            showVistaEstanteria(ubicacion);
        }

        private void showVistaEstanteria(ModuloUbicacion ubicacion)
        {
            visibilityHelper.showEstanteria();
            drawEstanteriaView(ubicacion);

        }

        private void drawEstanteriaView(ModuloUbicacion ubicacion)
        {
            EstanteriaViewVisualHandler handler = new EstanteriaViewVisualHandler(ubicacion, estanteriaCanvas, medidasHelper);
            handler.OnHover += handlerBancalHover;
        }

        private void handlerBancalHover(UbicacionDTO ubicacion)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Estanteria " + ubicacion.Estanteria);
            sb.Append(" Modulo " + ubicacion.Modulo);
            sb.Append(" Nivel " + ubicacion.Nivel);
            sb.Append(" Bancal " + ubicacion.Bancal);

            textHelper.BancalHoverDescripcion = sb.ToString();
        }


    }
}
