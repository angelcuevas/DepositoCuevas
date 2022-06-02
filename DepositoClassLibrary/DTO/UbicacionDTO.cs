using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoClassLibrary.DTO
{
    public class UbicacionDTO
    {
        private int id;
        private int nivel;
        private string estanteria;
        private string modulo;
        private int bancal;
        private string nombre;
        private int estadoActual;
        private int stateLess;

        public int Id { get; set; }
        public int Nivel { get; set; }
        public string Estanteria { get; set; }
        public string Modulo { get; set; }
        public int Bancal { get; set; }
        public string Nombre { get; set; }
        public int EstadoActual { get; set; }
        public int StateLess { get; set; }

        public String Descripcion
        {
            get
            {
                if(Estanteria != null && Modulo != null && Nivel != null && Bancal != null)
                {
                    return "E" + Estanteria + "-M" + Modulo + "-N" + Nivel + "-B" + Bancal;
                }

                return "";
            }
        }
    }
}
