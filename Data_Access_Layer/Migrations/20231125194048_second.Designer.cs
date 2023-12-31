﻿// <auto-generated />
using System;
using Data_Access_Layer.Data_Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231125194048_second")]
    partial class second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data_Access_Layer.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("CurrentlyBorrowedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LentByUserId")
                        .HasColumnType("int");

                    b.Property<bool>("isBookAvailable")
                        .HasColumnType("bit");

                    b.HasKey("BookId");

                    b.HasIndex("LentByUserId");

                    b.ToTable("BookList");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Ratings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TokensAvailable")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Shahnwaz Ansari",
                            Password = "$2a$11$KhjJz3eJV/ru.mKj8N42DOiSS3GXLvCZM7FVqqiM4isxdaVHuC6iq",
                            TokensAvailable = 1,
                            UserName = "nagarro1"
                        },
                        new
                        {
                            UserId = 2,
                            Name = "Nagarro-2",
                            Password = "$2a$11$imNod9RjDumtteqDcgVVNOUduDyf4MZCu4LHWeQnsxwMNtRYKh.2u",
                            TokensAvailable = 1,
                            UserName = "nagarro2"
                        },
                        new
                        {
                            UserId = 3,
                            Name = "Nagarro-3",
                            Password = "$2a$11$325LRc2XnvQcvwmm4o2Auub6MQ71LTDvnnk/n.BVnHAGq0ZWLwbL2",
                            TokensAvailable = 1,
                            UserName = "nagarro3"
                        },
                        new
                        {
                            UserId = 4,
                            Name = "Nagarro-4",
                            Password = "$2a$11$IrNR7fOujt1.js42NTQieOJPfcts9FU3NvmCf6Vs2Cp9oke1afKZK",
                            TokensAvailable = 1,
                            UserName = "nagarro4"
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Book", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.User", "User")
                        .WithMany("Books")
                        .HasForeignKey("LentByUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Ratings", b =>
                {
                    b.HasOne("Data_Access_Layer.Entities.Book", "Book")
                        .WithMany("Ratings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data_Access_Layer.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.Book", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.User", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
