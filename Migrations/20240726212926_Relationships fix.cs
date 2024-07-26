using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Migrations
{
    /// <inheritdoc />
    public partial class Relationshipsfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suscriptions_SuscriptionsTypes_SuscriptionTypeId",
                table: "Suscriptions");

            migrationBuilder.AlterColumn<int>(
                name: "SuscriptionTypeId",
                table: "Suscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Suscriptions_SuscriptionsTypes_SuscriptionTypeId",
                table: "Suscriptions",
                column: "SuscriptionTypeId",
                principalTable: "SuscriptionsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suscriptions_SuscriptionsTypes_SuscriptionTypeId",
                table: "Suscriptions");

            migrationBuilder.AlterColumn<int>(
                name: "SuscriptionTypeId",
                table: "Suscriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Suscriptions_SuscriptionsTypes_SuscriptionTypeId",
                table: "Suscriptions",
                column: "SuscriptionTypeId",
                principalTable: "SuscriptionsTypes",
                principalColumn: "Id");
        }
    }
}
