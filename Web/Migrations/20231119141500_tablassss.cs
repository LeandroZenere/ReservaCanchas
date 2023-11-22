using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class tablassss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cancha_Estado_idEstado",
                table: "Cancha");

            migrationBuilder.DropIndex(
                name: "IX_Cancha_idEstado",
                table: "Cancha");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Cancha");

            migrationBuilder.DropColumn(
                name: "idEstado",
                table: "Cancha");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_idEstado",
                table: "Reserva",
                column: "idEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Estado_idEstado",
                table: "Reserva",
                column: "idEstado",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Estado_idEstado",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_idEstado",
                table: "Reserva");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Cancha",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idEstado",
                table: "Cancha",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cancha_idEstado",
                table: "Cancha",
                column: "idEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_Cancha_Estado_idEstado",
                table: "Cancha",
                column: "idEstado",
                principalTable: "Estado",
                principalColumn: "Id");
        }
    }
}
