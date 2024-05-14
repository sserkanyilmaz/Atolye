using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atolye.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mgr13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "news",
                table: "BaseNew",
                newName: "News");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "News",
                table: "BaseNew",
                newName: "news");
        }
    }
}
