using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeWarehouse.Data.Migrations
{
    public partial class addLocationAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "FridgeProduct");

            migrationBuilder.AddColumn<string>(
                name: "LocationAddress",
                table: "Fridges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationAddress",
                table: "Fridges");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FridgeProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
