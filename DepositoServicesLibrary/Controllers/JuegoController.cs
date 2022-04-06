using Dapper;
using DepositoClassLibrary.DTO;
using DepositoClassLibrary.juegos;
using DepositoServices;
using DepositoServicesLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoServicesLibrary.Controllers
{
    public static class JuegoController
    {
        private static SqliteDataAccess<JuegoDTO> dataAccess = new SqliteDataAccess<JuegoDTO>();
        private static SqliteDataAccess<MovimientoJuegoDTO> movimientoJuegoDataAccess = new SqliteDataAccess<MovimientoJuegoDTO>();
        private static SqliteDataAccess<MovimientoDTO> movimientoDataAccess = new SqliteDataAccess<MovimientoDTO>();
        
        public static List<Juego> getAll()
        {
            List<Juego> lista = dataAccess.getAll().ConvertAll(j => new Juego(j));
            return lista; 
        }

        public static Juego saveAndGet(JuegoDTO juegoDTO)
        {
            dataAccess.save(juegoDTO);

            return getOne(juegoDTO.Codigo);
        }
        public static Juego getOne(string codigo)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Codigo", codigo);
            JuegoDTO juego = dataAccess.getOne("codigo = @Codigo", parameters);

            if (juego == null)
            {
                throw new Exception("No existe");
            }

            return new Juego(juego);
        } 

        public static Juego update(Juego juego)
        {
            dataAccess.update(juego.getJuego(), " id = @Id");
            return getOne(juego.getJuego().Codigo);
        }
        public static int crearMovimiento(int ubicacionOrigen, int ubicacionDestino)
        {
            MovimientoDTO movimiento = new MovimientoDTO() {Fecha = DateTime.Now.ToLocalTime(), UbicacionOrigen = ubicacionDestino, UbicacionDestino = ubicacionDestino, Comentario = ""  } ;
            return movimientoDataAccess.save(movimiento);
        }
        public static MovimientoJuegoDTO crearNuevoMovimiento(Juego juego, int cantidad)
        {
            List<MovimientoJuegoDTO> lista = movimientoJuegoDataAccess.getAll(" juego_id = " + juego.getJuego().Id);

            MovimientoJuegoDTO movimiento = new MovimientoJuegoDTO();
            int id = crearMovimiento(0, 9);

            movimiento.MovimientoId = id;
            movimiento.JuegoId = juego.getJuego().Id;
            
            if(lista.Count > 0)
            {
                MovimientoJuegoDTO ultimo = lista[lista.Count - 1];
                movimiento.SaldoAnterior = ultimo.Saldo; 

            }
            movimiento.Cantidad = cantidad;
            movimiento.Saldo = movimiento.SaldoAnterior + movimiento.Cantidad;

            return movimiento;
        }

        public static Juego addMovimiento(Juego juego, int cantidad)
        {
            
            MovimientoJuegoDTO nuevoMovimiento = crearNuevoMovimiento(juego, cantidad);
            movimientoJuegoDataAccess.save(nuevoMovimiento);
            juego.setCantidad(nuevoMovimiento.Saldo);

            return update(juego);
        }
    }
}
