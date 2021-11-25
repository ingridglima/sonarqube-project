using ExemploSonar.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExemploSonar.API.Data.Config
{
    public class RegistroConfiguration : IEntityTypeConfiguration<Registro>
    {
        public void Configure(EntityTypeBuilder<Registro> builder)
        {
            builder.ToTable("registros");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnType("id");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nome");

            builder.Property(x => x.Cidade)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("cidade");

            builder.Property(x => x.DataCriacao)
                .IsRequired()
                .HasColumnName("data_criacao");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("email");

            builder.Property(x => x.Estado)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("estado");

        }
    }
}
