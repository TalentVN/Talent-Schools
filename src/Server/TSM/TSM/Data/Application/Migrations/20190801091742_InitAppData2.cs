using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TSM.Data.Application.Migrations
{
    public partial class InitAppData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Areas_AreaId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Areas_AreaId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AreaId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Cities_AreaId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Cities");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Cities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.AddColumn<Guid>(
                name: "AreaId",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AreaId",
                table: "Cities",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AreaId",
                table: "Locations",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_AreaId",
                table: "Cities",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CountryId",
                table: "Areas",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Areas_AreaId",
                table: "Cities",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Areas_AreaId",
                table: "Locations",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
