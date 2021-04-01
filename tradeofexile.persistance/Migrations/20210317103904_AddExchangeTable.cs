using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tradeofexile.persistance.Migrations
{
    public partial class AddExchangeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseHandlerHelpers",
                table: "ResponseHandlerHelpers");

            migrationBuilder.RenameTable(
                name: "ResponseHandlerHelpers",
                newName: "ResponeHandlerHelpers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponeHandlerHelpers",
                table: "ResponeHandlerHelpers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ExchangeTable",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    FromCurrency = table.Column<int>(type: "int", nullable: false),
                    ToCurrency = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "double", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponeHandlerHelpers",
                table: "ResponeHandlerHelpers");

            migrationBuilder.RenameTable(
                name: "ResponeHandlerHelpers",
                newName: "ResponseHandlerHelpers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseHandlerHelpers",
                table: "ResponseHandlerHelpers",
                column: "Id");
        }
    }
}
