using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactApp.Migrations
{
    public partial class Date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 6, 14, 14, 47, 35, 211, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 6, 14, 14, 47, 35, 217, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 6, 14, 14, 47, 35, 217, DateTimeKind.Local).AddTicks(979));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Contacts");
        }
    }
}
