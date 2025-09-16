using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveNow.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_car_ispublished : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Cars");
        }
    }
}
