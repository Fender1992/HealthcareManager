using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthcareManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodPressureDiastolic",
                table: "userForm");

            migrationBuilder.DropColumn(
                name: "BloodPressureSystolic",
                table: "userForm");

            migrationBuilder.AddColumn<string>(
                name: "BloodPressure",
                table: "userForm",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodPressure",
                table: "userForm");

            migrationBuilder.AddColumn<int>(
                name: "BloodPressureDiastolic",
                table: "userForm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BloodPressureSystolic",
                table: "userForm",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
