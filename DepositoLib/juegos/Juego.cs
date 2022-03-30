using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoLib.juegos
{
    public class Juego
    {
        private int id; 
        private string codigo;
        private string descripcion; 

        public int Id
        {
            get;set; 
        }
        public string Codigo
        {
            get;set;
        }
        public string Descripcion
        {
            get;set;
        }
    }
}
