﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mock.Core.Data;

#nullable disable

namespace Mock.Core.Migrations
{
    [DbContext(typeof(LivebraryContext))]
    [Migration("20240918082330_add-property-IsPickUpLate")]
    partial class addpropertyIsPickUpLate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mock.Core.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublishedYear")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Mock.Core.Models.BookGenre", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenres");
                });

            modelBuilder.Entity("Mock.Core.Models.Borrowing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ActualPickUpDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BorrowingStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpectedPickUpDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpectedReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsBookPickedUp")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPickUpLate")
                        .HasColumnType("bit");

                    b.Property<decimal?>("PenaltyFine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalQuantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Borrowings");
                });

            modelBuilder.Entity("Mock.Core.Models.BorrowingDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ActualReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BorrowingId")
                        .HasColumnType("int");

                    b.Property<int?>("NumberReturnedBook")
                        .HasColumnType("int");

                    b.Property<decimal?>("Penalty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("BorrowingId");

                    b.ToTable("BorrowingDetails");
                });

            modelBuilder.Entity("Mock.Core.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Mock.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "josh@gmail.com",
                            FirstName = "Josh",
                            IsActive = true,
                            IsAdmin = true,
                            LastName = "Miller",
                            Password = "$2a$12$PWrcJdxqn2qbniRRBOOFVOhpx925EOLuMJmEX1ZfOhsU0znIClGOu",
                            Phone = "1234567890",
                            Username = "josh_miller"
                        },
                        new
                        {
                            Id = 2,
                            Email = "mark@gmail.com",
                            FirstName = "Mark",
                            IsActive = true,
                            IsAdmin = true,
                            LastName = "Smith",
                            Password = "$2a$12$PWrcJdxqn2qbniRRBOOFVOhpx925EOLuMJmEX1ZfOhsU0znIClGOu",
                            Phone = "0987654321",
                            Username = "mark_smith"
                        },
                        new
                        {
                            Id = 3,
                            Email = "jessica@gmail.com",
                            FirstName = "Jessica",
                            IsActive = true,
                            IsAdmin = true,
                            LastName = "Johnson",
                            Password = "$2a$12$PWrcJdxqn2qbniRRBOOFVOhpx925EOLuMJmEX1ZfOhsU0znIClGOu",
                            Phone = "09022254566",
                            Username = "jessica_johnson"
                        });
                });

            modelBuilder.Entity("Mock.Core.Models.WishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("TotalQuantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WishLists");
                });

            modelBuilder.Entity("Mock.Core.Models.WishListDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("WishListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("WishListId");

                    b.ToTable("WishListDetails");
                });

            modelBuilder.Entity("Mock.Core.Models.BookGenre", b =>
                {
                    b.HasOne("Mock.Core.Models.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mock.Core.Models.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Mock.Core.Models.Borrowing", b =>
                {
                    b.HasOne("Mock.Core.Models.User", "User")
                        .WithMany("Borrowings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mock.Core.Models.BorrowingDetails", b =>
                {
                    b.HasOne("Mock.Core.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mock.Core.Models.Borrowing", "Borrowing")
                        .WithMany("BorrowingDetails")
                        .HasForeignKey("BorrowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Borrowing");
                });

            modelBuilder.Entity("Mock.Core.Models.WishList", b =>
                {
                    b.HasOne("Mock.Core.Models.User", "User")
                        .WithMany("WishLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mock.Core.Models.WishListDetails", b =>
                {
                    b.HasOne("Mock.Core.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mock.Core.Models.WishList", "WishList")
                        .WithMany("WishListDetails")
                        .HasForeignKey("WishListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("WishList");
                });

            modelBuilder.Entity("Mock.Core.Models.Book", b =>
                {
                    b.Navigation("BookGenres");
                });

            modelBuilder.Entity("Mock.Core.Models.Borrowing", b =>
                {
                    b.Navigation("BorrowingDetails");
                });

            modelBuilder.Entity("Mock.Core.Models.Genre", b =>
                {
                    b.Navigation("BookGenres");
                });

            modelBuilder.Entity("Mock.Core.Models.User", b =>
                {
                    b.Navigation("Borrowings");

                    b.Navigation("WishLists");
                });

            modelBuilder.Entity("Mock.Core.Models.WishList", b =>
                {
                    b.Navigation("WishListDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
