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
        
    }
}