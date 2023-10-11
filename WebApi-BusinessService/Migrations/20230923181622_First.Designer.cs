﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi_BusinessService.Models;

#nullable disable

namespace WebApi_BusinessService.Migrations
{
    [DbContext(typeof(AuthDbContext1))]
    [Migration("20230923181622_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi_BusinessService.Entities.AppMonthAttachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Record_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Record_Id");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("WebApi_BusinessService.Entities.AppMonthRecords", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MonthRecords");
                });

            modelBuilder.Entity("WebApi_BusinessService.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("App_User");
                });

            modelBuilder.Entity("WebApi_BusinessService.Entities.AppMonthAttachment", b =>
                {
                    b.HasOne("WebApi_BusinessService.Entities.AppMonthRecords", "Record")
                        .WithMany("Attachments")
                        .HasForeignKey("Record_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Record");
                });

            modelBuilder.Entity("WebApi_BusinessService.Entities.AppMonthRecords", b =>
                {
                    b.HasOne("WebApi_BusinessService.Entities.AppUser", "User")
                        .WithMany("MonthRecords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApi_BusinessService.Entities.AppMonthRecords", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("WebApi_BusinessService.Entities.AppUser", b =>
                {
                    b.Navigation("MonthRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
