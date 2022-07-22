using BVS.Models.Entity.Parceria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BVS.Models.EntityMap.ParceriaMap
{
    public class AlteracaoSaídaMap : IEntityTypeConfiguration<AlteracaoSaida>
    {
        public void Configure(EntityTypeBuilder<AlteracaoSaida> builder)
        {
            //builder.ToTable("AlteracaoESaidas");

            builder.HasKey(a => a.BoiId);
            builder.Property(a => a.PesoMedioAlterado).HasColumnType("decimal(18,2)");
            builder.Property(a => a.Saida).HasColumnType("date");
            builder.Property(i => i.PesoBruto).HasColumnType("decimal(7,2)").IsRequired();
            builder.Property(i => i.RendimentoCarcaca).HasColumnType("decimal(7,2)");
            builder.Property(i => i.Arroba).HasColumnType("decimal(7,2)");

            builder.Property(a => a.Classificacao).HasConversion(a => a.ToString(), a =>
            (Classificacao)Enum.Parse(typeof(Classificacao), a));
            
            builder.Property(a => a.CompraVenda).HasConversion(a => a.ToString(), a =>
            (CompraVenda)Enum.Parse(typeof(CompraVenda), a));

            builder.HasOne(a => a.Comprador).WithMany(a => a.AlteracaoSaidas)
                .HasForeignKey(a => a.IdComprador).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.Associado).WithMany(a => a.AlteracaoSaidas)
                .HasForeignKey(a => a.IdAssociado).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.InicioParceria).WithMany(a => a.AlteracaoSaidas)
                .HasForeignKey(a => a.InicioParceriaId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
