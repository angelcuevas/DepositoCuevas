using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoLib.DTO
{
    public class MovimientoDTO
    {
        private int id;
        private int ubicacionOrigen;
        private int ubicacionDestino;
        private DateTime fecha;
        private string comentario;
        public int Id { get; set; }
        public int  UbicacionOrigen { get; set; }
        public int UbicacionDestino { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }

    }
}
