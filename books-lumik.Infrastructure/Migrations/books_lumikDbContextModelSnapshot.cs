﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using books_lumik.Infrastructure;

namespace books_lumik.Infrastructure.Migrations
{
    [DbContext(typeof(books_lumikDbContext))]
    partial class books_lumikDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("books_api.Core.Entities.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Edad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("books_api.Core.Entities.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AutorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadCopias")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("fechaPublicacion")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("books_api.Core.Entities.Libro", b =>
                {
                    b.HasOne("books_api.Core.Entities.Autor", "Autor")
                        .WithMany("Libros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
