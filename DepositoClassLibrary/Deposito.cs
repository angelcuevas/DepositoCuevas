using DepositoClassLibrary.deposito;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoClassLibrary
{
    public class Deposito
    {
        private List<Estanteria> estanterias = new List<Estanteria>();

        public List<Estanteria> Estanterias { get; set; }
    }
}
