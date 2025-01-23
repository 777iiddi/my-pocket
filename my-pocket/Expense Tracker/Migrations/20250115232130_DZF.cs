using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MY_POCKET.Migrations
{
    /// <inheritdoc />
    public partial class DZF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Transactions",
                type: "varchar(75)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Categories",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Categories",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Categories",
                type: "varchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Transactions",
                type: "nvarchar(75)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(75)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Categories",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Categories",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Categories",
                type: "nvarchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)");
        }
    }
}
