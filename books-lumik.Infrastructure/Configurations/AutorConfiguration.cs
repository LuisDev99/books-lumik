using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using books_api.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace books_lumik.Infrastructure.Configurations
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Edad).IsRequired();

            builder.Property(x => x.Nombre).IsRequired();

            builder.Property(x=>x.Id).ValueGeneratedOnAdd();

            //builder.HasMany<Libro>(x => x.Libros);
        }
    }
}
