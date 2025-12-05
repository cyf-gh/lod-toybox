using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CampusToolbox.Service.Migrations.TokenSession
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_AccountBackModel_AccountId",
                table: "Tokens");

            migrationBuilder.DropTable(
                name: "AccountBackModel");

            migrationBuilder.DropTable(
                name: "_SharedAbsolutelyVisiableAccountModel");

            migrationBuilder.DropTable(
                name: "_SharedRelieableAccountModel");

            migrationBuilder.DropTable(
                name: "_SharedSystemAccountModel");

            migrationBuilder.DropIndex(
                name: "IX_Tokens_AccountId",
                table: "Tokens");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Tokens",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Tokens",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "_SharedAbsolutelyVisiableAccountModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    College = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true)
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
                    District = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Grade = table.Column<int>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
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
                name: "AccountBackModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AbsVisiableId = table.Column<int>(nullable: true),
                    Identity = table.Column<int>(nullable: false),
                    RelieableId = table.Column<int>(nullable: true),
                    SysId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBackModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountBackModel__SharedAbsolutelyVisiableAccountModel_AbsV~",
                        column: x => x.AbsVisiableId,
                        principalTable: "_SharedAbsolutelyVisiableAccountModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountBackModel__SharedRelieableAccountModel_RelieableId",
                        column: x => x.RelieableId,
                        principalTable: "_SharedRelieableAccountModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountBackModel__SharedSystemAccountModel_SysId",
                        column: x => x.SysId,
                        principalTable: "_SharedSystemAccountModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_AccountId",
                table: "Tokens",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBackModel_AbsVisiableId",
                table: "AccountBackModel",
                column: "AbsVisiableId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBackModel_RelieableId",
                table: "AccountBackModel",
                column: "RelieableId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBackModel_SysId",
                table: "AccountBackModel",
                column: "SysId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_AccountBackModel_AccountId",
                table: "Tokens",
                column: "AccountId",
                principalTable: "AccountBackModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
