﻿// <auto-generated />
using Barinak.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Barinak.Migrations
{
    [DbContext(typeof(BarinakContext))]
    [Migration("20230730183036_ilk")]
    partial class ilk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Barinak.Models.Kategori", b =>
                {
                    b.Property<int>("KategoriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriID"));

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategoriID");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("Barinak.Models.Tur", b =>
                {
                    b.Property<int>("TurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TurID"));

                    b.Property<int>("KategoriID")
                        .HasColumnType("int");

                    b.Property<string>("TurAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TurCins")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TurYas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TurID");

                    b.HasIndex("KategoriID");

                    b.ToTable("Turler");
                });

            modelBuilder.Entity("Barinak.Models.Tur", b =>
                {
                    b.HasOne("Barinak.Models.Kategori", "Kategori")
                        .WithMany("Turler")
                        .HasForeignKey("KategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("Barinak.Models.Kategori", b =>
                {
                    b.Navigation("Turler");
                });
#pragma warning restore 612, 618
        }
    }
}