﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthcareManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRoleToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "userForm",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "userForm");
        }
    }
}
