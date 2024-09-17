using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.POC.Project.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededRolesAgainWithChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32489fa6-8276-4229-98c8-ac5b6c4e4fc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36d7afdd-be37-438e-aa58-88bcd135c485");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "741584ab-b145-4403-9ae1-01c3a7beac40");

            migrationBuilder.AddColumn<string>(
                name: "Created_by",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Is_Delete",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44e32d87-5478-4510-b97b-4d1081d7d80d", "3", "Employee", "Employee" },
                    { "61c00b56-0608-4634-9ab6-6f9fcdbba7d2", "2", "HR", "HR" },
                    { "ee1caaab-f2c5-408b-8661-b0d7bf0b8a72", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44e32d87-5478-4510-b97b-4d1081d7d80d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61c00b56-0608-4634-9ab6-6f9fcdbba7d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee1caaab-f2c5-408b-8661-b0d7bf0b8a72");

            migrationBuilder.DropColumn(
                name: "Created_by",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Is_Delete",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32489fa6-8276-4229-98c8-ac5b6c4e4fc1", "3", "Employee", "EMPLOYEE" },
                    { "36d7afdd-be37-438e-aa58-88bcd135c485", "1", "Admin", "ADMIN" },
                    { "741584ab-b145-4403-9ae1-01c3a7beac40", "2", "HR", "HR" }
                });
        }
    }
}
