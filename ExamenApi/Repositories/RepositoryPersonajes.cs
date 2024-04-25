using ExamenApi.Data;
using ExamenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenApi.Repositories
{
    public class RepositoryPersonajes
    {

        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        { 
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        public async Task InsertarPersonaje(int idPersonaje, string nombre, string imagen, string serie)
        { 
            Personaje personaje = new Personaje(); 
            personaje.IdPersonaje = idPersonaje;
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.Serie = serie;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonaje(int idPersonaje, string nombre, string imagen, string serie)
        {
            Personaje personaje = await this.FindPersonajeAsync(idPersonaje);
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.Serie = serie;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonaje(int id)
        {
            Personaje personaje = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }


        public async Task<List<string>> GetSeries()
        { 
            var query = (from datos in context.Personajes
                         select datos.Serie).Distinct();
            return await query.ToListAsync();
        }

        public async Task<List<Personaje>> GetPersonajesBySerie(string serie)
        {
            return await context.Personajes
                .Where(p => p.Serie == serie)
                .ToListAsync();
        }


    }
}
