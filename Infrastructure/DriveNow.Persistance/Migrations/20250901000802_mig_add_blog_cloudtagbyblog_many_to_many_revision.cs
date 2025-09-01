using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveNow.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_blog_cloudtagbyblog_many_to_many_revision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCloudTagByBlog");

            migrationBuilder.AddColumn<Guid>(
                name: "BlogId",
                table: "CloudTagByBlogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlogCloudTagByBlogs",
                columns: table => new
                {
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CloudTagByBlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCloudTagByBlogs", x => new { x.BlogId, x.CloudTagByBlogId });
                    table.ForeignKey(
                        name: "FK_BlogCloudTagByBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogCloudTagByBlogs_CloudTagByBlogs_CloudTagByBlogId",
                        column: x => x.CloudTagByBlogId,
                        principalTable: "CloudTagByBlogs",
                        principalColumn: "CloudTagByBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CloudTagByBlogs_BlogId",
                table: "CloudTagByBlogs",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCloudTagByBlogs_CloudTagByBlogId",
                table: "BlogCloudTagByBlogs",
                column: "CloudTagByBlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_CloudTagByBlogs_Blogs_BlogId",
                table: "CloudTagByBlogs",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CloudTagByBlogs_Blogs_BlogId",
                table: "CloudTagByBlogs");

            migrationBuilder.DropTable(
                name: "BlogCloudTagByBlogs");

            migrationBuilder.DropIndex(
                name: "IX_CloudTagByBlogs_BlogId",
                table: "CloudTagByBlogs");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "CloudTagByBlogs");

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
    }
}
