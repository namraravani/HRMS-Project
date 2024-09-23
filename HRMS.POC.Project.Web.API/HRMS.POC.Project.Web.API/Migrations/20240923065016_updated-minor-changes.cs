using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.POC.Project.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class updatedminorchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71907976-3054-462f-aa63-30c9bda8af1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfffce75-6477-4322-b269-dc88e18522ea");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "81cebf58-ac38-4615-8a3b-fe08eb20cc04", "bf72dd7c-665c-4c06-bd94-ad2e044e1ca6" });

            migrationBuilder.DeleteData(
                table: "OrganizationUsers",
                keyColumns: new[] { "OrganizationId", "UserId" },
                keyValues: new object[] { "d70c21e8-5ce0-475a-9a01-9cfe417174d3", "bf72dd7c-665c-4c06-bd94-ad2e044e1ca6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81cebf58-ac38-4615-8a3b-fe08eb20cc04");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf72dd7c-665c-4c06-bd94-ad2e044e1ca6");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: "d70c21e8-5ce0-475a-9a01-9cfe417174d3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09a84e5b-0e2d-4a3a-ba96-038c9e36cb35", null, "HR", "HR" },
                    { "b4d877b8-e111-44ee-b743-18106516161b", null, "Admin", "ADMIN" },
                    { "d0d866e9-db05-4da8-964a-c8797d12e22c", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_by", "Email", "EmailConfirmed", "Is_Delete", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46d0dbae-5c91-4ada-adad-fee90612038d", 0, "7a2122fc-8144-4027-b46c-f42b52606717", "46d0dbae-5c91-4ada-adad-fee90612038d", "namraravani8@gmail.com", false, false, false, null, null, null, "449ED546C921FE530F94E99FBF7EF1C437E5B066940AB606C345576C0457332A", "9427662325", false, "65337ff9-21d0-45d6-8723-52e2f9c0abb7", false, "Namra" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "address", "orgName" },
                values: new object[] { "abaf098e-da6e-4c4d-9439-b32e0b191567", "Gandhinagar", "Evision" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b4d877b8-e111-44ee-b743-18106516161b", "46d0dbae-5c91-4ada-adad-fee90612038d" });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "OrganizationId", "UserId" },
                values: new object[] { "abaf098e-da6e-4c4d-9439-b32e0b191567", "46d0dbae-5c91-4ada-adad-fee90612038d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09a84e5b-0e2d-4a3a-ba96-038c9e36cb35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0d866e9-db05-4da8-964a-c8797d12e22c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b4d877b8-e111-44ee-b743-18106516161b", "46d0dbae-5c91-4ada-adad-fee90612038d" });

            migrationBuilder.DeleteData(
                table: "OrganizationUsers",
                keyColumns: new[] { "OrganizationId", "UserId" },
                keyValues: new object[] { "abaf098e-da6e-4c4d-9439-b32e0b191567", "46d0dbae-5c91-4ada-adad-fee90612038d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4d877b8-e111-44ee-b743-18106516161b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46d0dbae-5c91-4ada-adad-fee90612038d");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: "abaf098e-da6e-4c4d-9439-b32e0b191567");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71907976-3054-462f-aa63-30c9bda8af1f", null, "HR", "HR" },
                    { "81cebf58-ac38-4615-8a3b-fe08eb20cc04", null, "Admin", "ADMIN" },
                    { "bfffce75-6477-4322-b269-dc88e18522ea", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_by", "Email", "EmailConfirmed", "Is_Delete", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bf72dd7c-665c-4c06-bd94-ad2e044e1ca6", 0, "6a435438-7f5c-4358-bd94-de42a8372bf4", "bf72dd7c-665c-4c06-bd94-ad2e044e1ca6", "namraravani8@gmail.com", false, true, false, null, null, null, "449ED546C921FE530F94E99FBF7EF1C437E5B066940AB606C345576C0457332A", "9427662325", false, "43735e77-e5de-411e-b0c7-8d600bfad5ec", false, "Namra" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "address", "orgName" },
                values: new object[] { "d70c21e8-5ce0-475a-9a01-9cfe417174d3", "Gandhinagar", "Evision" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "81cebf58-ac38-4615-8a3b-fe08eb20cc04", "bf72dd7c-665c-4c06-bd94-ad2e044e1ca6" });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "OrganizationId", "UserId" },
                values: new object[] { "d70c21e8-5ce0-475a-9a01-9cfe417174d3", "bf72dd7c-665c-4c06-bd94-ad2e044e1ca6" });
        }
    }
}
