using Dapper;
using DepositoClassLibrary.DTO;
using DepositoClassLibrary.juegos;
using DepositoServices;
using DepositoServicesLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Slapper;
using System.Linq;
using System.Reflection;
using DepositoClassLibrary.DTOscombinados;

namespace DepositoServicesLibrary.Controllers
{
    public static class JuegoController
    {
        private static SqliteDataAccess<JuegoDTO> dataAccess = new SqliteDataAccess<JuegoDTO>();
        private static SqliteDataAccess<MovimientoJuegoDTO> movimientoJuegoDataAccess = new SqliteDataAccess<MovimientoJuegoDTO>();
        private static SqliteDataAccess<MovimientoDTO> movimientoDataAccess = new SqliteDataAccess<MovimientoDTO>();
        
        public static string createWhereString(string where)
        {
            if (where == "") return "";

            return " codigo like '%" + where + "%' OR  descripcion like '%" + where + "%' ";
        }
        public static List<Juego> getAll(string where  = "")
        {
            List<Juego> lista = dataAccess.getAll(createWhereString(where)).ConvertAll(j => new Juego(j));
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

        public static Juego update(JuegoDTO juego)
        {
            dataAccess.update(juego, " id = @Id");
            return getOne(juego.Codigo);
        }
        public static int crearMovimiento(int ubicacionOrigen, int ubicacionDestino)
        {
            MovimientoDTO movimiento = new MovimientoDTO() {Fecha = DateTime.Now.ToLocalTime(), UbicacionOrigen = ubicacionOrigen, UbicacionDestino = ubicacionDestino, Comentario = ""  } ;
            return movimientoDataAccess.save(movimiento);
        }
        public static MovimientoJuegoDTO crearNuevoMovimiento(UbicacionDTO origen, UbicacionDTO destino, JuegoEstadoCantidad juegoInfo)
        {
            List<MovimientoJuegoDTO> lista = movimientoJuegoDataAccess.getAll(" juego_id = " + juegoInfo.JuegoDTO.Id);

            MovimientoJuegoDTO movimiento = new MovimientoJuegoDTO();
            int id = crearMovimiento(origen.Id, destino.Id);

            movimiento.MovimientoId = id;
            movimiento.JuegoId = juegoInfo.JuegoDTO.Id;
            
            if(lista.Count > 0)
            {
                MovimientoJuegoDTO ultimo = lista[lista.Count - 1];
                movimiento.SaldoAnterior = ultimo.Saldo; 

            }
            movimiento.Cantidad = juegoInfo.JuegoCantidadDTO.Cantidad;
            movimiento.Saldo = movimiento.SaldoAnterior + movimiento.Cantidad;

            return movimiento;
        }

        public static Tuple<Juego, MovimientoJuegoDTO> addMovimiento(UbicacionDTO origen, UbicacionDTO destino, JuegoEstadoCantidad juegoInfo)
        {
            
            MovimientoJuegoDTO nuevoMovimiento = crearNuevoMovimiento(origen, destino, juegoInfo);
            movimientoJuegoDataAccess.save(nuevoMovimiento);
            juegoInfo.JuegoDTO.Cantidad = nuevoMovimiento.Saldo;
            

            return new Tuple<Juego, MovimientoJuegoDTO>(update(juegoInfo.JuegoDTO), nuevoMovimiento);
        }

        public static List<MovimientoJuegoDTO> getMovimientos(Juego juego ) {
            return movimientoJuegoDataAccess.getAll(" juego_id = " + juego.getJuego().Id);
        }

        public static Dictionary<String, object> processFila(object o)
        {
            return o.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(o, null));
        }

        public static string mapUbicacionFieldNames(string alias)
        {
            string result = "";
            string[] fields = new string[] { "nivel", "fila", "columna", "nombre"};

            foreach (var field in fields)
            {
                result += alias + "." + field;
            }

            return result; 
        }
        public static List<MovimientoJuego> getMovimientosTest(Juego juego)
        {

            //Slapper.AutoMapper.Map<Customer>(list);
            List<Movimiento> lista = SqliteDataAccess<Movimiento>.query("SELECT mj.id AS movimientoJuegoId, mj.cantidad as MovimientoJuegoCantidad, mj.*, j.*, m.*, ud.*, ud.id AS ubicacionDestinoId, uo.id AS ubicacionOrigenId, uo.nivel as nivelOrigen, uo.estanteria as estanteriaOrigen, uo.modulo as ModuloOrigen, uo.bancal as bancalOrigen, uo.nombre as nombreOrigen  FROM movimientos_juego as mj LEFT JOIN juegos as j ON j.id = mj.juego_id LEFT JOIN movimientos as m ON m.id = mj.movimiento_id LEFT JOIN ubicaciones as ud ON ud.id = m.ubicacion_destino LEFT JOIN ubicaciones as uo ON uo.id = m.ubicacion_origen  WHERE j.codigo = " + juego.getJuego().Codigo);

            return lista.Select(l => new MovimientoJuego()
            {
                JuegoDTO = new JuegoDTO()
                {
                    Id = l.JuegoId,
                    Cantidad = l.JuegoCantidad,
                    Descripcion = l.Descripcion,
                    Codigo = l.Codigo
                },
                MovimientoJuegoDTO = new MovimientoJuegoDTO()
                {
                    Id = l.MovimientoJuegoId,
                    Cantidad = l.MovimientoJuegoCantidad,
                    MovimientoId = l.MovimientoId,
                    JuegoId = l.JuegoId,
                    SaldoAnterior = l.SaldoAnterior,
                    Saldo = l.Saldo
                },
                UbicacionOrigenDTO = new UbicacionDTO()
                {
                    Id = l.UbicacionOrigenId,
                    Nombre = l.NombreORigen,
                    Estanteria = l.EstanteriaOrigen,
                    Modulo = l.ModuloOrigen,
                    Bancal = l.BancalOrigen,
                    Nivel = l.NivelOrigen
                },
                UbicacionDestinoDTO = new UbicacionDTO()
                {
                    Id = l.UbicacionDestinoId,
                    Nombre = l.Nombre,
                    Estanteria = l.Estanteria,
                    Modulo = l.Modulo,
                    Bancal = l.Bancal,
                    Nivel = l.Nivel

                }
                
            }).ToList<MovimientoJuego>();

            
        }
    }
}
