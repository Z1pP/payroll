using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payroll.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SchemeChangeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalWorkingHoursPerMonth",
                table: "Employees",
                newName: "TotalHoursWorked");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "TotalHoursWorked",
                table: "Employees",
                newName: "TotalWorkingHoursPerMonth");
        }
    }
}
