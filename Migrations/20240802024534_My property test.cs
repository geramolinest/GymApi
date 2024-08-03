using System.Runtime.InteropServices.Marshalling;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Migrations
{
    /// <inheritdoc />
    public partial class Mypropertytest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Suscriptions"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Suscriptions_SuscriptionsTypes_SuscriptionTypeId",
                table: "Suscriptions"
            );

            migrationBuilder.DropIndex(
                name: "IX_Suscriptions_SuscriptionTypeId",
                table: "Suscriptions"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Suscriptions_SuscriptionsTypes_SuscriptionTypeId",
                table: "Suscriptions",
                column: "SuscriptionTypeId",
                principalTable: "SuscriptionsTypes",
                principalColumn: "Id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Suscriptions_SuscriptionTypeId",
                table: "Suscriptions",
                column: "SuscriptionTypeId",
                unique: false
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Suscriptions");
        }
    }
}
