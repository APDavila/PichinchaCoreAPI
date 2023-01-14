using Microsoft.EntityFrameworkCore;
using PichinchaCoreAPI.Entidades;

namespace PichinchaCoreAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }
        public DbSet<Cuenta> Cuentas{ get; set; }



    }
}
