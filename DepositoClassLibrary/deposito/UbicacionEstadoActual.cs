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
        private UbicacionDTO ubicacion;

        public UbicacionDTO Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

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
