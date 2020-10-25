using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using books_api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace books_lumik.Infrastructure.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nombre).IsRequired();

            builder.Property(x => x.AutorId).IsRequired();

            builder.Property(x => x.CantidadCopias).IsRequired();

            builder.Property(x => x.FechaPublicacion).IsRequired();


        }
    }
}
