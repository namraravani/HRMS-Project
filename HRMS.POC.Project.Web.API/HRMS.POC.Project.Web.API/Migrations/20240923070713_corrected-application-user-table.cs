using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.POC.Project.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class correctedapplicationusertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "38e39805-b6ef-442f-9c69-67b534c8fd8b", null, "Employee", "EMPLOYEE" },
                    { "54a5a166-9580-4638-9eb1-733d57440301", null, "HR", "HR" },
                    { "fb9936db-8096-45a8-9b1f-cee7a60f58a3", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_by", "Email", "EmailConfirmed", "Is_Delete", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0ac42624-4d86-4b1d-8104-2044e43e3461", 0, "58750e58-3d73-4916-ba21-dc4c11d017d3", "0ac42624-4d86-4b1d-8104-2044e43e3461", "namraravani8@gmail.com", false, false, false, null, null, null, "449ED546C921FE530F94E99FBF7EF1C437E5B066940AB606C345576C0457332A", "9427662325", false, "7ee76163-83a9-4d0d-8af5-2b1f36440e90", false, "Namra" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "address", "orgName" },
                values: new object[] { "67316ae2-f4ea-41b6-926b-0f21dfe7ccdc", "Gandhinagar", "Evision" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fb9936db-8096-45a8-9b1f-cee7a60f58a3", "0ac42624-4d86-4b1d-8104-2044e43e3461" });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "OrganizationId", "UserId" },
                values: new object[] { "67316ae2-f4ea-41b6-926b-0f21dfe7ccdc", "0ac42624-4d86-4b1d-8104-2044e43e3461" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38e39805-b6ef-442f-9c69-67b534c8fd8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54a5a166-9580-4638-9eb1-733d57440301");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fb9936db-8096-45a8-9b1f-cee7a60f58a3", "0ac42624-4d86-4b1d-8104-2044e43e3461" });

            migrationBuilder.DeleteData(
                table: "OrganizationUsers",
                keyColumns: new[] { "OrganizationId", "UserId" },
                keyValues: new object[] { "67316ae2-f4ea-41b6-926b-0f21dfe7ccdc", "0ac42624-4d86-4b1d-8104-2044e43e3461" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb9936db-8096-45a8-9b1f-cee7a60f58a3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0ac42624-4d86-4b1d-8104-2044e43e3461");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: "67316ae2-f4ea-41b6-926b-0f21dfe7ccdc");

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
    }
}
