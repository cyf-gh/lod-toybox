using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusToolbox.Service.Migrations.Trade
{
    public partial class addcollege : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Collage",
                table: "Supplies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Collage",
                table: "Demands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Collage",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "Collage",
                table: "Demands");
        }
    }
}
