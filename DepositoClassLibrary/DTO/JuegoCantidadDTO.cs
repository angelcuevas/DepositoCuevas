using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoClassLibrary.DTO
{
    public class JuegoCantidadDTO
    {
        private int id;
        private int juegoId;
        private int cantidad;

        public int Id {get;set;}
        public int JuegoId { get; set; }
        public int Cantidad { get; set; }
    }
}
