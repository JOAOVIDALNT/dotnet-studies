using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace villa_app_api.Migrations
{
    public partial class SetNullables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 29, 21, 54, 25, 610, DateTimeKind.Local).AddTicks(8624));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 29, 21, 54, 25, 610, DateTimeKind.Local).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 29, 21, 54, 25, 610, DateTimeKind.Local).AddTicks(8640));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 14, 23, 28, 16, 744, DateTimeKind.Local).AddTicks(5702));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 14, 23, 28, 16, 744, DateTimeKind.Local).AddTicks(5716));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 14, 23, 28, 16, 744, DateTimeKind.Local).AddTicks(5717));
        }
    }
}
