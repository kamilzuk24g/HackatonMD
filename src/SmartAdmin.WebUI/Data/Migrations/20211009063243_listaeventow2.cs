using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartAdmin.WebUI.Data.Migrations
{
    public partial class listaeventow2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Events");

            migrationBuilder.AddColumn<decimal>(
                name: "Duration",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Events");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Events",
                nullable: true);
        }
    }
}
