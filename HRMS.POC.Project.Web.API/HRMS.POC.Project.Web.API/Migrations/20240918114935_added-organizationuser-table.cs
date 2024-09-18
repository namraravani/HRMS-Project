using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.POC.Project.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class addedorganizationusertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "OrgName",
                table: "Organizations",
                newName: "orgName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Organizations",
                newName: "address");

            migrationBuilder.CreateTable(
                name: "OrganizationUsers",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationUsers", x => new { x.OrganizationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_OrganizationUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationUsers_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11ae0e50-89c8-46bc-9e4f-22632e5bb907", "2", "HR", "HR" },
                    { "626fbefa-6c22-43cd-8465-5efa23935a93", "3", "Employee", "Employee" },
                    { "a87f80e8-74d8-487a-9ae7-049ef5acb799", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUsers_UserId",
                table: "OrganizationUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11ae0e50-89c8-46bc-9e4f-22632e5bb907");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626fbefa-6c22-43cd-8465-5efa23935a93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a87f80e8-74d8-487a-9ae7-049ef5acb799");

            migrationBuilder.RenameColumn(
                name: "orgName",
                table: "Organizations",
                newName: "OrgName");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Organizations",
                newName: "Address");

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
    }
}
