using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveNow.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_blogcontent_and_blog_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogContents",
                columns: table => new
                {
                    BlogContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogContents", x => x.BlogContentId);
                    table.ForeignKey(
                        name: "FK_BlogContents_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogContents_BlogId",
                table: "BlogContents",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogContents");
        }
    }
}
