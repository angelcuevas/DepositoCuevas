using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace DepositoCuevas.classes
{
    public delegate void OnHoverDelegate(ModuloUbicacion ubicacion);  // delegate
    public class EstanteriaVisualHandler
    {
        private EstanteriaUbicacion ubicacion;
        private CanvasHelper canvasHelper;
        public event OnHoverDelegate OnHover; // event
        public event OnHoverDelegate OnClick; // event
        public List<ModuloUbicacion> modulos = new List<ModuloUbicacion>();
        private double moduleWidth;

        public EstanteriaVisualHandler(EstanteriaUbicacion ubicacion, Canvas canvas)
        {
            this.ubicacion = ubicacion;
            this.canvasHelper = new CanvasHelper(canvas);
            moduleWidth = ubicacion.ancho / ubicacion.cantidadDeModulos;
            this.drawModulos();
            
        }

        private void drawModulos()
        {
            for (int i = 0; i < ubicacion.cantidadDeModulos; i++)
            {
                SolidColorBrush colorModulos = new SolidColorBrush(Color.FromArgb(100, (byte)200, (byte)150, (byte)85));
                
                int numero = i + 1;
                ModuloUbicacion moduloUbicacion = new ModuloUbicacion()
                {
                    estanteriaUbicacion = ubicacion,
                    numero = numero
                };
                modulos.Add(moduloUbicacion);
                var leftAndTop = calcularLeftAndTop(i);
                canvasHelper.drawRectangle(new RectangleArguments() { 
                        Height = ubicacion.alto, 
                        Width = moduleWidth, 
                        Fill = colorModulos, 
                        Left = leftAndTop.Item1, 
                        Top = leftAndTop.Item2, 
                        showBorder = true, 
                        text = "" + numero,
                        differentColorOnHover = true
                }, (string a) =>{
                        OnHover.Invoke(moduloUbicacion);
                }
                , (string a) => {
                        OnClick.Invoke(moduloUbicacion);
                });
            }

        }

        private Tuple<double, double> calcularLeftAndTop(int i)
        {
            double left = 0;
            double top = 0; 
            if (ubicacion.orientacion == orientacion.HACIA_DERECHA)
            {
                left = ubicacion.x + (i * moduleWidth);
                top = ubicacion.y; 
            }

            if (ubicacion.orientacion == orientacion.HACIA_IZQUIERDA)
            {
                left =  (ubicacion.x + ubicacion.ancho ) - ((i+1) * moduleWidth);
                top = ubicacion.y;
            }

            return Tuple.Create(left, top);
        }
    }
}
