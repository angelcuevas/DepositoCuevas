using DepositoLib;
using DepositoLib.deposito;
using DepositoLib.DTO;
using DepositoLib.juegos;
using DepositoServices;
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
            SqliteDataAccess<Ubicacion> dataAccess = new SqliteDataAccess<Ubicacion>();

            bool savedOk = true;

            try
            {
                dataAccess.save(new Ubicacion() { Nivel = 1, Columna = "A", Fila =  "1", Nombre = "A1" });
                dataAccess.save(new Ubicacion() { Nivel = 1, Columna = "A", Fila = "2", Nombre = "A2" });
                dataAccess.save(new Ubicacion() { Nivel = 1, Columna = "A", Fila = "3", Nombre = "A3" });
                dataAccess.save(new Ubicacion() { Nivel = 1, Columna = "A", Fila = "4", Nombre = "A4" });
                dataAccess.save(new Ubicacion() { Nivel = 1, Columna = "A", Fila = "5", Nombre = "A5" });
                dataAccess.save(new Ubicacion() { Nivel = 1, Columna = "A", Fila = "6", Nombre = "A6" });
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