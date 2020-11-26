using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiPatternDDD.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apiPatternDDD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {

        public HeroController()
        {
        }

        [HttpGet]
        public ActionResult<Hero> Get()
        {
            return Ok();
        }
    }
}
