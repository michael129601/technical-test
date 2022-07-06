using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNTTDATA.Entity.Models;

namespace PruebaTecnicaNTTDATA.Entity.Connector
{
    public class ApplicationDBContext : DbContext
    {
        /// <summary>
        /// DataBase instance
        /// </summary>
        /// <param name="options">Settings</param>
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Persona> Persona { get; set; }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Movimientos> Movimientos { get; set; }

        public DbSet<Cuentas> Cuentas { get; set; }


    }
}
