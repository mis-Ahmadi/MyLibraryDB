﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLibrary.Backend.API.DB;

#nullable disable

namespace MyLibrary.Backend.API.Migrations
{
    [DbContext(typeof(MyLibraryDB))]
    [Migration("20241025105345_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyLibrary.Backend.API.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Titel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Writer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("MyLibrary.Backend.API.Entities.Borrow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MemerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RrturnTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("MemerId");

                    b.ToTable("Borrows");
                });

            modelBuilder.Entity("MyLibrary.Backend.API.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("MyLibrary.Backend.API.Entities.Borrow", b =>
                {
                    b.HasOne("MyLibrary.Backend.API.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("MyLibrary.Backend.API.Entities.Member", "Memer")
                        .WithMany()
                        .HasForeignKey("MemerId");

                    b.Navigation("Book");

                    b.Navigation("Memer");
                });
#pragma warning restore 612, 618
        }
    }
}