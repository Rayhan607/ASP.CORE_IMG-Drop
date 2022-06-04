﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication5.Models;

namespace WebApplication5.Migrations
{
    [DbContext(typeof(EmpDbContext))]
    partial class EmpDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication5.Models.Dep", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepId");

                    b.ToTable("Deps");
                });

            modelBuilder.Entity("WebApplication5.Models.Emp", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepId")
                        .HasColumnType("int");

                    b.Property<string>("EmpImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpId");

                    b.HasIndex("DepId");

                    b.ToTable("Emps");
                });

            modelBuilder.Entity("WebApplication5.Models.Emp", b =>
                {
                    b.HasOne("WebApplication5.Models.Dep", "Dep")
                        .WithMany("Emps")
                        .HasForeignKey("DepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
