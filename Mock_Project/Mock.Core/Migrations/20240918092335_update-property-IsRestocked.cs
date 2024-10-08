﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Core.Migrations
{
    /// <inheritdoc />
    public partial class updatepropertyIsRestocked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRestocked",
                table: "Borrowings",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRestocked",
                table: "Borrowings");
        }
    }
}
