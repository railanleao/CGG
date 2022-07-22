using BVS.Models.Entity.CompradorAssociado;
using BVS.Models.Entity.Parceria;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BVS.Models.Entity.ContextBVS
{
    public class BVSContext : DbContext
    {
        public DbSet<Comprador> Compradores { get; set; } 
        public DbSet<Associado> Associados { get; set; }
        public DbSet<InicioParceria> InicioParcerias { get; set; }
        public DbSet<AlteracaoSaida> AlteracaoSaidas { get; set; }

        public BVSContext(DbContextOptions<BVSContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=postgres;Password=007055;Host=localhost;Port=5432;" +
                    "Database=BVS;Pooling=true;",
                    //Habilitar consultas divididas globalmente
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));                
            }
        }
    }
}
