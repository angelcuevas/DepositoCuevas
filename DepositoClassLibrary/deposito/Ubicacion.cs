using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoClassLibrary.deposito
{
    public class Ubicacion
    {
        private int id; 
        private int nivel;
        private string estanteria;
        private string modulo;
        private int bancal;
        private string nombre; 
        
        public int Nivel { get; set; }
        public string Estanteria { get; set; }
        public string Modulo { get; set; }
        public string Nombre { get; set; }

        public int Bancal { get; set; }

        public int Id { get; set; }

    }
}
