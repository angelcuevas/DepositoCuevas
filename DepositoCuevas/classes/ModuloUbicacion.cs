using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoCuevas.classes
{
    public class ModuloUbicacion
    {
        public EstanteriaUbicacion estanteriaUbicacion;
        public string name = "";
        public double x = 0;
        public double y = 0;
        public double alto = 0;
        public double ancho = 0;
        public int numero = 0;

        public string getDescripcion()
        {
            return "Estanteria " + estanteriaUbicacion.numero + " Módulo " + numero;
        }
    }
}
