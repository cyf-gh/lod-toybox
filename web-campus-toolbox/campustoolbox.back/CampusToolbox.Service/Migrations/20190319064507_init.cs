using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CampusToolbox.Service.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_SharedAbsolutelyVisiableAccountModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NickName = table.Column<string>(nullable: true),
                    College = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SharedAbsolutelyVisiableAccountModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_SharedRelieableAccountModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    City = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Grade = table.Column<int>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SharedRelieableAccountModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_SharedSystemAccountModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PasswordEncrypted = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SharedSystemAccountModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SysId = table.Column<int>(nullable: true),
                    AbsVisiableId = table.Column<int>(nullable: true),
                    RelieableId = table.Column<int>(nullable: true),
                    Identity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts__SharedAbsolutelyVisiableAccountModel_AbsVisiableId",
                        column: x => x.AbsVisiableId,
                        principalTable: "_SharedAbsolutelyVisiableAccountModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts__SharedRelieableAccountModel_RelieableId",
                        column: x => x.RelieableId,
                        principalTable: "_SharedRelieableAccountModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts__SharedSystemAccountModel_SysId",
                        column: x => x.SysId,
                        principalTable: "_SharedSystemAccountModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AbsVisiableId",
                table: "Accounts",
                column: "AbsVisiableId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RelieableId",
                table: "Accounts",
                column: "RelieableId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_SysId",
                table: "Accounts",
                column: "SysId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "_SharedAbsolutelyVisiableAccountModel");

            migrationBuilder.DropTable(
                name: "_SharedRelieableAccountModel");

            migrationBuilder.DropTable(
                name: "_SharedSystemAccountModel");
        }
    }
}
