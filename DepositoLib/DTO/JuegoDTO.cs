using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoLib.DTO
{
    public class JuegoDTO
    {
        private int id;
        private string codigo;
        private string descripcion;
        private int cantidad; 

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set;  }
    }
}
