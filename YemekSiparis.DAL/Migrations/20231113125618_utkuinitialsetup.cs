using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemekSiparis.DAL.Migrations
{
    public partial class utkuinitialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bf9002b2-678a-4cac-ad34-27f64e000368", "555f10d5-d4f7-401d-83a7-1b6d370a751f" });

            migrationBuilder.UpdateData(
                table: "Beverages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "Beverages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "Beverages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "Beverages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6529));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6531));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6534));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6614));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(6949));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(8218));

            migrationBuilder.UpdateData(
                table: "OrderBags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "OrderDate" },
                values: new object[] { new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(8305), new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(8306) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 15, 56, 17, 500, DateTimeKind.Local).AddTicks(9956));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "30ecf82b-3342-4ef5-8a8f-db20e12f5403", "67715e0a-17b6-4604-8927-ce2c89d46a1d" });

            migrationBuilder.UpdateData(
                table: "Beverages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "Beverages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "Beverages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "Beverages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(8792));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(8806));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(9272));

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 669, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 670, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 670, DateTimeKind.Local).AddTicks(1262));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 670, DateTimeKind.Local).AddTicks(1266));

            migrationBuilder.UpdateData(
                table: "OrderBags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "OrderDate" },
                values: new object[] { new DateTime(2023, 11, 12, 23, 15, 12, 670, DateTimeKind.Local).AddTicks(1437), new DateTime(2023, 11, 12, 23, 15, 12, 670, DateTimeKind.Local).AddTicks(1438) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 670, DateTimeKind.Local).AddTicks(4001));

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 23, 15, 12, 670, DateTimeKind.Local).AddTicks(4014));
        }
    }
}
