using Microsoft.EntityFrameworkCore.Migrations;

namespace TSM.Data.Application.Migrations
{
    public partial class InitAppData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEducationPrograms_EducationPrograms_ProgramId",
                table: "SchoolEducationPrograms");

            migrationBuilder.RenameColumn(
                name: "ProgramId",
                table: "SchoolEducationPrograms",
                newName: "EducationProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolEducationPrograms_ProgramId",
                table: "SchoolEducationPrograms",
                newName: "IX_SchoolEducationPrograms_EducationProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEducationPrograms_EducationPrograms_EducationProgramId",
                table: "SchoolEducationPrograms",
                column: "EducationProgramId",
                principalTable: "EducationPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEducationPrograms_EducationPrograms_EducationProgramId",
                table: "SchoolEducationPrograms");

            migrationBuilder.RenameColumn(
                name: "EducationProgramId",
                table: "SchoolEducationPrograms",
                newName: "ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolEducationPrograms_EducationProgramId",
                table: "SchoolEducationPrograms",
                newName: "IX_SchoolEducationPrograms_ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEducationPrograms_EducationPrograms_ProgramId",
                table: "SchoolEducationPrograms",
                column: "ProgramId",
                principalTable: "EducationPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
