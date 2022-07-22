using BVS.Models.Entity.CompradorAssociado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BVS.Models.EntityMap.CompradorAssociado
{
    public class CompradorMap : IEntityTypeConfiguration<Comprador>
    {
        public void Configure(EntityTypeBuilder<Comprador> builder)
        {
            builder.ToTable("Compradores");
            builder.HasKey(c => c.CadastroId);
            builder.Property(c => c.Nome).HasMaxLength(150).IsRequired();
            builder.Property(c => c.CPF).HasMaxLength(14).IsRequired();

            //https://docs.microsoft.com/pt-br/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
            builder.Navigation(c => c.Associados).AutoInclude();
            builder.Navigation(c => c.InicioParcerias).AutoInclude();
            builder.Navigation(c => c.AlteracaoSaidas).AutoInclude();

            builder.HasMany(c => c.Associados).WithOne(c => c.Comprador).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.InicioParcerias).WithOne(c => c.Comprador).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.AlteracaoSaidas).WithOne(c => c.Comprador).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
