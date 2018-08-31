using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Data.Mapping
{
    public class EditoraMap : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            builder.ToTable("Editoras");

            builder.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.Property(e => e.DataCadastro)
                    .IsRequired();

            builder.Property(e => e.Status)
                    .HasDefaultValue(true);
        }
    }
}
