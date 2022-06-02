﻿using Dapper;
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
        private static SqliteDataAccess<MovimientoDTO> movimientoDataAccess = new SqliteDataAccess<MovimientoDTO>();
        private static SqliteDataAccess<JuegoCantidadDTO> juegoCantidadDataAccess = new SqliteDataAccess<JuegoCantidadDTO>();
        private static SqliteDataAccess<UbicacionesEstadosJuegosDTO> estadoJuegoCantidadDataAccess = new SqliteDataAccess<UbicacionesEstadosJuegosDTO>();

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

        public static Tuple<Juego,UbicacionEstadoActual, UbicacionEstadoActual, MovimientoDTO> moveFromOneUbicacionToAnother(UbicacionDTO origen, UbicacionDTO destino, List<JuegoEstadoCantidad> listaJuegos)
        {

            UbicacionEstadoActual origenEstado = getUbicacionYEstadoActual(origen);
            UbicacionEstadoActual destinoEstado = getUbicacionYEstadoActual(destino);

            MovimientoDTO movimientoDTO = crearNuevoMovimiento(origen, destino);

            if(origen.IsCreator == 1) { 
                listaJuegos.ForEach(j =>
                {
                    Tuple<Juego, MovimientoJuegoDTO> movimientoResponse = JuegoController.addMovimiento(origen, destino, j, movimientoDTO.Id);
                });
            }

            UbicacionEstadoActual nuevoEstadoOrigen = null;
            if (origen.StateLess == 0) { 
                nuevoEstadoOrigen = createNewStateFromOldOne(origenEstado, movimientoDTO, listaJuegos, TipoMovimiento.EGRESO);
            }

            UbicacionEstadoActual nuevoEstadoDestino = createNewStateFromOldOne(destinoEstado, movimientoDTO, listaJuegos, TipoMovimiento.INGRESO);


            return new Tuple<Juego, UbicacionEstadoActual, UbicacionEstadoActual, MovimientoDTO>(
            
                null,
                nuevoEstadoOrigen,
                nuevoEstadoDestino,
                movimientoDTO
            );
        }

        public static MovimientoDTO crearNuevoMovimiento(UbicacionDTO origen, UbicacionDTO destino )
        {
            int movimientoId = JuegoController.crearMovimiento(origen.Id, destino.Id);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", movimientoId);
            return movimientoDataAccess.getOne(" id = @Id", parameters);
        }

        public static UbicacionEstadoActual getUbicacionYEstadoActual(UbicacionDTO ubicacion )
        {
            UbicacionEstadoActual result = new UbicacionEstadoActual();

            UbicacionDTO ubicacionDTO = getUbicacionFromDB(ubicacion);
            result.Ubicacion = ubicacion;
            if(ubicacionDTO.EstadoActual != 0)
            {
                result.estado = getEstadoById(ubicacionDTO.EstadoActual);
                result.Cantidades = getEstadoContent(ubicacionDTO.EstadoActual);
            }

            return result; 
        }

        public static List<JuegoEstadoCantidad> getEstadoContent(int estadoId)
        {
            List<EstadoJuegoCantidad> lista = SqliteDataAccess<EstadoJuegoCantidad>.query("SELECT uej.*, uej.id as IdUbicacionesEstadosJuegosId, jc.*, j.*,  j.cantidad as CantidadJuego, jc.cantidad as JcCantidad  FROM ubicaciones_estados_juegos as uej LEFT JOIN juegos_cantidad as jc ON jc.id =  uej.juegos_cantidad_id LEFT JOIN juegos as j on j.id = jc.juego_id  WHERE uej.ubicaciones_estados_id = " + estadoId);

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
                    Cantidad = l.JcCantidad,
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
        public enum TipoMovimiento
        {
            INGRESO,
            EGRESO 
        }

        public static UbicacionEstadoActual createNewStateFromOldOne(UbicacionEstadoActual estadoActual, MovimientoDTO movimiento, List<JuegoEstadoCantidad> listaJuegos, TipoMovimiento tipoMovimiento)
        {
            if (estadoActual.Ubicacion.StateLess == 1)
            {
                return estadoActual;
            }

            UbicacionesEstadosDTO nuevoEstado = createNewEstadoConFechaYHoraActual(estadoActual, movimiento);
            //---desde
            listaJuegos.ForEach(j =>
            {
                createNewJuegoCantidad(estadoActual, movimiento, j, tipoMovimiento, nuevoEstado);
            });

            estadoActual.Cantidades.ForEach(c =>
            {

                if (!listaJuegos.Any(i=> i.JuegoDTO.Id == c.JuegoDTO.Id) )//c.JuegoDTO.Id != juegoInfo.JuegoCantidadDTO.Id
                {
                    estadoJuegoCantidadDataAccess.save(new UbicacionesEstadosJuegosDTO()
                    {
                        UbicacionesEstadosId = nuevoEstado.Id,
                        JuegosCantidadId = c.JuegoCantidadDTO.Id
                    });
                }


            });

            return getUbicacionYEstadoActual(estadoActual.Ubicacion);
        }

        public static void createNewJuegoCantidad(UbicacionEstadoActual estadoActual, MovimientoDTO movimiento, JuegoEstadoCantidad juegoInfo, TipoMovimiento tipoMovimiento, UbicacionesEstadosDTO nuevoEstado)
        {
            JuegoEstadoCantidad juegoYaExistente = estadoActual.Cantidades.Find(c => c.JuegoDTO.Id == juegoInfo.JuegoDTO.Id);
            

            JuegoCantidadDTO nuevoJuegoCantidad = new JuegoCantidadDTO()
            {
                JuegoId = juegoInfo.JuegoDTO.Id,
                Cantidad = getCantidadSegunTipoMovimiento(juegoYaExistente, juegoInfo, tipoMovimiento)
            };

            nuevoJuegoCantidad.Id = juegoCantidadDataAccess.save(nuevoJuegoCantidad);

            estadoActual.Ubicacion.EstadoActual = nuevoEstado.Id;
            ubicacionDataAccess.update(estadoActual.Ubicacion, " id = @Id");


            estadoJuegoCantidadDataAccess.save(new UbicacionesEstadosJuegosDTO()
            {
                UbicacionesEstadosId = nuevoEstado.Id,
                JuegosCantidadId = nuevoJuegoCantidad.Id
            });


        }

        public static int getCantidadSegunTipoMovimiento(JuegoEstadoCantidad estadoAnterior, JuegoEstadoCantidad juegoInfo, TipoMovimiento tipoMovimiento)
        {
            int cantidad = juegoInfo.JuegoCantidadDTO.Cantidad;

            if(tipoMovimiento == TipoMovimiento.EGRESO)
            {
                cantidad = cantidad * -1;
            }

            return (estadoAnterior != null) ? estadoAnterior.JuegoCantidadDTO.Cantidad + cantidad : cantidad;
        }

        public static UbicacionesEstadosDTO createNewEstadoConFechaYHoraActual(UbicacionEstadoActual estadoActual, MovimientoDTO movimiento)
        {
            UbicacionesEstadosDTO nuevoEstado = new UbicacionesEstadosDTO()
            {
                Fecha = DateTime.Now.ToString(),
                UbicacionId = estadoActual.Ubicacion.Id,
                MovimientoId = movimiento.Id
            };

            if (estadoActual.estado == null)
            {
                nuevoEstado.Numero = 1;
            }
            else
            {
                nuevoEstado.Numero = estadoActual.estado.Numero + 1;
            }

            nuevoEstado.Id = ubicacionEstadoDataAccess.save(nuevoEstado);

            return nuevoEstado;
        }
    }
}
