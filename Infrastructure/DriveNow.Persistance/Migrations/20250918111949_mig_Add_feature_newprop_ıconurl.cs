using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveNow.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_Add_feature_newprop_ıconurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Features");
        }
    }
}
