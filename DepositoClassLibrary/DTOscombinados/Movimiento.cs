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


        //private int movimientoId;
        private int ubicacionOrigen;
        private int ubicacionDestino;
        private DateTime fecha;
        private string comentario;
        //public int MovimientoId { get; set; }
        public int UbicacionOrigen { get; set; }
        public int UbicacionDestino { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }

        private int ubicacionDestinoId;
        private int nivel;
        private string fila;
        private string columna;
        private string nombre;

        public int UbicacionDestinoId { get; set; }
        public int Nivel { get; set; }
        public string Fila { get; set; }
        public string Columna { get; set; }
        public string Nombre { get; set; }

        private int ubicacionOrigenId;
        private int nivelOrigen;
        private string filaOrigen;
        private string columnaOrigen;
        private string nombreOrigen;

        public int UbicacionOrigenId { get; set; }
        public int NivelOrigen { get; set; }
        public string FilaOrigen { get; set; }
        public string ColumnaOrigen { get; set; }
        public string NombreORigen { get; set; }
    }
}
