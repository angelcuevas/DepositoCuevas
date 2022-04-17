using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoClassLibrary.DTO
{
    public class MovimientoJuegoDTO
    {
        private int id;
        private int juegoId;
        private int movimientoId;
        private int saldoAnterior;
        private int cantidad;
        private int saldo; 

        public int Id { get; set; }
        public int JuegoId { get; set; }
        public int MovimientoId { get; set; }
        
        public int SaldoAnterior { get; set; }
        public int Cantidad { get; set; }
        public int Saldo { get; set; }

    }
}
