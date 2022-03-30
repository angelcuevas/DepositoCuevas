using DepositoLib.deposito;
using DepositoLib.juegos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServices.database
{
    public static class TableQueryInfoFactory
    {
        public static TableQueryInfo getQueryInfo<T>() where T: class
        {
            switch (typeof(T))
            {
                case var cls when cls == typeof(Ubicacion):
                    return new UbicacionTableQueryINfo();
                case var cls when cls == typeof(Juego):
                    return new JuegoTableQueryInfo();


                default:
                    break;
            }

            return new JuegoTableQueryInfo();
        }
    }
}
