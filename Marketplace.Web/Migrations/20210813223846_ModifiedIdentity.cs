using Microsoft.EntityFrameworkCore.Migrations;

namespace Marketplace.Web.Migrations
{
    public partial class ModifiedIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Shop_ShopId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPictures_Products_ProductId",
                table: "ProductPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shop_ShopId",
                table: "Products");

            migrationBuilder.AlterColumn<long>(
                name: "ShopId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "ProductPictures",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ShopId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Shop_ShopId",
                table: "AspNetUsers",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPictures_Products_ProductId",
                table: "ProductPictures",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shop_ShopId",
                table: "Products",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Shop_ShopId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPictures_Products_ProductId",
                table: "ProductPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shop_ShopId",
                table: "Products");

            migrationBuilder.AlterColumn<long>(
                name: "ShopId",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "ProductPictures",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ShopId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Shop_ShopId",
                table: "AspNetUsers",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPictures_Products_ProductId",
                table: "ProductPictures",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shop_ShopId",
                table: "Products",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
