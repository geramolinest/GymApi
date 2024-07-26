using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Migrations
{
    /// <inheritdoc />
    public partial class Fixingrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Suscriptions_SuscriptionTypeId",
                table: "Suscriptions");

            migrationBuilder.CreateIndex(
                name: "IX_Suscriptions_SuscriptionTypeId",
                table: "Suscriptions",
                column: "SuscriptionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Suscriptions_SuscriptionTypeId",
                table: "Suscriptions");

            migrationBuilder.CreateIndex(
                name: "IX_Suscriptions_SuscriptionTypeId",
                table: "Suscriptions",
                column: "SuscriptionTypeId",
                unique: true);
        }
    }
}
