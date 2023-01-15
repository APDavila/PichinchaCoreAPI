using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PichinchaCoreAPI.Entidades;
using System.Data;

namespace PichinchaCoreAPI.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ClientesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Cliente cliente)
        {
            try
            {
                context.Clientes.Add(cliente);
                await context.SaveChangesAsync();
                return Created($"/getClienteById?id={cliente.Id}", cliente);
                //return Ok("Persona insertada con éxito");
            }
            catch (Exception err)
            {
                return NotFound("Problemas en la inserción");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int clienteId)
        {
            try
            {
                var cliente = new Cliente { Id = clienteId };
                context.Clientes.Attach(cliente);
                context.Clientes.Remove(cliente);
                context.SaveChanges();
                return Ok("Cliente eliminada exitosamente");
            }
            catch (Exception err)
            {
                return NotFound("Problemas en la elminación" + err.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var clientes = await context.Clientes.ToListAsync();
                return Ok(clientes);
            }
            catch (Exception err)
            {
                return NotFound("Problemas en la elminación" + err.Message);
            }
        }

        [HttpGet]
        [Route("getClienteById")]
        public async Task<IActionResult> GetClientByIdAsync(int id)
        {
            var cliente = await context.Clientes.FindAsync(id);
            return Ok(cliente);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Cliente clienteToUpdate)
        {
            context.Clientes.Update(clienteToUpdate);
            await context.SaveChangesAsync();
            return Ok("Registro actualizado con éxito");
        }
    }
}
