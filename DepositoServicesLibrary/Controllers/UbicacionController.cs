using Dapper;
using DepositoClassLibrary.deposito;
using DepositoClassLibrary.DTO;
using DepositoClassLibrary.DTOscombinados;
using DepositoClassLibrary.juegos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoServicesLibrary.Controllers
{
    public static class UbicacionController
    {
        private static SqliteDataAccess<UbicacionDTO> ubicacionDataAccess = new SqliteDataAccess<UbicacionDTO>();
        private static SqliteDataAccess<UbicacionesEstadosDTO> ubicacionEstadoDataAccess = new SqliteDataAccess<UbicacionesEstadosDTO>();
        private static SqliteDataAccess<UbicacionesEstadosJuegosDTO> ubicacionEstadosJuegosDataAccess = new SqliteDataAccess<UbicacionesEstadosJuegosDTO>();

        public static UbicacionesEstadosJuegosDTO saveAndGet(UbicacionesEstadosJuegosDTO ubicacionesEstadosJuegosDTO)
        {
            int id = ubicacionEstadosJuegosDataAccess.save(ubicacionesEstadosJuegosDTO);
            return getOne(id);
        }

        public static UbicacionesEstadosJuegosDTO getOne(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            UbicacionesEstadosJuegosDTO ubicacionesEstadosJuegosDTO = ubicacionEstadosJuegosDataAccess.getOne("id = @Id", parameters);
            if (ubicacionesEstadosJuegosDTO == null)
            {
                throw new Exception("No existe");
            }

            return ubicacionesEstadosJuegosDTO;
        }

        public static object moveFromOneUbicacionToAnother(UbicacionDTO origen, UbicacionDTO destino, JuegoDTO juego, int cantidad)
        {

            UbicacionEstadoActual origenEstado = getUbicacionYEstadoActual(origen);
            UbicacionEstadoActual destinoEstado = getUbicacionYEstadoActual(destino);



            return new object();
        }

        public static UbicacionEstadoActual getUbicacionYEstadoActual(UbicacionDTO ubicacion )
        {
            UbicacionEstadoActual result = new UbicacionEstadoActual();

            UbicacionDTO ubicacionDTO = getUbicacionFromDB(ubicacion);

            if(ubicacionDTO.EstadoActual != 0)
            {
                result.estado = getEstadoById(ubicacionDTO.EstadoActual);
                result.Cantidades = getEstadoContent(ubicacionDTO.EstadoActual);
            }

            return result; 
        }

        public static List<JuegoEstadoCantidad> getEstadoContent(int estadoId)
        {
            List<EstadoJuegoCantidad> lista = SqliteDataAccess<EstadoJuegoCantidad>.query("SELECT uej.*, uej.id as IdUbicacionesEstadosJuegosId, jc.*, j.*, j.cantidad as CantidadJuego  FROM ubicaciones_estados_juegos as uej LEFT JOIN juegos_cantidad as jc ON jc.id =  uej.juegos_cantidad_id LEFT JOIN juegos as j on j.id = jc.juego_id  WHERE  = uej.ubicaciones_estados_id" + estadoId);

            return lista.Select(l => new JuegoEstadoCantidad()
            {
                JuegoDTO = new JuegoDTO()
                {
                    Id = l.JuegoId,
                    Cantidad = l.CantidadJuego,
                    Descripcion = l.Descripcion,
                    Codigo = l.Codigo
                },
                JuegoCantidadDTO = new JuegoCantidadDTO()
                {
                    Id = l.JuegosCantidadId,
                    Cantidad = l.Cantidad,
                    JuegoId = l.JuegoId

                },

                UbicacionesEstadosJuegosDTO = new UbicacionesEstadosJuegosDTO()
                {
                    Id = l.IdUbicacionesEstadosJuegosId,
                    UbicacionesEstadosId = l.UbicacionesEstadosId,
                    JuegosCantidadId = l.JuegosCantidadId

                }

            }).ToList<JuegoEstadoCantidad>();
        }

        public static UbicacionDTO getUbicacionFromDB(UbicacionDTO ubicacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            string query = "";
            if (ubicacion.StateLess == 0) { 
                parameters.Add("@Estanteria", ubicacion.Estanteria);
                parameters.Add("@Modulo", ubicacion.Modulo);
                parameters.Add("@Nivel", ubicacion.Nivel);
                parameters.Add("@Bancal", ubicacion.Bancal);
                query = " estanteria = @Estanteria AND modulo = @Modulo AND nivel = @Nivel AND bancal = @Bancal ";
            }

            if (ubicacion.StateLess == 1)
            {
                parameters.Add("@Nombre", ubicacion.Nombre);

                query = " nombre = @Nombre ";
            }



            return ubicacionDataAccess.getOne(query, parameters);
        }

        public static UbicacionesEstadosDTO getEstadoById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return ubicacionEstadoDataAccess.getOne(" id = @Id", parameters);
        }
    }
}
