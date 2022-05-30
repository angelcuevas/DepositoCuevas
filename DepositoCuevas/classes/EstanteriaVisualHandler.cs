using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace DepositoCuevas.classes
{
    public delegate void OnHoverDelegate(EstanteriaUbicacion ubicacion);  // delegate
    public class EstanteriaVisualHandler
    {
        private EstanteriaUbicacion ubicacion;
        private CanvasHelper canvasHelper;
        public event OnHoverDelegate OnHover; // event

        public EstanteriaVisualHandler(EstanteriaUbicacion ubicacion, Canvas canvas)
        {
            this.ubicacion = ubicacion;
            this.canvasHelper = new CanvasHelper(canvas);
            this.drawModulos();
        }

        private void drawModulos()
        {
            double moduleWidth = ubicacion.ancho / ubicacion.cantidadDeModulos;
            
            SolidColorBrush colorModulos = new SolidColorBrush(Color.FromArgb(100, (byte)200, (byte)150, (byte)85));

            for (int i = 0; i < ubicacion.cantidadDeModulos; i++)
            {
                canvasHelper.drawRectangle(
                    new RectangleArguments() { Height = ubicacion.alto, Width = moduleWidth, Fill = colorModulos, Left = ubicacion.x + (i*moduleWidth) , Top = ubicacion.y, showBorder = true }
                , (string a) =>
                {
                    OnHover.Invoke(ubicacion);
                }
                );
            }

        }
    }
}
