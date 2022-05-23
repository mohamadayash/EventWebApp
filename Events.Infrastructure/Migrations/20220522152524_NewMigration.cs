using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Infrastructure.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Events",
                columns: table => new
                {
                    RfId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EVT_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EVT_EventDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Events", x => x.RfId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EventFiles",
                columns: table => new
                {
                    RfId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EVF_EVT_RFID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EVF_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EVF_Type = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EventFiles", x => x.RfId);
                    table.ForeignKey(
                        name: "FK_tbl_EventFiles_tbl_Events_EVF_EVT_RFID",
                        column: x => x.EVF_EVT_RFID,
                        principalTable: "tbl_Events",
                        principalColumn: "RfId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EventFiles_EVF_EVT_RFID",
                table: "tbl_EventFiles",
                column: "EVF_EVT_RFID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_EventFiles");

            migrationBuilder.DropTable(
                name: "tbl_Events");
        }
    }
}
