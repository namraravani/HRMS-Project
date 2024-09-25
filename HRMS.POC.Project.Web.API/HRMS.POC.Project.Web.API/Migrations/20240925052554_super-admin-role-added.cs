using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.POC.Project.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class superadminroleadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "281eb592-4f1c-4db3-921f-257a40ace0af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5272eadd-6cc3-4efd-8437-2e3836a51757");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3d801102-de21-4045-b41c-8d7cef6c5d50", "5f80b4bb-067e-44c2-94b4-6a3ebde1199c" });

            migrationBuilder.DeleteData(
                table: "OrganizationUsers",
                keyColumns: new[] { "OrganizationId", "UserId" },
                keyValues: new object[] { "258dee23-8e9d-426c-8111-8c1c4c8ace7a", "5f80b4bb-067e-44c2-94b4-6a3ebde1199c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d801102-de21-4045-b41c-8d7cef6c5d50");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f80b4bb-067e-44c2-94b4-6a3ebde1199c");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: "258dee23-8e9d-426c-8111-8c1c4c8ace7a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "359557c0-ef90-4e28-8be4-62c9b0d4230a", null, "Admin", "ADMIN" },
                    { "6c629aa2-0cfa-4a40-a8b7-a5a0cdfcbde2", null, "Employee", "EMPLOYEE" },
                    { "9d4e0c58-e688-4827-9f68-1483c00f4877", null, "HR", "HR" },
                    { "a3313cd3-2c4f-4fa4-8629-b0822e8b78e9", null, "SuperAdmin", "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_by", "Email", "EmailConfirmed", "Is_Delete", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "firstName", "lastName" },
                values: new object[] { "a13a24ac-81ab-4ee0-ba5d-dc930d913819", 0, "8960edd2-c74a-4f69-b27a-9586e97def59", "a13a24ac-81ab-4ee0-ba5d-dc930d913819", "namraravani8@gmail.com", false, false, false, null, null, null, "449ED546C921FE530F94E99FBF7EF1C437E5B066940AB606C345576C0457332A", "9427662325", false, "37619a3d-84a9-47f8-ade9-105165586862", false, "Namra", "Namra", "Ravani" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "address", "orgName" },
                values: new object[] { "0fd9682d-ed60-4cad-bb3f-60e8d223ca4d", "Gandhinagar", "Evision" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a3313cd3-2c4f-4fa4-8629-b0822e8b78e9", "a13a24ac-81ab-4ee0-ba5d-dc930d913819" });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "OrganizationId", "UserId" },
                values: new object[] { "0fd9682d-ed60-4cad-bb3f-60e8d223ca4d", "a13a24ac-81ab-4ee0-ba5d-dc930d913819" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "359557c0-ef90-4e28-8be4-62c9b0d4230a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c629aa2-0cfa-4a40-a8b7-a5a0cdfcbde2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d4e0c58-e688-4827-9f68-1483c00f4877");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3313cd3-2c4f-4fa4-8629-b0822e8b78e9", "a13a24ac-81ab-4ee0-ba5d-dc930d913819" });

            migrationBuilder.DeleteData(
                table: "OrganizationUsers",
                keyColumns: new[] { "OrganizationId", "UserId" },
                keyValues: new object[] { "0fd9682d-ed60-4cad-bb3f-60e8d223ca4d", "a13a24ac-81ab-4ee0-ba5d-dc930d913819" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3313cd3-2c4f-4fa4-8629-b0822e8b78e9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a13a24ac-81ab-4ee0-ba5d-dc930d913819");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: "0fd9682d-ed60-4cad-bb3f-60e8d223ca4d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "281eb592-4f1c-4db3-921f-257a40ace0af", null, "Employee", "EMPLOYEE" },
                    { "3d801102-de21-4045-b41c-8d7cef6c5d50", null, "Admin", "ADMIN" },
                    { "5272eadd-6cc3-4efd-8437-2e3836a51757", null, "HR", "HR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_by", "Email", "EmailConfirmed", "Is_Delete", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "firstName", "lastName" },
                values: new object[] { "5f80b4bb-067e-44c2-94b4-6a3ebde1199c", 0, "04e0ea3d-f307-4ef2-8fcf-8ec7bb66a9d6", "5f80b4bb-067e-44c2-94b4-6a3ebde1199c", "namraravani8@gmail.com", false, false, false, null, null, null, "449ED546C921FE530F94E99FBF7EF1C437E5B066940AB606C345576C0457332A", "9427662325", false, "1d0ff8e0-0a7e-4bad-ba0a-a87a287012b6", false, "Namra", "Namra", "Ravani" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "address", "orgName" },
                values: new object[] { "258dee23-8e9d-426c-8111-8c1c4c8ace7a", "Gandhinagar", "Evision" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3d801102-de21-4045-b41c-8d7cef6c5d50", "5f80b4bb-067e-44c2-94b4-6a3ebde1199c" });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "OrganizationId", "UserId" },
                values: new object[] { "258dee23-8e9d-426c-8111-8c1c4c8ace7a", "5f80b4bb-067e-44c2-94b4-6a3ebde1199c" });
        }
    }
}
