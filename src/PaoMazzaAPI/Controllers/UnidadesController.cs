using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PaoMazzaAPI.Models;

namespace PaoMazzaAPI.Controllers {

    [Route("/api/unidades")]
    [ApiController]
    public class UnidadesController : ControllerBase {

        private readonly PaoMazzaAPIContext _context;

        public UnidadesController(PaoMazzaAPIContext context) => _context = context;

        /*[HttpGet]
        public ActionResult <IEnumerable<string>> DemoLambdaAction() => new string[] { "this", "is", "hard", "coded" };*/

        [HttpGet]
        public ActionResult<IEnumerable<Unidad>> GetUnidades() {
            return _context.Unidades;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Unidad> GetUnidad(int id)
        {
            var unidad = _context.Unidades.Find(id);

            if (unidad == null)
            {
                return NotFound();
            }

            return unidad;
        }

        [HttpPost]
        public ActionResult<Unidad> PostUnidad(Unidad unidad)
        {
            _context.Unidades.Add(unidad);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return CreatedAtAction("GetUnidad", new Unidad{ Id = unidad.Id }, unidad);
        }
    }
}