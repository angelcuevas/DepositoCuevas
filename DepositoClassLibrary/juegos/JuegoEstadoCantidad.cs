using DepositoClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoClassLibrary.juegos
{
    public class JuegoEstadoCantidad
    {
        private JuegoDTO juegoDTO;

        public JuegoDTO JuegoDTO
        {
            get { return juegoDTO; }
            set { juegoDTO = value; }
        }

        private JuegoCantidadDTO juegoCantidadDTO;

        public JuegoCantidadDTO JuegoCantidadDTO
        {
            get { return juegoCantidadDTO; }
            set { juegoCantidadDTO = value; }
        }

        private UbicacionesEstadosJuegosDTO ubicacionesEstadosJuegosDTO;

        public UbicacionesEstadosJuegosDTO UbicacionesEstadosJuegosDTO
        {
            get { return ubicacionesEstadosJuegosDTO; }
            set { ubicacionesEstadosJuegosDTO = value; }
        }



    }
}
