﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveNow.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPublishedToBlogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Blogs");
        }
    }
}
