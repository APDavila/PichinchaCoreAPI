using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PichinchaCoreAPI.Entidades;

namespace PichinchaCoreAPI.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class CuentasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CuentasController(ApplicationDbContext context)
        {
            this.context = context;
        }        

        [HttpPost]
        public async Task<ActionResult> PostAsync(Cuenta cuenta)
        {
            try
            {
                context.Cuentas.Add(cuenta);
                await context.SaveChangesAsync();
                return Created($"/getCuentaById?id={cuenta.Id}", cuenta);
                //return Ok("Persona insertada con éxito");
            }
            catch (Exception err)
            {
                return NotFound("Problemas en la inserción");
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int cuentaId)
        {
            try
            {
                var cuenta = new Cuenta { Id = cuentaId };
                context.Cuentas.Attach(cuenta);
                context.Cuentas.Remove(cuenta);
                context.SaveChanges();
                return Ok("Cuenta eliminada exitosamente");
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
                var cuentas = await context.Cuentas.ToListAsync();
                return Ok(cuentas);
            }
            catch (Exception err)
            {
                return NotFound("Problemas en la elminación" + err.Message);
            }
        }
        [HttpGet]
        [Route("getCuentaById")]      
        public async Task<Cuenta> GetCuentaByIdAsync(int id)
        {
            Cuenta cuenta = await context.Cuentas.FindAsync(id);
            return cuenta;
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Cuenta cuentaToUpdate)
        {
            context.Cuentas.Update(cuentaToUpdate);
            await context.SaveChangesAsync();
            return Ok("Registro actualizado con éxito");
        }

        [HttpGet]
        [Route("VerificaSaldoDisponible")]
        public async Task<bool> VerificaSaldoDisponible(int cuentaId, double saldoADebitar)
        {
            Cuenta cuenta = (Cuenta) await GetCuentaByIdAsync(cuentaId);
            return cuenta.SaldoInicial > saldoADebitar ? true : false;
        }

        [HttpGet]
        [Route("VerificaLimiteDiario")]
        public async Task<bool> VerificaLimiteDiario(int cuentaId, double saldoADebitar)
        {
            Cuenta cuenta = (Cuenta)await GetCuentaByIdAsync(cuentaId);
            return cuenta.CupoDiario >= 1000 ? false : true;
        }

        [HttpGet]
        [Route("CalculaSaldoTransaccíon")]
        public async Task<double> CalculaSaldoTransaccíon(int cuentaId, double saldoADebitar, int option)
        {
            //option = 0 Debito, 1 Credito; 
            Cuenta cuenta = (Cuenta)await GetCuentaByIdAsync(cuentaId);
            switch (option)
            {
                case 0:
                    cuenta.SaldoInicial = cuenta.SaldoInicial - saldoADebitar;
                    cuenta.CupoDiario = cuenta.CupoDiario + saldoADebitar;
                    await PutAsync(cuenta);
                    return cuenta.SaldoInicial;                    
                break;
                case 1:
                    cuenta.SaldoInicial = cuenta.SaldoInicial + saldoADebitar;
                    await PutAsync(cuenta);
                    return cuenta.SaldoInicial;                    
                break;
                default:
                    return 0;
                break;
            }         
            
        }
        
    }
}
