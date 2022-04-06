using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoClassLibrary.deposito
{
    public class Ubicacion
    {
        private int id; 
        private int nivel;
        private string fila;
        private string columna; 
        private string nombre; 
        
        public int Nivel { get; set; }
        public string Fila { get; set; }
        public string Columna { get; set; }
        public string Nombre { get; set; }

        public int Id { get; set; }

        public Ubicacion(int nivel, string fila, string columna, string nombre)
        {
            this.nivel = nivel;
            this.fila = fila;
            this.columna = columna;
            this.nombre = nombre;
        }
        public Ubicacion() { }
    }
}
