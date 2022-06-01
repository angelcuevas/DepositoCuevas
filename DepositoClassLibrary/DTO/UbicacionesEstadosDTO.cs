using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoClassLibrary.DTO
{
    public class UbicacionesEstadosDTO
    {
        private int id;
        private DateTime fecha;
        private int movimientoId;
        private int ubicacionId;
        private int numero;

        public int Id { get; set; }
        public string Fecha { get; set; }
        public int MovimientoId { get; set; }
        public int UbicacionId { get; set; }
        public int Numero { get; set; }
    }
}
