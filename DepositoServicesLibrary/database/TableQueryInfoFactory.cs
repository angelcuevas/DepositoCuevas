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
                case var cls when cls == typeof(UbicacionDTO):
                    return new UbicacionTableQueryINfo();
                case var cls when cls == typeof(JuegoDTO):
                    return new JuegoTableQueryInfo();
                case var cls when cls == typeof(MovimientoJuegoDTO):
                    return new JuegoMovimientoTableQueryInfo();
                case var cls when cls == typeof(MovimientoDTO):
                    return new MovimientoTableQueryInfo();
                case var cls when cls == typeof(UbicacionesEstadosDTO):
                    return new UbicacionesEstadosTableQueryInfo();
                case var cls when cls == typeof(UbicacionesEstadosJuegosDTO):
                    return new UbicacionesEstadosJuegosTableQueryInfo();

                default:
                    Console.WriteLine("DEFAULT");
                    break;
            }

            return new JuegoTableQueryInfo();
        }
    }
}
