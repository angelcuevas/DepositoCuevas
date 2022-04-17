using DepositoClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoClassLibrary.juegos
{
    public class MovimientoJuego
    {
        private JuegoDTO juegoDTO;
        public JuegoDTO JuegoDTO
        {
            get { return juegoDTO; }
            set { juegoDTO = value; }
        }

        private MovimientoJuegoDTO movimientoJuegoDTO;
        public MovimientoJuegoDTO MovimientoJuegoDTO
        {
            get { return MovimientoJuegoDTO; }
            set { MovimientoJuegoDTO = value; }
        }
    }
}
