using DepositoLib.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoLib.juegos
{
    public class Juego
    {
        private JuegoDTO juego;
        
        public Juego(JuegoDTO juego)
        {
            this.juego = juego; 
        }

        public JuegoDTO getJuego()
        {
            return this.juego;
        }

        public int getCantidad()
        {
            return this.juego.Cantidad;
        }
        public void setCantidad(int cantidad)
        {
            this.juego.Cantidad = cantidad;
        }
    }
}
