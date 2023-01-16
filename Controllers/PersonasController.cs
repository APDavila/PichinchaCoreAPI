using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PichinchaCoreAPI.Entidades;
using System.Data;

namespace PichinchaCoreAPI.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonasController(ApplicationDbContext context)
        {            
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Persona persona)
        {
            try
            {                           
                context.Personas.Add(persona);
                await context.SaveChangesAsync();
                return Created($"/getPersonaById?id={persona.Id}", persona);
                //return Ok("Persona insertada con éxito");
            }catch(Exception err)
            {
                return NotFound("Problemas en la inserción");
            }                                                                
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int personaId)
        {
            try
            {
                var persona = new Persona { Id = personaId };
                context.Personas.Attach(persona);
                context.Personas.Remove(persona);
                context.SaveChanges();
                return Ok("Persona eliminada exitosamente");
            }
            catch (Exception err)
            {
                return NotFound("Problemas en la elminación"+err.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var personas = await context.Personas.ToListAsync();
                return Ok(personas);
            }
            catch (Exception err)
            {
                return NotFound("Problemas en la elminación" + err.Message);
            }
        }

        [HttpGet]
        [Route("getPersonaById")]
        public async Task<IActionResult> GetPersonByIdAsync(int id)
        {
            var persona = await context.Personas.FindAsync(id);
            return Ok(persona);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Persona personaToUpdate)
        {
            context.Personas.Update(personaToUpdate);
            await context.SaveChangesAsync();
            return Ok("Registro actualizado con éxito");
        }
    }
}
