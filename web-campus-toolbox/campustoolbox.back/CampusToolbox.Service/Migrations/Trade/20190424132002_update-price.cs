using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusToolbox.Service.Migrations.Trade
{
    public partial class updateprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Supplies",
                newName: "PriceMin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceMin",
                table: "Supplies",
                newName: "Price");
        }
    }
}
