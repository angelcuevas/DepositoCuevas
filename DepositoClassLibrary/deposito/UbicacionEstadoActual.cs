using DepositoClassLibrary.DTO;
using DepositoClassLibrary.DTOscombinados;
using DepositoClassLibrary.juegos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoClassLibrary.deposito
{
    public class UbicacionEstadoActual
    {
        public UbicacionDTO ubicacion;
        public UbicacionesEstadosDTO estado;
        public bool isStateLess = false;

        private List<JuegoEstadoCantidad> cantidades = new List<JuegoEstadoCantidad>();
        public List<JuegoEstadoCantidad> Cantidades
        {
            get { return cantidades; }
            set { cantidades = value; }
        }
    }
}
