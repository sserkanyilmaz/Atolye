using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atolye.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mgr11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BaseId",
                table: "CareerStuffs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CareerStuffs_BaseId",
                table: "CareerStuffs",
                column: "BaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareerStuffs_Bases_BaseId",
                table: "CareerStuffs",
                column: "BaseId",
                principalTable: "Bases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerStuffs_Bases_BaseId",
                table: "CareerStuffs");

            migrationBuilder.DropIndex(
                name: "IX_CareerStuffs_BaseId",
                table: "CareerStuffs");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "CareerStuffs");
        }
    }
}
