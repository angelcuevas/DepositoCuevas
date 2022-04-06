using DepositoClassLibrary.deposito;
using DepositoClassLibrary.DTO;
using DepositoClassLibrary.juegos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServicesLibrary.database
{
    public static class TableQueryInfoFactory
    {
        public static TableQueryInfo getQueryInfo<T>() where T: class
        {
            switch (typeof(T))
            {
                case var cls when cls == typeof(Ubicacion):
                    return new UbicacionTableQueryINfo();
                case var cls when cls == typeof(JuegoDTO):
                    return new JuegoTableQueryInfo();
                case var cls when cls == typeof(MovimientoJuegoDTO):
                    return new JuegoMovimientoTableQueryInfo();
                case var cls when cls == typeof(MovimientoDTO):
                    return new MovimientoTableQueryInfo();

                default:
                    Console.WriteLine("DEFAULT");
                    break;
            }

            return new JuegoTableQueryInfo();
        }
    }
}
