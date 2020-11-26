using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiPatternDDD.Domain;
using apiPatternDDD.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apiPatternDDD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _service;

        public HeroController(IHeroService service) =>
            _service = service;


        /// <summary>
        /// Lista todos os herois
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var hero = await _service.GetAllHeros();
                return new ObjectResult(hero) { StatusCode = StatusCodes.Status200OK };
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista um heroi por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var hero = await _service.GetHeroById(id);
                return new ObjectResult(hero) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Realiza a criação dos herois
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] Hero hero)
        {
            try
            {
                _service.InsertHeroAsync(hero);
                return new ObjectResult(hero) { StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Realiza a atualização dos herois
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Hero hero)
        {
            try
            {
                _service.UpdateHeroAsync(hero, id);
                return new ObjectResult(hero) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
