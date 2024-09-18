using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mock.Core.Migrations
{
    /// <inheritdoc />
    public partial class addpropertyIsPickUpLate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPickUpLate",
                table: "Borrowings",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPickUpLate",
                table: "Borrowings");
        }
    }
}
