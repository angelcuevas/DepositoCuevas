using DepositoClassLibrary;
using DepositoClassLibrary.deposito;
using DepositoClassLibrary.DTO;
using DepositoServicesLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DepositoLibTesting
{
    public class Deposito
    {
        [SetUp]
        public void Setup()
        {
        }

        
        public void Test1()
        {
            Estanteria estanteria = new Estanteria();

        }
        [Test]
        public void GuardarJuego()
        {
            JuegoDTO juego = new JuegoDTO() { Codigo = "4050", Descripcion="No se repite"};

            SqliteDataAccess<JuegoDTO> dataAccess = new SqliteDataAccess<JuegoDTO>();
            dataAccess.save(juego);
            List<JuegoDTO> juegos = dataAccess.getAll();
            
            Assert.AreEqual(juego.Codigo, juegos.Find((j)=> j.Codigo == juego.Codigo).Codigo);
        }

        [Test]
        public void Ubicacion()
        {
            SqliteDataAccess<UbicacionDTO> dataAccess = new SqliteDataAccess<UbicacionDTO>();

            bool savedOk = true;

            try
            {
                dataAccess.save(new UbicacionDTO() { Estanteria = "1", Modulo =  "1", Nivel = 1, Bancal = 1, Nombre = "A1" });

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                savedOk = false; 
            }

            Assert.AreEqual(true, savedOk);
        }
        [Test]
        public void pruebaDeposito()
        {
            Deposito deposito = new Deposito();

            Assert.NotNull(deposito);
        }

        [Test]

        public void notNullTest()
        {
            Assert.NotNull(1);
        }
    }
}