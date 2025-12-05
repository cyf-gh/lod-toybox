using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CampusToolbox.Service.Migrations.HHI
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "backModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OwnerId = table.Column<int>(nullable: false),
                    Images = table.Column<List<string>>(nullable: true),
                    TaskId = table.Column<int>(nullable: false),
                    LastCommitTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_backModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "classModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prefixModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Start = table.Column<int>(nullable: false),
                    End = table.Column<int>(nullable: false),
                    IndexList = table.Column<List<int>>(nullable: true),
                    IncludeList = table.Column<List<string>>(nullable: true),
                    ExcludeList = table.Column<List<string>>(nullable: true),
                    MemberNameList = table.Column<List<string>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prefixModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "workModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OwnerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsSubItemFolder = table.Column<bool>(nullable: false),
                    IsSubItemImage = table.Column<bool>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Regex = table.Column<string>(nullable: true),
                    PrefixName = table.Column<string>(nullable: true),
                    PrefixId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DeadLine = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workModels_prefixModels_PrefixId",
                        column: x => x.PrefixId,
                        principalTable: "prefixModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_workModels_PrefixId",
                table: "workModels",
                column: "PrefixId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "backModel");

            migrationBuilder.DropTable(
                name: "classModels");

            migrationBuilder.DropTable(
                name: "workModels");

            migrationBuilder.DropTable(
                name: "prefixModels");
        }
    }
}
