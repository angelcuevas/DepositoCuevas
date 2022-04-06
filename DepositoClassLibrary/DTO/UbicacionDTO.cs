using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoClassLibrary.DTO
{
    public class UbicacionDTO
    {
        private int id;
        private int nivel;
        private string fila;
        private string columna;
        private string nombre;

        public int Id { get; set; }
        public int Nivel { get; set; }
        public string Fila { get; set; }
        public string Columna { get; set; }
        public string Nombre { get; set; }
    }
}
