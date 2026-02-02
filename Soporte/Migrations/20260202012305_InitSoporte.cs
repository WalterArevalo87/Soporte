using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soporte.Migrations
{
    /// <inheritdoc />
    public partial class InitSoporte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Gestores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechainicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechafin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Atms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GestoresModelId = table.Column<int>(type: "int", nullable: false),
                    MantenimientoModelId = table.Column<int>(type: "int", nullable: false),
                    MantenimientosModelid = table.Column<int>(type: "int", nullable: false),
                    AgenciasModelId = table.Column<int>(type: "int", nullable: false),
                    BancosModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atms", x => x.id);
                    table.ForeignKey(
                        name: "FK_Atms_Agencias_AgenciasModelId",
                        column: x => x.AgenciasModelId,
                        principalTable: "Agencias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Atms_Bancos_BancosModelId",
                        column: x => x.BancosModelId,
                        principalTable: "Bancos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Atms_Gestores_GestoresModelId",
                        column: x => x.GestoresModelId,
                        principalTable: "Gestores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Atms_Mantenimientos_MantenimientosModelid",
                        column: x => x.MantenimientosModelid,
                        principalTable: "Mantenimientos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atms_AgenciasModelId",
                table: "Atms",
                column: "AgenciasModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Atms_BancosModelId",
                table: "Atms",
                column: "BancosModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Atms_GestoresModelId",
                table: "Atms",
                column: "GestoresModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Atms_MantenimientosModelid",
                table: "Atms",
                column: "MantenimientosModelid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atms");

            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropTable(
                name: "Bancos");

            migrationBuilder.DropTable(
                name: "Gestores");

            migrationBuilder.DropTable(
                name: "Mantenimientos");
        }
    }
}
