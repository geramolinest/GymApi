using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Migrations
{
    /// <inheritdoc />
    public partial class Optionrelationshipsuscriptorsuscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suscriptors_Suscriptions_SuscriptionId",
                table: "Suscriptors");

            migrationBuilder.AlterColumn<int>(
                name: "SuscriptionId",
                table: "Suscriptors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Suscriptors_Suscriptions_SuscriptionId",
                table: "Suscriptors",
                column: "SuscriptionId",
                principalTable: "Suscriptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suscriptors_Suscriptions_SuscriptionId",
                table: "Suscriptors");

            migrationBuilder.AlterColumn<int>(
                name: "SuscriptionId",
                table: "Suscriptors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Suscriptors_Suscriptions_SuscriptionId",
                table: "Suscriptors",
                column: "SuscriptionId",
                principalTable: "Suscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
