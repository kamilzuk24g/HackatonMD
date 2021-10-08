using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartAdmin.WebUI.Data.Migrations
{
    public partial class UserFilterParametersNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "UserFilterParams");

            migrationBuilder.CreateTable(
                name: "UserFilterParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    PriceMin = table.Column<decimal>(nullable: true),
                    PriceMax = table.Column<decimal>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: true),
                    DateTo = table.Column<DateTime>(nullable: true),
                    PeopleMin = table.Column<int>(nullable: true),
                    PeopleMax = table.Column<int>(nullable: true),
                    Remote = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFilterParameters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFilterParameters");

            //migrationBuilder.CreateTable(
            //    name: "UserFilterParams",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        DateFrom = table.Column<DateTime>(nullable: true),
            //        DateTo = table.Column<DateTime>(nullable: true),
            //        PeopleMax = table.Column<int>(nullable: true),
            //        PeopleMin = table.Column<int>(nullable: true),
            //        PriceMax = table.Column<decimal>(nullable: true),
            //        PriceMin = table.Column<decimal>(nullable: true),
            //        Remote = table.Column<bool>(nullable: true),
            //        UserId = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserFilterParams", x => x.Id);
            //    });
        }
    }
}