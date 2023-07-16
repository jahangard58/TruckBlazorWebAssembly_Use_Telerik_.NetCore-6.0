using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckBlazorWebAssembly.Server.Migrations
{
    public partial class secound6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Carryingweight",
                table: "Trucks",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carryingweight",
                table: "Trucks");
        }
    }
}
