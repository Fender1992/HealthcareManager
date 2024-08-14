using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthcareManager.Migrations
{
    /// <inheritdoc />
    public partial class MedicationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicationCount = table.Column<int>(type: "int", nullable: false),
                    DatePrescribed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationId);
                });

            migrationBuilder.CreateTable(
                name: "ProviderModel",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    YearsExperience = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicationsDTOMedicationId = table.Column<int>(type: "int", nullable: true)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderModel");

            migrationBuilder.DropTable(
                name: "Medications");
        }
    }
}
