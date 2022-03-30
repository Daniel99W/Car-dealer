using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.CarDealer.Migrations
{
    public partial class AddTitleToCarAnnounce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "car");
        }
    }
}
