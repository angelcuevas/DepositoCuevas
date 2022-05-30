using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace DepositoCuevas.classes
{
    public class EstanteriaViewVisualHandler
    {
        private ModuloUbicacion ubicacion;
        private CanvasHelper canvasHelper;
        private DepositoMedidasHelper medidasHelper;
        

        public EstanteriaViewVisualHandler(ModuloUbicacion ubicacion, Canvas canvas, DepositoMedidasHelper medidasHelper)
        {
            this.ubicacion = ubicacion;
            this.canvasHelper = new CanvasHelper(canvas);
            this.medidasHelper = medidasHelper;

            drawEstanteria();
            drawEstanteriaAdornos();
        }
        private void drawEstanteria()
        {
            SolidColorBrush colorModulos = new SolidColorBrush(Color.FromArgb(100, (byte)200, (byte)150, (byte)85));

            int contadorNivel = 1;
            for (int i = 3 - 1; i >= 0; i--)
            {
                canvasHelper.drawRectangle(new RectangleArguments()
                {
                    Height = medidasHelper.estanteriaViewHeigth / 3,
                    Width = medidasHelper.estanteriaViewWidth,
                    Fill = colorModulos,
                    Left = medidasHelper.estanteriaViewLeft,
                    Top = medidasHelper.estanteriaViewTop + (i* medidasHelper.estanteriaViewHeigth / 3) ,
                    showBorder = true,
                    text = "Nivel " + contadorNivel
                }, (string a) => {
                    //OnHover.Invoke(moduloUbicacion);
                }
                , (string a) => {
                   // OnClick.Invoke(moduloUbicacion);
               });

                contadorNivel++;
            }
        }

        public void drawEstanteriaAdornos()
        {

            double estanteriaColumnaWidth = medidasHelper.estanteriaViewWidth * 0.10;
            SolidColorBrush colorEstanteria = new SolidColorBrush(Color.FromArgb(240, (byte)28, (byte)84, (byte)45));

        canvasHelper.drawRectangle(new RectangleArguments()
            {
                Height = medidasHelper.estanteriaViewHeigth * 1.2,
                Width = estanteriaColumnaWidth,
                Fill = colorEstanteria,
                Left = medidasHelper.estanteriaViewLeft - estanteriaColumnaWidth,
                Top = medidasHelper.estanteriaViewTop,
                showBorder = true
            });

            canvasHelper.drawRectangle(new RectangleArguments()
            {
                Height = medidasHelper.estanteriaViewHeigth * 1.2,
                Width = estanteriaColumnaWidth,
                Fill = colorEstanteria,
                Left = medidasHelper.estanteriaViewLeft + medidasHelper.estanteriaViewWidth,
                Top = medidasHelper.estanteriaViewTop,
                showBorder = true
            });
        }
    }
}
