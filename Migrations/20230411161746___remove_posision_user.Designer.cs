﻿// <auto-generated />
using System;
using LibManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibManager.Migrations
{
    [DbContext(typeof(LibDbContext))]
    [Migration("20230411161746___remove_posision_user")]
    partial class __remove_posision_user
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibManager.Models.Book", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("categoryid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("publicYear")
                        .HasColumnType("int");

                    b.Property<string>("publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("categoryid");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibManager.Models.Borrowing", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("bookid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("brrowingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dueTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("fineAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("returnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("userid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("bookid");

                    b.HasIndex("userid");

                    b.ToTable("Borrowings");
                });

            modelBuilder.Entity("LibManager.Models.Category", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LibManager.Models.Report", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("countBorrowing")
                        .HasColumnType("int");

                    b.Property<int>("countReader")
                        .HasColumnType("int");

                    b.Property<int>("countUser")
                        .HasColumnType("int");

                    b.Property<int>("month")
                        .HasColumnType("int");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("LibManager.Models.User", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hashPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.Property<int>("sex")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibManager.Models.Book", b =>
                {
                    b.HasOne("LibManager.Models.Category", "category")
                        .WithMany("Books")
                        .HasForeignKey("categoryid");

                    b.Navigation("category");
                });

            modelBuilder.Entity("LibManager.Models.Borrowing", b =>
                {
                    b.HasOne("LibManager.Models.Book", "book")
                        .WithMany()
                        .HasForeignKey("bookid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibManager.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("book");

                    b.Navigation("user");
                });

            modelBuilder.Entity("LibManager.Models.Category", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
