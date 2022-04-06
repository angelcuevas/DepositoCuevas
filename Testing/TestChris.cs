using System;
using System.Collections.Generic;
using System.Text;
using DepositoClassLibrary.DTO;
using NUnit.Framework;

namespace DepositoLibTesting
{
    class TestChris
    {
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
            Assert.NotNull (juego);
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
        
    }
}
