using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoCuevas.classes
{
    public class EstanteriaUbicacion
    {
        public string name = "";
        public double x = 0;
        public double y = 0;
        public double alto = 0;
        public double ancho = 0;
        public orientacion orientacion;
        public int cantidadDeModulos = 0;
    }

    public enum orientacion
    {
        HACIA_DERECHA,
        HACIA_IZQUIERDA
    }
}
