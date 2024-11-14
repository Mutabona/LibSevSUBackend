using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibSevSUBackend.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class Add_PublishDate_To_News : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "PublishDate",
                table: "News",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "News");
        }
    }
}
