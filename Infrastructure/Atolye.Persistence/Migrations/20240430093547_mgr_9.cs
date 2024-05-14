using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atolye.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mgr9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BaseId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BaseId",
                table: "Inventories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BaseId",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BaseId",
                table: "BaseNew",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BaseId",
                table: "ActivityLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FixtureInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bases_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bases_FixtureInformations_FixtureInformationId",
                        column: x => x.FixtureInformationId,
                        principalTable: "FixtureInformations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_BaseId",
                table: "Teams",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_BaseId",
                table: "Inventories",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_BaseId",
                table: "Image",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseNew_BaseId",
                table: "BaseNew",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_BaseId",
                table: "ActivityLogs",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_ContactId",
                table: "Bases",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_FixtureInformationId",
                table: "Bases",
                column: "FixtureInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLogs_Bases_BaseId",
                table: "ActivityLogs",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseNew_Bases_BaseId",
                table: "BaseNew",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Bases_BaseId",
                table: "Image",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Bases_BaseId",
                table: "Inventories",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Bases_BaseId",
                table: "Teams",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLogs_Bases_BaseId",
                table: "ActivityLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseNew_Bases_BaseId",
                table: "BaseNew");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Bases_BaseId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Bases_BaseId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Bases_BaseId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Bases");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Teams_BaseId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_BaseId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Image_BaseId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_BaseNew_BaseId",
                table: "BaseNew");

            migrationBuilder.DropIndex(
                name: "IX_ActivityLogs_BaseId",
                table: "ActivityLogs");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "BaseNew");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "ActivityLogs");
        }
    }
}
