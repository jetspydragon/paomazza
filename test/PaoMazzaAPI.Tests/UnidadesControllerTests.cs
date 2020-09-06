using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using PaoMazzaAPI.Models;
using PaoMazzaAPI.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PaoMazzaAPI.Tests {

    public class UnidadesControllerTests : IDisposable
    {
        UnidadesController controller;
        DbContextOptionsBuilder<PaoMazzaAPIContext> optionsBuilder;
        PaoMazzaAPIContext dbContext;

        public UnidadesControllerTests()
        {
            // Arrange
            // DBContext - Se usará un contexto InMemory para no depender de una base de datos real
            optionsBuilder = new DbContextOptionsBuilder<PaoMazzaAPIContext>();
            optionsBuilder.UseInMemoryDatabase("UnitTestInMemDb");
            dbContext = new PaoMazzaAPIContext(optionsBuilder.Options);
            controller = new UnidadesController(dbContext);
        }

        [Fact]
        public void GetUnidades_ReturnsZero_WhenDBEmpty() {
            // Act
            var result = controller.GetUnidades();

            // Assert
            Assert.Empty(result.Value);
        }

        [Fact]
        public void GetUnidades_ReturnOne_WhenDBHasOnlyOne() {
            // Arrange
            var testUnidad = new Unidad {
                Abrev = "Kg",
                Nombre = "Kilogramo",
                RelBase = 1,
                Tipo = new UnidadTipo {
                    Tipo = "Peso"
                }
            };
            dbContext.Unidades.Add(testUnidad);
            dbContext.SaveChanges();

            // Act
            var result = controller.GetUnidades();

            // Assert
            Assert.Single(result.Value);
        }

        [Fact]
        public void GetUnidades_ReturnN_WhenDBHasN() {
            // Arrange
            Unidad testUnidad;
            testUnidad = new Unidad {
                Abrev = "Kg",
                Nombre = "Kilogramo",
                RelBase = 1,
                Tipo = new UnidadTipo {
                    Tipo = "Peso"
                }
            };
            dbContext.Unidades.Add(testUnidad);
            testUnidad = new Unidad {
                Abrev = "Kg",
                Nombre = "Kilogramo",
                RelBase = 1,
                Tipo = new UnidadTipo {
                    Tipo = "Peso"
                }
            };
            dbContext.Unidades.Add(testUnidad);
            dbContext.SaveChanges();

            // Act
            var result = controller.GetUnidades();

            // Assert
            Assert.Equal(2, result.Value.Count());
        }

        [Fact]
        public void GetUnidades_ReturnCorrectType() {
            var result = controller.GetUnidades();

            Assert.IsType<ActionResult<IEnumerable<Unidad>>>(result);
        }

        [Fact]
        public void GetUnidad_ReturnNull_WhenIDIsInvalid()
        {
            // Assert
            // Dbase is empty

            // Act
            var result = controller.GetUnidad(1);

            // Assert
            Assert.Null(result.Value);
        }

        [Fact]
        public void GetUnidad_Return404_WhenIDIsInvalid()
        {
            // Assert
            // Dbase is empty

            // Act
            var result = controller.GetUnidad(0);

            // Assert
            Assert.IsType<NotFoundResult>(result.Value);
        }

        [Fact]
        public void GetUnidad_ReturnCorrectType_WhenIDisValid()
        {
            // Arrange
            Unidad testUnidad;
            testUnidad = new Unidad {
                Abrev = "Kg",
                Nombre = "Kilogramo",
                RelBase = 1,
                Tipo = new UnidadTipo {
                    Tipo = "Peso"
                }
            };
            dbContext.Unidades.Add(testUnidad);
            dbContext.SaveChanges();
            var id = testUnidad.Id;

            // Act
            var result = controller.GetUnidad(id);

            // Assert
            Assert.IsType<Unidad>(result.Value);
        }

        [Fact]
        public void GetUnidad_ReturnCorrectUnidad_WhenIDisValid()
        {
            // Arrange
            Unidad testUnidad;
            testUnidad = new Unidad {
                Abrev = "Kg",
                Nombre = "Kilogramo",
                RelBase = 1,
                Tipo = new UnidadTipo {
                    Tipo = "Peso"
                }
            };
            dbContext.Unidades.Add(testUnidad);
            dbContext.SaveChanges();
            var id = testUnidad.Id;

            // Act
            var result = controller.GetUnidad(id);

            // Assert
            Assert.Equal(id, result.Value.Id);
        }

        [Fact]
        public void PostUnidad_WhenValidUnidad_CountUnidadesIncrementsBy1()
        {
            // Arrange
            var oldCount = dbContext.Unidades.Count();

            Unidad testUnidad;
            testUnidad = new Unidad {
                Abrev = "Kg",
                Nombre = "Kilogramo",
                RelBase = 1,
                Tipo = new UnidadTipo {
                    Tipo = "Peso"
                }
            };

            // Act
            var result = controller.PostUnidad(testUnidad);
            var newCount = dbContext.Unidades.Count();

            // Assert
            Assert.Equal(oldCount+1, newCount);
        }

        [Fact]
        public void PostUnidad_WhenValidUnidad_Return201Created()
        {
            // Arrange
            Unidad testUnidad;
            testUnidad = new Unidad {
                Abrev = "Kg",
                Nombre = "Kilogramo",
                RelBase = 1,
                Tipo = new UnidadTipo {
                    Tipo = "Peso"
                }
            };

            // Act
            var result = controller.PostUnidad(testUnidad);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result.Value);
        }

        public void Dispose()
        {
            optionsBuilder = null;
            foreach (var unidad in dbContext.Unidades) {
                dbContext.Unidades.Remove(unidad);
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            controller = null;
        }
    }
}