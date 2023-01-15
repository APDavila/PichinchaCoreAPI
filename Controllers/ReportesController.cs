using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PichinchaCoreAPI.Entidades;
using System.Data;

namespace PichinchaCoreAPI.Controllers
{
    [ApiController]
    [Route("api/reportes")]
    public class ReportesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ReportesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get(int clienteId, DateTime fechaInicio, DateTime fechafin)
        {
            try
            {
                //var movimientos = await context.Movimientos.ToListAsync();
                //var movimientos = await context.Movimientos.Include(x => x.CuentaId == cuentaId).ToListAsync();
                //var movimientos = await context.Movimientos.Join(context.Cuentas, Movimiento=>Movimiento.CuentaId, 
                //    Cuenta =>Cuenta.Id,(Movimiento, Cuenta) => new { Movimiento, Cuenta }).ToListAsync();
                /*var movimientos = await context.Movimientos.Join(context.Cuentas, Movimiento => Movimiento.CuentaId,
                    Cuenta => Cuenta.Id, (Movimiento, Cuenta) => new { Movimiento, Cuenta }).
                    Join(context.Clientes, Movimiento => Movimiento.Cuenta.ClienteId, Cliente => Cliente.Id,
                     (Movimiento, Cliente) => new { Movimiento.Movimiento, Movimiento.Cuenta, Cliente }).ToListAsync();
                */

                var movimientos = from Movimientos in context.Movimientos
                                  join Cuenta in context.Cuentas on Movimientos.CuentaId equals Cuenta.Id
                                  join Cliente in context.Clientes on Cuenta.ClienteId equals Cliente.Id
                                  join Persona in context.Personas on Cliente.PersonaId equals Persona.Id
                                  where Cliente.Id == clienteId && Movimientos.Fecha >= fechaInicio && Movimientos.Fecha <= fechafin
                                  select new{ Movimientos.Fecha, Persona.Nombre, Cuenta.NumeroCuenta, Cuenta.TipoCuenta
                                                ,Cuenta.SaldoInicial, Cuenta.Activo, Movimientos.TipoMovimiento, Movimientos.Valor, Movimientos.Saldo};

                return Ok(movimientos);
            }
            catch (Exception err)
            {
                return NotFound("Problemas en la elminación" + err.Message);
            }
        }
    }
}
