using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "BorrowingDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedPickUpDate", "ExpectedReturnDate", "RequestDate" },
                values: new object[] { new DateTime(2024, 9, 16, 9, 12, 20, 378, DateTimeKind.Local).AddTicks(6374), new DateTime(2024, 9, 23, 9, 12, 20, 378, DateTimeKind.Local).AddTicks(6375), new DateTime(2024, 9, 11, 9, 12, 20, 378, DateTimeKind.Local).AddTicks(6327) });

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActualPickUpDate", "ExpectedPickUpDate", "ExpectedReturnDate", "RequestDate" },
                values: new object[] { new DateTime(2024, 9, 8, 9, 12, 20, 378, DateTimeKind.Local).AddTicks(6386), new DateTime(2024, 9, 8, 9, 12, 20, 378, DateTimeKind.Local).AddTicks(6385), new DateTime(2024, 9, 21, 9, 12, 20, 378, DateTimeKind.Local).AddTicks(6388), new DateTime(2024, 9, 6, 9, 12, 20, 378, DateTimeKind.Local).AddTicks(6384) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "BorrowingDetails");

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedPickUpDate", "ExpectedReturnDate", "RequestDate" },
                values: new object[] { new DateTime(2024, 9, 15, 0, 11, 42, 708, DateTimeKind.Local).AddTicks(4950), new DateTime(2024, 9, 22, 0, 11, 42, 708, DateTimeKind.Local).AddTicks(4952), new DateTime(2024, 9, 10, 0, 11, 42, 708, DateTimeKind.Local).AddTicks(4933) });

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActualPickUpDate", "ExpectedPickUpDate", "ExpectedReturnDate", "RequestDate" },
                values: new object[] { new DateTime(2024, 9, 7, 0, 11, 42, 708, DateTimeKind.Local).AddTicks(4962), new DateTime(2024, 9, 7, 0, 11, 42, 708, DateTimeKind.Local).AddTicks(4962), new DateTime(2024, 9, 20, 0, 11, 42, 708, DateTimeKind.Local).AddTicks(4963), new DateTime(2024, 9, 5, 0, 11, 42, 708, DateTimeKind.Local).AddTicks(4961) });
        }
    }
}
