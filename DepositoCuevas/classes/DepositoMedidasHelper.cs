using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoCuevas.classes
{
    public class DepositoMedidasHelper
    {
        public double Heigth;
        public double Width;

        public double estanteriasHeigth = 0;
        public double estanteriasWidth = 0;

        public double bordeEstanterias = 0;
        public double espacioEntreEstanterias = 0;
        public double altoEstanterias = 0;
        public double anchoEstanterias = 0;
        public double anchoPasilloCentral = 0;

        public double estanteriaViewWidth = 0;
        public double estanteriaViewHeigth = 0;
        public double estanteriaViewLeft = 0;
        public double estanteriaViewTop = 0;

        public List<int> lugaresIzquierda = new List<int>() { 3, 4, 7, 8, 11, 12, 15, 16, 19, 20, 23 };
        public List<int> cantidadDeModulosIzquierda = new List<int>() { 6, 7, 7, 7, 5, 6, 5, 7, 6, 6, 7 };

        public List<int> lugaresDerecha = new List<int>() { 12, 15, 16, 19, 20, 23 };
        public List<int> cantidadDeModulosDerecha = new List<int>() { 7, 6, 6, 6, 5, 6 };

        public List<EstanteriaUbicacion> ubicacionesEstanterias = new List<EstanteriaUbicacion>();

        public DepositoMedidasHelper(double canvasHeigth, double canvasWidth)
        {
            this.Heigth = canvasHeigth; 
            this.Width = canvasWidth;
            calcularMedidas();
            calcularUbicacionEstanterias();
        }

        private void calcularMedidas()
        {
            estanteriasHeigth = Heigth / 10;
            estanteriasWidth = Width / 10;
            bordeEstanterias = Width /20;
            anchoPasilloCentral = Width / 10;
            altoEstanterias = (Heigth - bordeEstanterias) / 23;
            anchoEstanterias = ( ((Width - (bordeEstanterias * 2)) - anchoPasilloCentral) /2) ;
            espacioEntreEstanterias = altoEstanterias * 2;

            double  division = 2;
            estanteriaViewWidth = Width / division;
            estanteriaViewHeigth = Heigth * 0.80;
            estanteriaViewLeft = (Width - estanteriaViewWidth) / 2;
            estanteriaViewTop = Heigth * 0.1;


        }
        private void calcularUbicacionEstanterias()
        {
            int contador = 23;
            int contadorDeEstanterias = 1; 



            while (contador > 0)
            {
                int index = lugaresIzquierda.IndexOf(contador);
                if (index != -1) { 
                    ubicacionesEstanterias.Add(new EstanteriaUbicacion() { x = bordeEstanterias, y = bordeEstanterias + (altoEstanterias * (contador - 1)), alto = altoEstanterias, ancho = anchoEstanterias, orientacion = orientacion.HACIA_IZQUIERDA, cantidadDeModulos = cantidadDeModulosIzquierda[index], numero = contadorDeEstanterias });
                    contadorDeEstanterias++;
                }
                contador--;
                
            }
            contador = 23;
            while (contador > 0)
            {
                int index = lugaresDerecha.IndexOf(contador);
                if (index != -1)
                {
                    ubicacionesEstanterias.Add(new EstanteriaUbicacion() { x = bordeEstanterias + anchoEstanterias + anchoPasilloCentral, y = bordeEstanterias + (altoEstanterias * (contador - 1)), alto = altoEstanterias, ancho = anchoEstanterias, orientacion = orientacion.HACIA_DERECHA, cantidadDeModulos = cantidadDeModulosDerecha[index], numero = contadorDeEstanterias });
                    contadorDeEstanterias++;
                }
                contador--;
                
            }

        }

    }

    
}
