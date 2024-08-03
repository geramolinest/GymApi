using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApi.Migrations
{
    /// <inheritdoc />
    public partial class FixingrelationshipProductSaleSaleProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sales_SaleId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SaleId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_SalesProducts_ProductId",
                table: "SalesProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesProducts_SaleId",
                table: "SalesProducts",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesProducts_Products_ProductId",
                table: "SalesProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesProducts_Sales_SaleId",
                table: "SalesProducts",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesProducts_Products_ProductId",
                table: "SalesProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesProducts_Sales_SaleId",
                table: "SalesProducts");

            migrationBuilder.DropIndex(
                name: "IX_SalesProducts_ProductId",
                table: "SalesProducts");

            migrationBuilder.DropIndex(
                name: "IX_SalesProducts_SaleId",
                table: "SalesProducts");

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SaleId",
                table: "Products",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sales_SaleId",
                table: "Products",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
