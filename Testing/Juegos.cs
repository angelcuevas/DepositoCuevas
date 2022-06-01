using DepositoServicesLibrary.Controllers;
using DepositoClassLibrary.DTO;
using DepositoClassLibrary.juegos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using DepositoServicesLibrary;

namespace DepositoLibTesting
{
    class Juegos
    {
        private Juego juego; 

        [SetUp]
        public void Setup()
        {
            try
            {
                JuegoDTO juegoDTO = new JuegoDTO() { Codigo = "4050", Descripcion = "No se repite" };
                this.juego = JuegoController.saveAndGet(juegoDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        [Test]
        public void getCantidad()
        {
            try
            {
                Juego miJuego = JuegoController.getOne("4050");
                Console.WriteLine(miJuego.getJuego().Descripcion + " cantidad " + miJuego.getCantidad());
                Assert.GreaterOrEqual(miJuego.getCantidad(), 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.False(false);
            }

        }
        [Test]
        public void actualizarCantidadDeFormaDirecta()
        {
            int cantidadOriginal = juego.getJuego().Cantidad;
            juego.getJuego().Cantidad++;
            juego.getJuego().Descripcion = "cambie";

            Console.WriteLine("id " + juego.getJuego().Id);
            Console.WriteLine("cantidadOriginal " + cantidadOriginal);
            try
            {
                Juego juegoCambiado = JuegoController.update(juego);
                Assert.AreNotEqual(cantidadOriginal, juegoCambiado.getCantidad());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.False(false);
            }
        }

        [Test]
        public void agregarMovimientoRandom()
        {
            Random rnd = new Random();

            UbicacionDTO origen = UbicacionController.getUbicacionFromDB(new UbicacionDTO(){
                Estanteria = "1",
                Modulo = "1",
                Nivel = 1,
                Bancal = 1
            });

            UbicacionDTO destino = UbicacionController.getUbicacionFromDB(new UbicacionDTO()
            {
                Estanteria = "1",
                Modulo = "1",
                Nivel = 1,
                Bancal = 2
            });

            //Tuple<Juego, MovimientoJuegoDTO> tuple = JuegoController.addMovimiento(origen, destino, juego, rnd.Next(5, 200));

            var result = UbicacionController.moveFromOneUbicacionToAnother(origen, destino, juego, rnd.Next(5, 200));
            

            result = UbicacionController.moveFromOneUbicacionToAnother(origen, destino, juego, rnd.Next(5, 200));
            Juego juegoModificado = result.Item1;

            Assert.GreaterOrEqual(juegoModificado.getCantidad(), juego.getCantidad());
        }

        [Test]
        public void InstanciarMovimientoJuego()
        {
            List<MovimientoJuego> lista = JuegoController.getMovimientosTest(juego);
            Console.WriteLine("COUNT " + lista.Count);
            Assert.Greater(lista.Count, 0);
        }

        [Test]

        public void LoadUbicaciones()
        {
            List<int> cantidadDeModulosIzquierda = new List<int>() { 6, 7, 7, 7, 5, 6, 5, 7, 6, 6, 7 };
            List<int> cantidadDeModulosDerecha = new List<int>() { 7, 6, 6, 6, 5, 6 };

            cantidadDeModulosIzquierda.Reverse();
            cantidadDeModulosDerecha.Reverse();

            int contadorEstanterias = 1;

            cantidadDeModulosIzquierda.ForEach(e =>
            {
                CreateUbicacionesDeEstanteria(contadorEstanterias, e);
                contadorEstanterias++;
            });

            cantidadDeModulosDerecha.ForEach(e =>
            {
                CreateUbicacionesDeEstanteria(contadorEstanterias, e);
                contadorEstanterias++;
            });

        }

        private void CreateUbicacionesDeEstanteria(int numeroEstanteria, int cantidadDeModulos)
        {
            SqliteDataAccess<UbicacionDTO> ubicacionDataAccess = new SqliteDataAccess<UbicacionDTO>();
            for (int m = 0; m < cantidadDeModulos; m++)
            {
                for (int n = 0; n < 3; n++)
                {
                    for (int b = 0; b < 2; b++)
                    {
                        ubicacionDataAccess.save(new UbicacionDTO(){
                            Estanteria = ""+numeroEstanteria,
                            Modulo = ""+(m + 1),
                            Nivel = n + 1,
                            Bancal = b +1
                        });
                    }
                }
            }
        }

        

    }
}
