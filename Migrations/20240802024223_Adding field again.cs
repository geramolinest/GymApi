using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Migrations
{
    /// <inheritdoc />
    public partial class Addingfieldagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "Suscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Suscriptions");
        }
    }
}
