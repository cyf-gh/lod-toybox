using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusToolbox.Service.Migrations
{
    public partial class updatehp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hp",
                table: "_SharedAbsolutelyVisiableAccountModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hp",
                table: "_SharedAbsolutelyVisiableAccountModel");
        }
    }
}
