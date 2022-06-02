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
        private string comentarios;
        //public int MovimientoId { get; set; }
        public int UbicacionOrigen { get; set; }
        public int UbicacionDestino { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentarios { get; set; }

        private int ubicacionDestinoId;
        private int nivel;
        private string estanteria;
        private string modulo;
        private int bancal;
        private string nombre;

        public int UbicacionDestinoId { get; set; }
        public int Nivel { get; set; }
        public string Estanteria { get; set; }
        public string Modulo { get; set; }
        public int Bancal { get; set; }
        public string Nombre { get; set; }

        private int ubicacionOrigenId;
        private int nivelOrigen;
        private string estanteriaOrigen;
        private string moduloOrigen;
        private int bancalOrigen;
        private string nombreOrigen;

        public int UbicacionOrigenId { get; set; }
        public int NivelOrigen { get; set; }
        public string EstanteriaOrigen { get; set; }
        public string ModuloOrigen { get; set; }

        public int BancalOrigen { get; set; }
        public string NombreORigen { get; set; }
    }
}
