using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveNow.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_paragraph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "paragraphs",
                columns: table => new
                {
                    ParagraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegendName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LegendDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paragraphs", x => x.ParagraphId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paragraphs");
        }
    }
}
