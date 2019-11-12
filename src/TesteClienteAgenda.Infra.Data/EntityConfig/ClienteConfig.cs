using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Infra.Data.EntityConfig
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.Id).HasColumnName("id");
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => new {c.Cnpj, c.RazaoSocial}).IsUnique();

            builder.Property(c => c.Classificacao).IsRequired().HasColumnName("classificacao");

            builder.Property(c => c.Capital).IsRequired().HasColumnName("capital").HasColumnType("decimal(18,2)");

            builder.Property(c => c.Cnpj).IsRequired().HasMaxLength(14).IsFixedLength().HasColumnName("cnpj").HasColumnType("varchar(14)");
            builder.Property(c => c.DataFundacao).IsRequired().HasColumnName("data_fundacao");
            builder.Property(c => c.Quarentena).IsRequired().HasColumnName("quarentena");
            builder.Property(c => c.RazaoSocial).IsRequired().HasMaxLength(200).HasColumnName("razao_social").HasColumnType("varchar(200)");
            builder.Property(c => c.StatusCliente).IsRequired().HasColumnName("status_cliente");

            //builder.Ignore(c => c.ValidationResult);

            builder.ToTable("cliente");

        }
    }
}