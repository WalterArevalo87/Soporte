using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soporte.Migrations.Soportes
{
    /// <inheritdoc />
    public partial class InitSoportes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atms_Mantenimientos_MantenimientosModelid",
                table: "Atms");

            migrationBuilder.DropColumn(
                name: "MantenimientoModelId",
                table: "Atms");

            migrationBuilder.RenameColumn(
                name: "MantenimientosModelid",
                table: "Atms",
                newName: "MantenimientosModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Atms_MantenimientosModelid",
                table: "Atms",
                newName: "IX_Atms_MantenimientosModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atms_Mantenimientos_MantenimientosModelId",
                table: "Atms",
                column: "MantenimientosModelId",
                principalTable: "Mantenimientos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atms_Mantenimientos_MantenimientosModelId",
                table: "Atms");

            migrationBuilder.RenameColumn(
                name: "MantenimientosModelId",
                table: "Atms",
                newName: "MantenimientosModelid");

            migrationBuilder.RenameIndex(
                name: "IX_Atms_MantenimientosModelId",
                table: "Atms",
                newName: "IX_Atms_MantenimientosModelid");

            migrationBuilder.AddColumn<int>(
                name: "MantenimientoModelId",
                table: "Atms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Atms_Mantenimientos_MantenimientosModelid",
                table: "Atms",
                column: "MantenimientosModelid",
                principalTable: "Mantenimientos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
