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
        public DbSet<Persona> Persona2s { get; set; }


    }
}
