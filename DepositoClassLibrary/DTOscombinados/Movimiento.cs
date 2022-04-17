using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoClassLibrary.DTOscombinados
{
    public class Movimiento
    {
        private int movimientoJuegoId;
        private int juegoId;
        private int movimientoId;
        private int saldoAnterior;
        private int movimientoJuegoCantidad;
        private int saldo;

        public int MovimientoJuegoId { get; set; }
        public int JuegoId { get; set; }
        public int MovimientoId { get; set; }

        public int SaldoAnterior { get; set; }
        public int MovimientoJuegoCantidad { get; set; }
        public int Saldo { get; set; }

        private string codigo = "";
        private string descripcion = "";
        private int juegoCantidad;

        public string Codigo { get { return this.codigo; } set { this.codigo = value; } }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public int JuegoCantidad { get; set; }
    }
}
