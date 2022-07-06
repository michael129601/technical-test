﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaTecnicaNTTDATA.Entity.Connector;

#nullable disable

namespace PruebaTecnicaNTTDATA.Entity.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PruebaTecnicaNTTDATA.Entity.Models.Clientes", b =>
                {
                    b.Property<int>("Clienteid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("contrasenia");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("estado");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int")
                        .HasColumnName("persona_id");

                    b.HasKey("Clienteid");

                    b.HasIndex("PersonaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PruebaTecnicaNTTDATA.Entity.Models.Cuentas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<int?>("Edad")
                        .HasColumnType("int")
                        .HasColumnName("edad");

                    b.Property<bool?>("Estado")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("estado");

                    b.Property<int?>("NumeroCuenta")
                        .HasColumnType("int")
                        .HasColumnName("numero_cuenta");

                    b.Property<double?>("SaldoInicial")
                        .HasColumnType("double")
                        .HasColumnName("saldo_inicial");

                    b.Property<string>("TipoCuenta")
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("tipo_cuenta");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("PruebaTecnicaNTTDATA.Entity.Models.Movimientos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CuentasId")
                        .HasColumnType("int")
                        .HasColumnName("cuentas_id");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("fecha");

                    b.Property<double?>("Saldo")
                        .HasColumnType("double")
                        .HasColumnName("saldo");

                    b.Property<string>("TipoMovimiento")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("tipo_movimiento");

                    b.Property<double?>("Valor")
                        .HasColumnType("double")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.HasIndex("CuentasId");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("PruebaTecnicaNTTDATA.Entity.Models.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Direccion")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("direccion");

                    b.Property<int?>("Edad")
                        .HasColumnType("int")
                        .HasColumnName("edad");

                    b.Property<string>("Genero")
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("genero");

                    b.Property<string>("Identificacion")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("identificacion");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("PruebaTecnicaNTTDATA.Entity.Models.Clientes", b =>
                {
                    b.HasOne("PruebaTecnicaNTTDATA.Entity.Models.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("PruebaTecnicaNTTDATA.Entity.Models.Cuentas", b =>
                {
                    b.HasOne("PruebaTecnicaNTTDATA.Entity.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("PruebaTecnicaNTTDATA.Entity.Models.Movimientos", b =>
                {
                    b.HasOne("PruebaTecnicaNTTDATA.Entity.Models.Cuentas", "Cuentas")
                        .WithMany()
                        .HasForeignKey("CuentasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuentas");
                });
#pragma warning restore 612, 618
        }
    }
}
