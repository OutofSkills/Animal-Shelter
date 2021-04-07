using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Server.Data.Migrations
{
    public partial class InitialProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "ProductImageUrl", "VatPercentage" },
                values: new object[] { 1, "DogFood", 10.99m, "https://avatars.mds.yandex.net/get-mpic/1911047/img_id1348695894112523125.jpeg/orig", 21 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
