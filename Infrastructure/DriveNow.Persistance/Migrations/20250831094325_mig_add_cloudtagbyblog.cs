using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveNow.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_cloudtagbyblog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CloudTagByBlogs",
                columns: table => new
                {
                    CloudTagByBlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloudTagByBlogs", x => x.CloudTagByBlogId);
                });

            migrationBuilder.CreateTable(
                name: "BlogCloudTagByBlog",
                columns: table => new
                {
                    BlogsBlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CloudTagByBlogsCloudTagByBlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCloudTagByBlog", x => new { x.BlogsBlogId, x.CloudTagByBlogsCloudTagByBlogId });
                    table.ForeignKey(
                        name: "FK_BlogCloudTagByBlog_Blogs_BlogsBlogId",
                        column: x => x.BlogsBlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogCloudTagByBlog_CloudTagByBlogs_CloudTagByBlogsCloudTagByBlogId",
                        column: x => x.CloudTagByBlogsCloudTagByBlogId,
                        principalTable: "CloudTagByBlogs",
                        principalColumn: "CloudTagByBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCloudTagByBlog_CloudTagByBlogsCloudTagByBlogId",
                table: "BlogCloudTagByBlog",
                column: "CloudTagByBlogsCloudTagByBlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCloudTagByBlog");

            migrationBuilder.DropTable(
                name: "CloudTagByBlogs");
        }
    }
}
