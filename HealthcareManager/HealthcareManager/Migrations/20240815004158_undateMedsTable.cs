using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthcareManager.Migrations
{
    /// <inheritdoc />
    public partial class undateMedsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderModel");

            migrationBuilder.AlterColumn<string>(
                name: "MedicationType",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MedicationName",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MedicationDescription",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MedicationType",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MedicationName",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MedicationDescription",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ProviderModel",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MedicationsDTOMedicationId = table.Column<int>(type: "int", nullable: true),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearsExperience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderModel", x => x.ProviderId);
                    table.ForeignKey(
                        name: "FK_ProviderModel_Medications_MedicationsDTOMedicationId",
                        column: x => x.MedicationsDTOMedicationId,
                        principalTable: "Medications",
                        principalColumn: "MedicationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProviderModel_MedicationsDTOMedicationId",
                table: "ProviderModel",
                column: "MedicationsDTOMedicationId");
        }
    }
}
