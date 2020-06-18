﻿// <auto-generated />
using System;
using ComercioLocalBackEnd.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ComercioLocalBackEnd.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200618003508_CreateTablePromocao")]
    partial class CreateTablePromocao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ComercioLocalBackEnd.Models.Perfil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<string>("DataAbertura")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fantasia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .HasColumnType("text");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Razao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Segmento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Site")
                        .HasColumnType("text");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("ComercioLocalBackEnd.Models.Promocao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CupomPromocao")
                        .HasColumnType("text");

                    b.Property<string>("DataFim")
                        .HasColumnType("text");

                    b.Property<string>("DataInicio")
                        .HasColumnType("text");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MidiaPromocao")
                        .HasColumnType("text");

                    b.Property<Guid>("PerfilId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Promocoes");
                });

            modelBuilder.Entity("ComercioLocalBackEnd.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DataNascimento")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TelefoneFixo")
                        .HasColumnType("text");

                    b.Property<string>("TelefoneMovel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ComercioLocalBackEnd.Models.Perfil", b =>
                {
                    b.HasOne("ComercioLocalBackEnd.Models.Usuario", "Usuario")
                        .WithOne()
                        .HasForeignKey("ComercioLocalBackEnd.Models.Perfil", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComercioLocalBackEnd.Models.Promocao", b =>
                {
                    b.HasOne("ComercioLocalBackEnd.Models.Perfil", "Perfil")
                        .WithMany("Promocoes")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
