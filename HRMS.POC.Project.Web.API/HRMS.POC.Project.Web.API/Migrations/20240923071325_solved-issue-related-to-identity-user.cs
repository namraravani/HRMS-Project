using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.POC.Project.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class solvedissuerelatedtoidentityuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "Is_Delete",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a8e6daa-5413-4826-96df-23f845dcbd3e", null, "HR", "HR" },
                    { "82c139eb-db59-4208-99f4-0f4a7d6c20d8", null, "Admin", "ADMIN" },
                    { "8324c5fb-b6f9-419b-b271-fd489613053c", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_by", "Discriminator", "Email", "EmailConfirmed", "Is_Delete", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "90b33f58-22d6-4665-81a5-a58c73399a75", 0, "f9b27d3a-57b8-4f9c-b2da-a72996243ddd", "90b33f58-22d6-4665-81a5-a58c73399a75", "ApplicationUser", "namraravani8@gmail.com", false, false, false, null, null, null, "449ED546C921FE530F94E99FBF7EF1C437E5B066940AB606C345576C0457332A", "9427662325", false, "9d8f418a-30fe-442a-82d8-3a890ddccfe2", false, "Namra" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "address", "orgName" },
                values: new object[] { "78b76779-a40c-4686-bf24-50cefd944e85", "Gandhinagar", "Evision" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "82c139eb-db59-4208-99f4-0f4a7d6c20d8", "90b33f58-22d6-4665-81a5-a58c73399a75" });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "OrganizationId", "UserId" },
                values: new object[] { "78b76779-a40c-4686-bf24-50cefd944e85", "90b33f58-22d6-4665-81a5-a58c73399a75" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a8e6daa-5413-4826-96df-23f845dcbd3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8324c5fb-b6f9-419b-b271-fd489613053c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "82c139eb-db59-4208-99f4-0f4a7d6c20d8", "90b33f58-22d6-4665-81a5-a58c73399a75" });

            migrationBuilder.DeleteData(
                table: "OrganizationUsers",
                keyColumns: new[] { "OrganizationId", "UserId" },
                keyValues: new object[] { "78b76779-a40c-4686-bf24-50cefd944e85", "90b33f58-22d6-4665-81a5-a58c73399a75" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82c139eb-db59-4208-99f4-0f4a7d6c20d8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90b33f58-22d6-4665-81a5-a58c73399a75");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: "78b76779-a40c-4686-bf24-50cefd944e85");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<bool>(
                name: "Is_Delete",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
