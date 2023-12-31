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
    [Migration("20231126112759_added comment on the rating table")]
    partial class addedcommentontheratingtable
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

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            Password = "$2a$11$qXJ3T8aa9G6tSPLhMmOX4eGQQqQr2xZWjU.mLeVza0xe4.lHOK0cq",
                            TokensAvailable = 1,
                            UserName = "nagarro1"
                        },
                        new
                        {
                            UserId = 2,
                            Name = "Nagarro-2",
                            Password = "$2a$11$aHj1WS87GVw5EJK6yLKC1.IOIM8VzdOOI2yTpPHGJ1u9w8ezhSKX2",
                            TokensAvailable = 1,
                            UserName = "nagarro2"
                        },
                        new
                        {
                            UserId = 3,
                            Name = "Nagarro-3",
                            Password = "$2a$11$5pL1VUFbwsQiVoVHzf3gHOd2s5B.d8cCxhqAcN8wv3th8f2kmPHxG",
                            TokensAvailable = 1,
                            UserName = "nagarro3"
                        },
                        new
                        {
                            UserId = 4,
                            Name = "Nagarro-4",
                            Password = "$2a$11$3/D5R45cl8LYN5kBPd9W9.Yop6icA9brlaxOfxjPRiVzf55z/gFyy",
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
