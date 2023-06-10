using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Data.Migrations
{
    public partial class AddUpdatedOnToPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Posts",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Posts");
        }
    }
}
