using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace villa_app_api.Migrations
{
    public partial class AddVillaNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 14, 22, 52, 9, 321, DateTimeKind.Local).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 14, 22, 52, 9, 321, DateTimeKind.Local).AddTicks(3416));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 14, 22, 52, 9, 321, DateTimeKind.Local).AddTicks(3417));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 0, 34, 12, 695, DateTimeKind.Local).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 0, 34, 12, 695, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 0, 34, 12, 695, DateTimeKind.Local).AddTicks(7899));
        }
    }
}
