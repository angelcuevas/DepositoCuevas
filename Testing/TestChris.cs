using System;
using System.Collections.Generic;
using System.Text;
using DepositoClassLibrary.DTO;
using DepositoServicesLibrary.Controllers;
using NUnit.Framework;

namespace DepositoLibTesting
{
    class TestChris
    {
        UbicacionesEstadosJuegosDTO ubicacionEstadoJuego;

        [SetUp]
        public void Setup()
        {
            try
            {


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [Test]
        public void primero()
        {
            Assert.NotNull(1);
        }

        [Test]
        public void instanciarEstanteriaDTO()
        {
            EstanteriaDTO estanteria = new EstanteriaDTO();
            estanteria.Nombre = "pepito";
            Assert.NotNull(estanteria);
        }
        [Test]
        public void instanciarJuegoDTO()
        {
            JuegoDTO juego = new JuegoDTO();
            juego.Id = 12;
            juego.Codigo = "codigo 12";
            juego.Descripcion = "descripcion codigo 12";
            Assert.NotNull(juego);
        }
        [Test]
        public void instanciarUbicacionDTO()
        {
            UbicacionDTO ubicacion = new UbicacionDTO();
            ubicacion.Id = 13;
            ubicacion.Nivel = 14;
            ubicacion.Fila = "fila 13 14";
            ubicacion.Columna = "Columna 13 fila 14";
            ubicacion.Nombre = "Nombre";
            Assert.NotNull(ubicacion);
        }

        [Test]
        public void instanciarUbicacionesEstadosDTO()
        {
            UbicacionesEstadosDTO ubicacionEstado = new UbicacionesEstadosDTO();
            ubicacionEstado.Fecha = "2014-02-013";
            ubicacionEstado.Movimiento_id = 1;
            Assert.NotNull(ubicacionEstado);
        }
        [Test]
        public void instanciarUbicacionesEstadosJuegosDTO()
        {
            ubicacionEstadoJuego = new UbicacionesEstadosJuegosDTO();
            ubicacionEstadoJuego.Ubicaciones_estados_id = 1;
            ubicacionEstadoJuego.Juegos_id = 1;
            ubicacionEstadoJuego.Cantidad = 1;
            Assert.NotNull(ubicacionEstadoJuego);
        }
        [Test]
        public void GuardarUbicacionEstadoJuegoEnBase()
        {
            this.ubicacionEstadoJuego = new UbicacionesEstadosJuegosDTO() { Ubicaciones_estados_id = 1, Juegos_id = 1, Cantidad = 201 };
            try
            {
                this.ubicacionEstadoJuego = UbicacionController.saveAndGet(ubicacionEstadoJuego);

            }
            catch (Exception)
            {
                Assert.NotNull(null);
            }
        }

    }
}
