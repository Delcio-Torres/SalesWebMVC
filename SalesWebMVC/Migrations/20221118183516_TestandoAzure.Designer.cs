// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesWebMVC.Context;

#nullable disable

namespace SalesWebMVC.Migrations
{
    [DbContext(typeof(SalesWebMvcContext))]
    [Migration("20221118183516_TestandoAzure")]
    partial class TestandoAzure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SalesWebMVC.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("SalesWebMVC.Models.SaleRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("SaleRecord");
                });

            modelBuilder.Entity("SalesWebMVC.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("BaseSalary")
                        .HasColumnType("float");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("SalesWebMVC.Models.SaleRecord", b =>
                {
                    b.HasOne("SalesWebMVC.Models.Seller", "Seller")
                        .WithMany("Sales")
                        .HasForeignKey("SellerId");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("SalesWebMVC.Models.Seller", b =>
                {
                    b.HasOne("SalesWebMVC.Models.Department", "Department")
                        .WithMany("Sellers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SalesWebMVC.Models.Department", b =>
                {
                    b.Navigation("Sellers");
                });

            modelBuilder.Entity("SalesWebMVC.Models.Seller", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
