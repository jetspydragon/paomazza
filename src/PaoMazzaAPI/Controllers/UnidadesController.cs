using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PaoMazzaAPI.Controllers {

    [Route("/api/unidades")]
    [ApiController]
    public class UnidadesController : ControllerBase {

        [HttpGet]
        public ActionResult <IEnumerable<string>> DemoLambdaAction() => new string[] { "this", "is", "hard", "coded" };

        
    }
}