using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using People.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Data.Mappings
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(70)")
                .HasColumnName("Nome");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Email");

            builder.Property(p => p.Photo)
                .HasColumnType("varchar(100)")
                .HasColumnName("Photo");

            builder.Property(p => p.WhatsAppNumber)
                .IsRequired()
                .HasColumnType("varchar(14)")
                .HasColumnName("WhatsAppNumber");

            builder.ToTable("People");
        }
    }
}
