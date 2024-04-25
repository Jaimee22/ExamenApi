using ExamenApi.Models;
using ExamenApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InsertPersonaje(Personaje personaje)
        {
            await this.repo.InsertarPersonaje(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen, personaje.Serie);
            return Ok();
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonaje(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen, personaje.Serie);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonaje(id);
            return Ok();
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> GetSeries()
        { 
            var series = await this.repo.GetSeries();   
            return Ok(series);
        }

        [HttpGet]
        [Route("[action]/{serie}")]
        public async Task<ActionResult<List<Personaje>>> FindPersonajesPorSerie(string serie)
        {
            var personajes = await repo.GetPersonajesBySerie(serie);
            return Ok(personajes);
        }



    }
}
