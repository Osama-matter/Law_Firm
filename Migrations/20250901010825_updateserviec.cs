using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Law_Firm.Migrations
{
    /// <inheritdoc />
    public partial class updateserviec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Services",
                newName: "SubDescription");

            migrationBuilder.AddColumn<string>(
                name: "IMagURL",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IconImage",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMagURL",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IconImage",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "SubDescription",
                table: "Services",
                newName: "ImageURL");
        }
    }
}
