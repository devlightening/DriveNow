using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveNow.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_paragraph3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_paragraphs",
                table: "paragraphs");

            migrationBuilder.RenameTable(
                name: "paragraphs",
                newName: "Paragraphs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paragraphs",
                table: "Paragraphs",
                column: "ParagraphId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Paragraphs",
                table: "Paragraphs");

            migrationBuilder.RenameTable(
                name: "Paragraphs",
                newName: "paragraphs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_paragraphs",
                table: "paragraphs",
                column: "ParagraphId");
        }
    }
}
