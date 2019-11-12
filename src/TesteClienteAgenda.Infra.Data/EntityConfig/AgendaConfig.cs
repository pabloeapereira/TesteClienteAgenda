using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Infra.Data.EntityConfig
{
    public class AgendaConfig : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.Property(a => a.Id).HasColumnName("id");
            builder.HasKey(a => a.Id);
                
            builder.Property(a => a.DataLiquidacao).IsRequired().HasColumnName("data_liquidacao");
            builder.Property(a => a.NumeroTitulo).IsRequired().HasMaxLength(60).HasColumnName("num_titulo").HasColumnType("varchar(60)");
            builder.Property(a => a.Taxa).HasColumnName("taxa").HasColumnType("decimal(5,4)");
            builder.Property(a => a.ValorBruto).IsRequired().HasColumnName("valor_bruto").HasColumnType("decimal(18,2)");
            builder.Property(a => a.ValorLiquido).HasColumnName("valor_liquido").HasColumnType("decimal(18,2)");

            builder.HasOne(a => a.Cliente).WithMany(c => c.Agendas)
                .HasForeignKey(a => a.ClienteId).HasConstraintName("cliente_id");

            //builder.Ignore(a => a.ValidationResult);

            builder.ToTable("agenda");
        }
    }
}
