namespace Soporte.Models
{
    using Microsoft.EntityFrameworkCore;
    public class SoporteDbContext : DbContext
    {
        public SoporteDbContext(DbContextOptions<SoporteDbContext> options) : base(options)
        {
        }
            public DbSet <GestoresModel> Gestores { get; set; }
            public DbSet<AtmsModel> Atms { get; set; }

            public DbSet<MantenimientosModel> Mantenimientos { get; set; }

            public DbSet<AgenciasModel> Agencias { get; set; }

            public DbSet<BancosModel> Bancos { get; set; }
    }

 }

