﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using HairSalon.Models;

namespace HairSalon.Migrations
{
    [DbContext(typeof(HairSalonContext))]
    [Migration("20191018163732_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HairSalon.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name_First");

                    b.Property<string>("Name_Last");

                    b.Property<string>("Phone");

                    b.Property<int>("StylistId");

                    b.HasKey("ClientId");

                    b.HasIndex("StylistId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("HairSalon.Models.Stylist", b =>
                {
                    b.Property<int>("StylistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Specialty");

                    b.HasKey("StylistId");

                    b.ToTable("Stylists");
                });

            modelBuilder.Entity("HairSalon.Models.Client", b =>
                {
                    b.HasOne("HairSalon.Models.Stylist", "Stylist")
                        .WithMany("Clients")
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
