using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using books_lumik.Infrastructure.Configurations;
using books_api.Core.Entities;

namespace books_lumik.Infrastructure
{
    public class books_lumikDbContext : DbContext
    {
        public books_lumikDbContext(DbContextOptions options):
            base(options)
        {


        }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutorConfiguration());
            modelBuilder.ApplyConfiguration(new LibroConfiguration());

        }

    }
}
