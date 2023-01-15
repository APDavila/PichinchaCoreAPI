using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PichinchaCoreAPI.Entidades;

namespace PichinchaCoreAPI.Controllers
{
    [ApiController]
    [Route("api/movimientos")]
    public class MovimientosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public MovimientosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Movimientos movimiento)
        {
            try
            {
                movimiento.Fecha = DateTime.Now;
                CuentasController cuentasController = new CuentasController(context);

                if (movimiento.TipoMovimiento.ToUpper().Equals("DÉBITO"))
                {
                    if (await cuentasController.VerificaSaldoDisponible(movimiento.CuentaId, movimiento.Valor))
                    {
                        if (await cuentasController.VerificaLimiteDiario(movimiento.CuentaId, movimiento.Valor))
                        {
                            double saldo = await cuentasController.CalculaSaldoTransaccíon(movimiento.CuentaId, movimiento.Valor, 0);
                            movimiento.Saldo = saldo;
                            movimiento.TipoMovimiento = movimiento.TipoMovimiento.ToUpper();
                            context.Movimientos.Add(movimiento);
                            await context.SaveChangesAsync();
                            return Created($"/getMovimientoById?id={movimiento.Id}", movimiento);
                            //return Problem("Detail","Instance",20,"title","type");                            

                        }
                        else
                        {
                            return Problem("Cupo diario Excedido", null, 20, "Problemas con la cuenta", "Transaction Conflict");
                        }
                    }
                    else
                    {
                        return Problem("Saldo no disponible", null, 21, "Problemas con la cuenta", "Transaction Conflict");
                    }

                }
                else if (movimiento.TipoMovimiento.ToUpper().Equals("CRÉDITO"))
                {
                    double saldo = await cuentasController.CalculaSaldoTransaccíon(movimiento.CuentaId, movimiento.Valor, 1);
                    movimiento.Saldo = saldo;
                    movimiento.TipoMovimiento = movimiento.TipoMovimiento.ToUpper();
                    context.Movimientos.Add(movimiento);
                    await context.SaveChangesAsync();
                    return Created($"/getMovimientoById?id={movimiento.Id}", movimiento);
                }
                else
                {
                    return Problem("Tipo de movimiento no reconocido.", null, 23, "Problemas con la cuenta", "Transaction Conflict");
                }
            }
            catch (Exception err)
            {
                return Problem("Problemas en la inserción", null, 22, "Problemas con la cuenta", "Transaction Conflict");
            }
        }

        private bool VerificaSaldoDisponible()
        {
            /*
            CuentasController cc = new CuentasController(context);
            return await cc.GetCuentaByIdAsync(movimiento.CuentaId);
            */
            return true;
        }

        private bool VerificaLimiteDiario()
        {
            return true;
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int movimientoId)
        {
            try
            {
                var movimiento = new Movimientos { Id = movimientoId };
                context.Movimientos.Attach(movimiento);
                context.Movimientos.Remove(movimiento);
                context.SaveChanges();
                return Ok("Movimiento eliminada exitosamente");
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
                var movimientos = await context.Movimientos.ToListAsync();
                return Ok(movimientos);
            }
            catch (Exception err)
            {
                return NotFound("Problemas en la elminación" + err.Message);
            }
        }

        [HttpGet]
        [Route("getMovimientoById")]
        public async Task<IActionResult> GetMovementByIdAsync(int id)
        {
            var movimiento = await context.Movimientos.FindAsync(id);
            return Ok(movimiento);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Movimientos movimientoToUpdate)
        {
            context.Movimientos.Update(movimientoToUpdate);
            await context.SaveChangesAsync();
            return Ok("Registro actualizado con éxito");
        }
    }
}
