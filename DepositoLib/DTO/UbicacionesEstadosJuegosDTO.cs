using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoLib.DTO
{
    public class UbicacionesEstadosJuegosDTO
    {
        private int id;
        private int ubicaciones_estados_id;
        private int juegos_id;
        private int cantidad;

        public int Id { get; set; }
        public int Ubicaciones_estados_id { get; set; }
        public int Juegos_id { get; set; }
        public int Cantidad { get; set; }
    }
}
