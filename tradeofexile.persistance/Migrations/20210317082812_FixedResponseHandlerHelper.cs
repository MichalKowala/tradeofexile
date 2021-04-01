using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tradeofexile.persistance.Migrations
{
    public partial class FixedResponseHandlerHelper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponseHandlerHelpers",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    NextCallId = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseHandlerHelpers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseHandlerHelpers");
        }
    }
}
