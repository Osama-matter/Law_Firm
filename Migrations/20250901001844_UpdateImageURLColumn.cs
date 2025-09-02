using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Law_Firm.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageURLColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IMagURL",
                table: "Services",
                newName: "ImageURL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Services",
                newName: "IMagURL");
        }
    }
}
