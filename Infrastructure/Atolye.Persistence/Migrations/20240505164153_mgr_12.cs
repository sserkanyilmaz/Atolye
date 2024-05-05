using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atolye.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mgr12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "URl",
                table: "Image",
                newName: "URL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Image",
                newName: "URl");
        }
    }
}
