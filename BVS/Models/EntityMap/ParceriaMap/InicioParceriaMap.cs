using BVS.Models.Entity.Parceria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BVS.Models.EntityMap.ParceriaMap
{
    public class InicioParceriaMap : IEntityTypeConfiguration<InicioParceria>
    {
        public void Configure(EntityTypeBuilder<InicioParceria> builder)
        {
            builder.HasKey(i => i.BoiId);
            builder.Property(i => i.Lote).HasMaxLength(10);
            builder.Property(i => i.Quantidade).HasColumnType("int").IsRequired();
            builder.Property(i => i.DataInicioParceria).HasColumnType("date").IsRequired();
            builder.Property(i => i.PesoBruto).HasColumnType("decimal(7,2)").IsRequired();
            builder.Property(i => i.RendimentoCarcaca).HasColumnType("decimal(7,2)");
            builder.Property(i => i.Origem).HasMaxLength(100).IsRequired();
            //builder.Property(i => i.PorcentoMes).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(i => i.Arroba).HasColumnType("decimal(7,2)");
            builder.Property(i => i.Valor).HasColumnType("decimal(18,2)").IsRequired();
            

            builder.Property(i => i.Classificacao).HasConversion(i => i.ToString(), i =>
            (Classificacao)Enum.Parse(typeof(Classificacao), i)).IsRequired();

            builder.Property(i => i.CompraVenda).HasConversion(i => i.ToString(), i =>
            (CompraVenda)Enum.Parse(typeof(CompraVenda), i)).IsRequired();

            builder.HasOne(i => i.Comprador).WithMany(i => i.InicioParcerias)
                .HasForeignKey(i => i.IdComprador).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(i => i.Associado).WithMany(i => i.InicioParcerias)
                .HasForeignKey(i => i.IdAssociado).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(i => i.AlteracaoSaidas).WithOne(i => i.InicioParceria).OnDelete(DeleteBehavior.NoAction);

            builder.Navigation(c => c.AlteracaoSaidas).AutoInclude();
        }
    }
}
