﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using msShop.Models;

namespace msShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210110234702_DadosUsuario")]
    partial class DadosUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("msShop.Models.CartaoCredito", b =>
                {
                    b.Property<Guid>("CartaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeCartao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCartao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartaoId");

                    b.ToTable("CartaoCredito");
                });

            modelBuilder.Entity("msShop.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoriaDescricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoriaNome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            CategoriaNome = "Softwares"
                        },
                        new
                        {
                            CategoriaId = 2,
                            CategoriaNome = "Hardware"
                        },
                        new
                        {
                            CategoriaId = 3,
                            CategoriaNome = "Video Games"
                        },
                        new
                        {
                            CategoriaId = 4,
                            CategoriaNome = "Acessórios"
                        },
                        new
                        {
                            CategoriaId = 5,
                            CategoriaNome = "Servidores"
                        });
                });

            modelBuilder.Entity("msShop.Models.DadosUsuario", b =>
                {
                    b.Property<Guid>("DadosUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Enderenco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DadosUsuarioId");

                    b.ToTable("DadosUsuario");
                });

            modelBuilder.Entity("msShop.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<decimal>("TotalPedido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PedidoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("msShop.Models.PedidoDetalhe", b =>
                {
                    b.Property<int>("DetalhePedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("DetalhePedidoId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PedidoDetalhes");
                });

            modelBuilder.Entity("msShop.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadeMedida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorBruto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("aVenda")
                        .HasColumnType("bit");

                    b.Property<int>("altura")
                        .HasColumnType("int");

                    b.Property<int>("comprimento")
                        .HasColumnType("int");

                    b.Property<bool>("emEstoque")
                        .HasColumnType("bit");

                    b.Property<int>("largura")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            ProdutoId = 1,
                            CategoriaId = 1,
                            Descricao = "Console Xbox One S 1TB + Anthem Legion Of Dawn - Original Microsoft",
                            ImagemThumbnailUrl = "xboxOneS.jpg",
                            ImagemUrl = "xboxOneS.jpg",
                            Marca = "Microsoft",
                            Nome = "XBox One S 1TB + Anthem Legion Of Dawn",
                            Peso = 5,
                            Preco = 2979.90m,
                            Quantidade = 1,
                            Slug = "Console-Xbox-One-S-1TB-Anthem-Legion-Of-Dawn",
                            ValorBruto = 3199.90m,
                            aVenda = true,
                            altura = 30,
                            comprimento = 23,
                            emEstoque = true,
                            largura = 10
                        },
                        new
                        {
                            ProdutoId = 2,
                            CategoriaId = 2,
                            Descricao = "Halo: Reach é mais um título desta aclamada franquia exclusiva para o Xbox 360, contando uma nova história envolvendo os acontecimentos da Noble Team.",
                            ImagemThumbnailUrl = "halo-reach.jpg",
                            ImagemUrl = "halo-reach.jpg",
                            Marca = "Microsoft",
                            Nome = "Halo Reach XBox 360",
                            Peso = 1,
                            Preco = 59.99m,
                            Quantidade = 1,
                            Slug = "Halo-Reach-XBox-360",
                            ValorBruto = 79.90m,
                            aVenda = true,
                            altura = 5,
                            comprimento = 10,
                            emEstoque = true,
                            largura = 3
                        },
                        new
                        {
                            ProdutoId = 3,
                            CategoriaId = 2,
                            Descricao = "Halo 4 é o quarto jogo da famosa franquia exclusiva da Microsoft, que estreou em 2001 com Halo: Combat Evolved. O game marca o surgimento de uma nova trilogia estrelada por Master Chief, o lendário soldado Spartan que é o grande representante da série.",
                            ImagemThumbnailUrl = "halo-4.jpg",
                            ImagemUrl = "halo-4.jpg",
                            Marca = "Microsoft",
                            Nome = "Halo 4 XBox 360",
                            Peso = 1,
                            Preco = 74.90m,
                            Quantidade = 1,
                            Slug = "Halo-4-XBox-360",
                            ValorBruto = 99.90m,
                            aVenda = true,
                            altura = 5,
                            comprimento = 10,
                            emEstoque = true,
                            largura = 3
                        },
                        new
                        {
                            ProdutoId = 4,
                            CategoriaId = 1,
                            Descricao = "Test Drive Unlimited 2 destina-se a transformar o gênero de condução, acrescentando que a persistência, a progressão ea personalização dos jogos mais recentes para a experiência multiplayer de corrida.",
                            ImagemThumbnailUrl = "tdu2.jpg",
                            ImagemUrl = "tdu2.jpg",
                            Marca = "Microsoft",
                            Nome = "Test Drive Unlimited 2 XBox 360",
                            Peso = 1,
                            Preco = 71.90m,
                            Quantidade = 1,
                            Slug = "Test-Drive-Unlimited-2-XBox-360",
                            ValorBruto = 91.90m,
                            aVenda = true,
                            altura = 5,
                            comprimento = 10,
                            emEstoque = true,
                            largura = 3
                        },
                        new
                        {
                            ProdutoId = 5,
                            CategoriaId = 1,
                            Descricao = "Em Halo 3: ODST o jogador controla seu protagonista principal, conhecido como Novato, em busca de pistas pela cidade de New Mombasa após acordar, depois de estar inconsciente por seis horas quando sua cápsula de lançamento caiu na superfície.",
                            ImagemThumbnailUrl = "halo3-odst.jpg",
                            ImagemUrl = "halo3-odst.jpg",
                            Marca = "Microsoft",
                            Nome = "Halo 3 Odst Original Dublado XBox360",
                            Peso = 1,
                            Preco = 49.90m,
                            Quantidade = 1,
                            Slug = "Halo-3-Odst Original-Dublado-XBox-360",
                            ValorBruto = 69.90m,
                            aVenda = true,
                            altura = 5,
                            comprimento = 10,
                            emEstoque = true,
                            largura = 3
                        },
                        new
                        {
                            ProdutoId = 6,
                            CategoriaId = 1,
                            Descricao = "Os aprimoramentos de Anniversary incluem uma atualização completa para visuais em alta definição, suporte a jogabilidade cooperativa e online por meio do serviço Xbox Live, músicas e efeitos sonoros novos e remasterizados, além de extras como conquistas e colecionáveis dentro do jogo.",
                            ImagemThumbnailUrl = "halo-aniversary.jpg",
                            ImagemUrl = "halo-aniversary.jpg",
                            Marca = "Microsoft",
                            Nome = "Halo Combat Evolved Anniversary - XBox 360 ",
                            Peso = 1,
                            Preco = 49.90m,
                            Quantidade = 10,
                            Slug = "Halo-Combat-Evolved-Anniversary-Xbox-360 ",
                            ValorBruto = 99.90m,
                            aVenda = true,
                            altura = 5,
                            comprimento = 10,
                            emEstoque = true,
                            largura = 3
                        },
                        new
                        {
                            ProdutoId = 7,
                            CategoriaId = 1,
                            Descricao = "F1™ 2013 é o videogame definitivo de FÓRMULA 1™ para esta geração de consoles. A premiada série de FÓRMULA 1 da Codemasters já vendeu mais de 6,5 milhões de unidades. O F1 2013: CLASSIC EDITION é um pacote premium que inclui o F1 2013, conteúdo clássico da década de 1980, e ainda tem mais conteúdo da década de 1990 e pistas clássicas adicionais.",
                            ImagemThumbnailUrl = "f1-2013.jpg",
                            ImagemUrl = "f1-2013.jpg",
                            Marca = "Microsoft",
                            Nome = "Formula 1 2013 (edição Classica) - XBox 360",
                            Peso = 1,
                            Preco = 69.90m,
                            Quantidade = 1,
                            Slug = "Formula-1-2013-(edição-Classica)-Xbox-360",
                            ValorBruto = 129.90m,
                            aVenda = true,
                            altura = 5,
                            comprimento = 10,
                            emEstoque = true,
                            largura = 3
                        },
                        new
                        {
                            ProdutoId = 8,
                            CategoriaId = 1,
                            Descricao = "É um controle muito anatômico, se adapta completamente a sua mão, a posição do analógico é muito boa, evitando dores ao se jogar por muito tempo. Os gatilhos são outro ponto positivo do controle do Xbox 360, com um alcance excelente para os dedos, fornecendo uma jogabilidade confortável e precisa, principalmente nos jogos que exigem mais desses botões.",
                            ImagemThumbnailUrl = "controle-xbox.jpg",
                            ImagemUrl = "controle-xbox.jpg",
                            Marca = "Microsoft",
                            Nome = "Controle Xbox 360 Original Sem Fio Wireless Microsoft",
                            Peso = 1,
                            Preco = 129.90m,
                            Quantidade = 1,
                            Slug = "controle-xbox-360",
                            ValorBruto = 179.90m,
                            aVenda = true,
                            altura = 5,
                            comprimento = 5,
                            emEstoque = true,
                            largura = 5
                        },
                        new
                        {
                            ProdutoId = 9,
                            CategoriaId = 1,
                            Descricao = "Fones de ouvido com fio para jogos, plug de 3.5mm Jack/Bass/Headsets Estéreo com Microfone para XBOX-ONE, PS4 e PC. Ideal para jogos Online",
                            ImagemThumbnailUrl = "fone-ouvido-kotion.jpg",
                            ImagemUrl = "fone-ouvido-kotion.jpg",
                            Marca = "Microsoft",
                            Nome = "Fones de ouvido com fio para jogos",
                            Peso = 1,
                            Preco = 89.90m,
                            Quantidade = 1,
                            Slug = "Fones-de-ouvido-com-fio-para-jogos",
                            ValorBruto = 129.90m,
                            aVenda = true,
                            altura = 5,
                            comprimento = 5,
                            emEstoque = true,
                            largura = 5
                        });
                });

            modelBuilder.Entity("msShop.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("altura")
                        .HasColumnType("int");

                    b.Property<int>("comprimento")
                        .HasColumnType("int");

                    b.Property<int>("largura")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ShoppingCartItens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("msShop.Models.PedidoDetalhe", b =>
                {
                    b.HasOne("msShop.Models.Pedido", "Pedido")
                        .WithMany("PedidoDetalhes")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("msShop.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("msShop.Models.Produto", b =>
                {
                    b.HasOne("msShop.Models.Categoria", "Categoria")
                        .WithMany("produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("msShop.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("msShop.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");
                });
#pragma warning restore 612, 618
        }
    }
}
