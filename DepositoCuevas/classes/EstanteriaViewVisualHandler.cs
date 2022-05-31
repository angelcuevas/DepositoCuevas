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
        private int cantidadNiveles = 3; 
        private List<int> cantidadBancalesPorNivel = new List<int>() { 2,2,2};
        

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
            SolidColorBrush colorModulos = new SolidColorBrush(Color.FromArgb(10, (byte)200, (byte)150, (byte)85));

            int contadorNivel = 1;
            double nivelHeight = medidasHelper.estanteriaViewHeigth / 3;
            for (int i = cantidadNiveles - 1; i >= 0; i--)
            {
                canvasHelper.drawRectangle(new RectangleArguments()
                {
                    Height = nivelHeight,
                    Width = medidasHelper.estanteriaViewWidth,
                    Fill = colorModulos,
                    Left = medidasHelper.estanteriaViewLeft,
                    Top = medidasHelper.estanteriaViewTop + (i* medidasHelper.estanteriaViewHeigth / cantidadNiveles) ,
                    showBorder = false
                    
                });
                double bancalWidth = medidasHelper.estanteriaViewWidth/cantidadBancalesPorNivel[contadorNivel - 1];
                for (int n = 0; n < cantidadBancalesPorNivel[contadorNivel - 1]; n++)
                {
                    canvasHelper.drawRectangle(new RectangleArguments()
                    {
                        Height = nivelHeight*0.75,
                        Width = bancalWidth,
                        Fill = colorModulos,
                        Left = medidasHelper.estanteriaViewLeft + (bancalWidth * n),
                        Top = medidasHelper.estanteriaViewTop + (i * medidasHelper.estanteriaViewHeigth / 3),
                        showBorder = true,
                        text = "Bancal " + (n+1),
                        differentColorOnHover = true,
                        isBold = true
                    }, (string a) => {
                        //OnHover.Invoke(moduloUbicacion);
                    }
                    , (string a) => {
                        // OnClick.Invoke(moduloUbicacion);
                    });
                    double bancalImageWidth = bancalWidth * 0.8;
                    double bancalImageHeigth = nivelHeight * 0.25;

                    canvasHelper.drawImage(new ImageArguments()
                    {
                        height = bancalImageHeigth,
                        width = bancalWidth,
                        imageName = "pallet_frente.png",
                        x = medidasHelper.estanteriaViewLeft + (bancalWidth * n),
                        y = medidasHelper.estanteriaViewTop + ((i + 1) * medidasHelper.estanteriaViewHeigth / cantidadNiveles) - bancalImageHeigth

                    });
                }

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
