using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddWishListToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedPickUpDate", "ExpectedReturnDate", "RequestDate" },
                values: new object[] { new DateTime(2024, 9, 16, 11, 2, 52, 804, DateTimeKind.Local).AddTicks(6237), new DateTime(2024, 9, 23, 11, 2, 52, 804, DateTimeKind.Local).AddTicks(6240), new DateTime(2024, 9, 11, 11, 2, 52, 804, DateTimeKind.Local).AddTicks(6211) });

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActualPickUpDate", "ExpectedPickUpDate", "ExpectedReturnDate", "RequestDate" },
                values: new object[] { new DateTime(2024, 9, 8, 11, 2, 52, 804, DateTimeKind.Local).AddTicks(6249), new DateTime(2024, 9, 8, 11, 2, 52, 804, DateTimeKind.Local).AddTicks(6249), new DateTime(2024, 9, 21, 11, 2, 52, 804, DateTimeKind.Local).AddTicks(6250), new DateTime(2024, 9, 6, 11, 2, 52, 804, DateTimeKind.Local).AddTicks(6248) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
