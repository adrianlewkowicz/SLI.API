using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLI.API.Migrations
{
    public partial class ReportsOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameExport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GetDateTimeExport = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserNameExport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");
        }
    }
}
