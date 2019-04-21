﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

namespace backend.Migrations
{
    [DbContext(typeof(EfDbContext))]
    [Migration("20190420072325_primeiro")]
    partial class primeiro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backend.Model.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<int>("Idade");

                    b.Property<DateTime>("Nascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("Profissao");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
