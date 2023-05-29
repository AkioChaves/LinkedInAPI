﻿// <auto-generated />
using System;
using LinkedInAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LinkedInAPI.Migrations
{
    [DbContext(typeof(LinkedInAPIContext))]
    partial class LinkedInAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LinkedInAPI.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("LinkedInAPI.Models.Job", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Benefits")
                        .HasColumnType("longtext");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Function")
                        .HasColumnType("longtext");

                    b.Property<string>("Local")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Requirements")
                        .HasColumnType("longtext");

                    b.Property<double>("Salary")
                        .HasColumnType("double");

                    b.Property<string>("Shipping")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CompanyId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("LinkedInAPI.Models.Job", b =>
                {
                    b.HasOne("LinkedInAPI.Models.Company", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("LinkedInAPI.Models.Company", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
