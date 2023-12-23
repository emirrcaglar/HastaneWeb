﻿// <auto-generated />
using HastaneRandevu.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HastaneRandevu.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    [Migration("20231223172744_fkEkle4")]
    partial class fkEkle4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HastaneRandevu.Models.Bolum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DoktorId")
                        .HasColumnType("integer");

                    b.Property<string>("bolumAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.ToTable("Bolumler");
                });

            modelBuilder.Entity("HastaneRandevu.Models.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BolumId")
                        .HasColumnType("integer");

                    b.Property<string>("ad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("soyad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("vardiya")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BolumId");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("HastaneRandevu.Models.Bolum", b =>
                {
                    b.HasOne("HastaneRandevu.Models.Doktor", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");
                });

            modelBuilder.Entity("HastaneRandevu.Models.Doktor", b =>
                {
                    b.HasOne("HastaneRandevu.Models.Bolum", "Bolum")
                        .WithMany("Doktorlar")
                        .HasForeignKey("BolumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolum");
                });

            modelBuilder.Entity("HastaneRandevu.Models.Bolum", b =>
                {
                    b.Navigation("Doktorlar");
                });
#pragma warning restore 612, 618
        }
    }
}