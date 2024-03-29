﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using msShop.Cliente.API.Data;

namespace msShop.Cliente.API.Migrations
{
    [DbContext(typeof(ClientesContext))]
    [Migration("20220209050956_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("msShop.Cliente.API.Models.Clientes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Excluido")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("msShop.Cliente.API.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("msShop.Cliente.API.Models.Clientes", b =>
                {
                    b.OwnsOne("mShop.Core.DomainObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("ClientesId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("Cpf")
                                .HasColumnType("varchar(11)")
                                .HasMaxLength(11);

                            b1.HasKey("ClientesId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClientesId");
                        });

                    b.OwnsOne("mShop.Core.DomainObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ClientesId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(254)");

                            b1.HasKey("ClientesId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClientesId");
                        });
                });

            modelBuilder.Entity("msShop.Cliente.API.Models.Endereco", b =>
                {
                    b.HasOne("msShop.Cliente.API.Models.Clientes", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("msShop.Cliente.API.Models.Endereco", "ClienteId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
