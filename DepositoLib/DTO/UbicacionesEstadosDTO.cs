using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoLib.DTO
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
