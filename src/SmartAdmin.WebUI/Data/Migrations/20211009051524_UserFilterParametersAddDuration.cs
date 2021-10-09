using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartAdmin.WebUI.Data.Migrations
{
    public partial class UserFilterParametersAddDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationFrom",
                table: "UserFilterParameters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurationTo",
                table: "UserFilterParameters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationFrom",
                table: "UserFilterParameters");

            migrationBuilder.DropColumn(
                name: "DurationTo",
                table: "UserFilterParameters");
        }
    }
}
