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
        private int movimiento_id;

        public int Id { get; set; }
        public string Fecha { get; set; }
        public int Movimiento_id { get; set; }
    }
}
