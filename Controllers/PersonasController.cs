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
        public async Task<ActionResult<int>> Post(Persona persona)
        {
            var parametroId = new SqlParameter("@id", SqlDbType.Int);
            parametroId.Direction = ParameterDirection.Output;

            await context.Database
                .ExecuteSqlInterpolatedAsync($@"
                                EXEC PersonasInsertar
                                @id={parametroId} OUTPUT,  
                                @nombre={persona.Nombre},
                                @genero={persona.Genero},
                                @edad={persona.Edad},
                                @identificacion={persona.Identificacion},
                                @direccion={persona.Direccion},
                                @telefono={persona.Telefono},
                                @activo={persona.Activo}");
            var id = (int)parametroId.Value;
            return Ok(id);
        }
    }
}
