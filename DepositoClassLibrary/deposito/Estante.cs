using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoClassLibrary.deposito
{
    public class Estante
    {
        private int id;
        private int id_ubicacion; 
        private Ubicacion ubicacion;

        public int Id { get; set; }
        public int Id_ubicacion { get; set; }



        public Estante(int id, int id_ubicacion)
        {
            this.id = id;
            this.id_ubicacion = id_ubicacion;

        }
        public Estante() { }
    }
}
