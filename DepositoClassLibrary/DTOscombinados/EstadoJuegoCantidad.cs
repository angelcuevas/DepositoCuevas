using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoClassLibrary.DTOscombinados
{
    public class EstadoJuegoCantidad
    {
        public int IdUbicacionesEstadosJuegosId { get; set; }
        public int UbicacionesEstadosId { get; set; }
        public int JuegosCantidadId { get; set; }

        public int JuegoId { get; set; }
        public int JcCantidad { get; set; }

        public string Codigo  { get; set; }
        public string Descripcion { get; set; }
        public int CantidadJuego { get; set; }


    }
}
