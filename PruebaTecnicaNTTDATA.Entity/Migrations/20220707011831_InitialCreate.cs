using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaNTTDATA.Entity.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy",1),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    edad = table.Column<int>(type: "int", nullable: true),
                    genero = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    identificacion = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    cliente_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy",1),
                    contrasenia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    persona_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.cliente_id);
                    table.ForeignKey(
                        name: "FK_Clientes_Persona_persona_id",
                        column: x => x.persona_id,
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy",1),
                    numero_cuenta = table.Column<int>(type: "int", nullable: true),
                    tipo_cuenta = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    saldo_inicial = table.Column<double>(type: "double", nullable: true),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    cliente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cuentas_Clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "Clientes",
                        principalColumn: "cliente_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy",1),
                    fecha = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    tipo_movimiento = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    valor = table.Column<double>(type: "double", nullable: true),
                    saldo = table.Column<double>(type: "double", nullable: true),
                    cuentas_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movimientos_Cuentas_cuentas_id",
                        column: x => x.cuentas_id,
                        principalTable: "Cuentas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_persona_id",
                table: "Clientes",
                column: "persona_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_cliente_id",
                table: "Cuentas",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_cuentas_id",
                table: "Movimientos",
                column: "cuentas_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
