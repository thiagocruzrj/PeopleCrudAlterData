using Microsoft.EntityFrameworkCore;
using People.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace People.Data.Context
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Caso esqueça de mapear property string
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(f => f.GetProperties()
                    .Where(e => e.ClrType == typeof(string))))
                property.Relational().ColumnName = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonDbContext).Assembly);
            // Desabilitando Cascade Delete(Não há interações entre tabelas, mas para a escalabilidade do projeto já deixo implementado)
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(f => f.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
