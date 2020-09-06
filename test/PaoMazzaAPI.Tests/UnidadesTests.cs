using Xunit;
using PaoMazzaAPI.Models;
using System;

namespace PaoMazzaAPI.Tests {

    public class UnidadesTests : IDisposable {

        Unidad testUnidad;

        // El constructor se ejecuta por cada Test
        public UnidadesTests() {
            testUnidad = new Unidad {
                Abrev = "Kg",
                Nombre = "Kilogramo",
                RelBase = 1,
                Tipo = new UnidadTipo {
                    Tipo = "Peso"
                }
            };
        }

        [Fact]
        public void CanChangeNombre() {
            // Act
            testUnidad.Nombre = "Nombre cambiado";

            // Assert
            Assert.Equal("Nombre cambiado", testUnidad.Nombre);
        }

        [Fact]
        public void CanChangeRelBase() {
            testUnidad.RelBase = 10;
            Assert.Equal(10, testUnidad.RelBase);
        }

        public void Dispose()
        {
            testUnidad = null;
        }
    }
}