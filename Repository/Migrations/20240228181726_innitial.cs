using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repository.Migrations
{
    public partial class innitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "premios",
                columns: table => new
                {
                    idPremio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombrePremio = table.Column<string>(type: "longtext", nullable: false),
                    ValorEnPuntos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premios", x => x.idPremio);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

           

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombreProducto = table.Column<string>(type: "longtext", nullable: false),
                    precio = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.idProducto);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    idUsario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombreUsuario = table.Column<string>(type: "longtext", nullable: false),
                    contraseña = table.Column<string>(type: "longtext", nullable: false),
                    diaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.idUsario);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "comprasrealizadas",
                columns: table => new
                {
                    idCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    fechaCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    TotalCompra = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comprasrealizadas", x => x.idCompra);
                    table.ForeignKey(
                        name: "FK_comprasrealizadas_usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "usuarios",
                        principalColumn: "idUsario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "premioscanjeados",
                columns: table => new
                {
                    idPremioCanjeado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idPremio = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    fechaCanje = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premioscanjeados", x => x.idPremioCanjeado);
                    table.ForeignKey(
                        name: "FK_premioscanjeados_premios_idPremio",
                        column: x => x.idPremio,
                        principalTable: "premios",
                        principalColumn: "idPremio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_premioscanjeados_usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "usuarios",
                        principalColumn: "idUsario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "puntos",
                columns: table => new
                {
                    idPuntos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puntos", x => x.idPuntos);
                    table.ForeignKey(
                        name: "FK_puntos_usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "idUsario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detallescomprasrealizadas",
                columns: table => new
                {
                    idDetalleCOmpra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idCompra = table.Column<int>(type: "int", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<double>(type: "double", nullable: false),
                    fechaCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallescomprasrealizadas", x => x.idDetalleCOmpra);
                    table.ForeignKey(
                        name: "FK_detallescomprasrealizadas_comprasrealizadas_idCompra",
                        column: x => x.idCompra,
                        principalTable: "comprasrealizadas",
                        principalColumn: "idCompra",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_comprasrealizadas_idUsuario",
                table: "comprasrealizadas",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_detallescomprasrealizadas_idCompra",
                table: "detallescomprasrealizadas",
                column: "idCompra");

            migrationBuilder.CreateIndex(
                name: "IX_premioscanjeados_idPremio",
                table: "premioscanjeados",
                column: "idPremio");

            migrationBuilder.CreateIndex(
                name: "IX_premioscanjeados_idUsuario",
                table: "premioscanjeados",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_puntos_IdUsuario",
                table: "puntos",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detallescomprasrealizadas");

            migrationBuilder.DropTable(
                name: "premioscanjeados");


            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "puntos");

            migrationBuilder.DropTable(
                name: "comprasrealizadas");

            migrationBuilder.DropTable(
                name: "premios");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
