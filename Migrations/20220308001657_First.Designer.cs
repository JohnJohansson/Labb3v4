﻿// <auto-generated />
using Labb3v4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb3v4.Migrations
{
    [DbContext(typeof(MusicContext))]
    [Migration("20220308001657_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("Labb3v4.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("Labb3v4.Models.Cd", b =>
                {
                    b.Property<int>("CdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CdInfo")
                        .HasColumnType("TEXT");

                    b.Property<string>("CdName")
                        .HasColumnType("TEXT");

                    b.HasKey("CdId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Cd");
                });

            modelBuilder.Entity("Labb3v4.Models.Cd", b =>
                {
                    b.HasOne("Labb3v4.Models.Artist", "Artist")
                        .WithMany("Cds")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Labb3v4.Models.Artist", b =>
                {
                    b.Navigation("Cds");
                });
#pragma warning restore 612, 618
        }
    }
}
