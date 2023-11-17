using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class pruebaimport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Estado_idEstado",
                table: "Reserva");

            migrationBuilder.DropTable(
                name: "ListaPrecio");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_idEstado",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Disponible",
                table: "Cancha");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Cancha",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cancha_Estado_idEstado",
                table: "Cancha");

            migrationBuilder.DropIndex(
                name: "IX_Cancha_idEstado",
                table: "Cancha");

            migrationBuilder.DropColumn(
                name: "idEstado",
                table: "Cancha");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Cancha",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Disponible",
                table: "Cancha",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ListaPrecio",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disponible = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaPrecio", x => x.ID);
                });

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
    }
}
