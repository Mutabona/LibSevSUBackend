﻿// <auto-generated />
using System;
using LibSevSUBackend.DbMigrator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibSevSUBackend.DbMigrator.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    [Migration("20241114172752_Add_PublishDate_To_News")]
    partial class Add_PublishDate_To_News
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookUser", b =>
                {
                    b.Property<Guid>("FavoriteBooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("FavoriteBooksId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("BookUser");
                });

            modelBuilder.Entity("LibSevSUBackend.Domain.Books.Entity.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("PublishDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId")
                        .IsUnique();

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("LibSevSUBackend.Domain.Files.Images.Entity.Base.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Image", (string)null);
                });

            modelBuilder.Entity("LibSevSUBackend.Domain.News.Entity.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("PublishDate")
                        .HasColumnType("date");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.ToTable("News", (string)null);
                });

            modelBuilder.Entity("LibSevSUBackend.Domain.Users.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.HasOne("LibSevSUBackend.Domain.Books.Entity.Book", null)
                        .WithMany()
                        .HasForeignKey("FavoriteBooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibSevSUBackend.Domain.Users.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibSevSUBackend.Domain.Books.Entity.Book", b =>
                {
                    b.HasOne("LibSevSUBackend.Domain.Files.Images.Entity.Base.Image", "Photo")
                        .WithOne()
                        .HasForeignKey("LibSevSUBackend.Domain.Books.Entity.Book", "PhotoId");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("LibSevSUBackend.Domain.News.Entity.News", b =>
                {
                    b.HasOne("LibSevSUBackend.Domain.Files.Images.Entity.Base.Image", "Image")
                        .WithOne()
                        .HasForeignKey("LibSevSUBackend.Domain.News.Entity.News", "ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("LibSevSUBackend.Domain.Users.Entity.User", b =>
                {
                    b.HasOne("LibSevSUBackend.Domain.Files.Images.Entity.Base.Image", "Photo")
                        .WithOne()
                        .HasForeignKey("LibSevSUBackend.Domain.Users.Entity.User", "PhotoId");

                    b.Navigation("Photo");
                });
#pragma warning restore 612, 618
        }
    }
}
