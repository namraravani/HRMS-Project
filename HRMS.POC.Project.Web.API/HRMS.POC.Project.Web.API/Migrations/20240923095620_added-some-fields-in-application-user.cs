using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.POC.Project.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class addedsomefieldsinapplicationuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50489e6e-7fad-42ac-8e3f-02c4d3eed296", null, "HR", "HR" },
                    { "be96181c-bace-451c-8fe7-e51640978123", null, "Admin", "ADMIN" },
                    { "e2111fea-3848-4670-944c-57a7b37e114a", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_by", "Discriminator", "Email", "EmailConfirmed", "Is_Delete", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "firstName", "lastName" },
                values: new object[] { "41cd4958-fc67-476d-8788-ecbde93b1d77", 0, "8e9a9fad-4c92-466b-953e-01f521a158e3", "41cd4958-fc67-476d-8788-ecbde93b1d77", "ApplicationUser", "namraravani8@gmail.com", false, false, false, null, null, null, "449ED546C921FE530F94E99FBF7EF1C437E5B066940AB606C345576C0457332A", "9427662325", false, "d1a37d73-9a49-4cbe-8c03-05232b1187f9", false, "Namra", "Namra", "Ravani" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "address", "orgName" },
                values: new object[] { "9a2a9e69-0096-41d7-b117-212e20dbfe36", "Gandhinagar", "Evision" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "be96181c-bace-451c-8fe7-e51640978123", "41cd4958-fc67-476d-8788-ecbde93b1d77" });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "OrganizationId", "UserId" },
                values: new object[] { "9a2a9e69-0096-41d7-b117-212e20dbfe36", "41cd4958-fc67-476d-8788-ecbde93b1d77" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50489e6e-7fad-42ac-8e3f-02c4d3eed296");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2111fea-3848-4670-944c-57a7b37e114a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be96181c-bace-451c-8fe7-e51640978123", "41cd4958-fc67-476d-8788-ecbde93b1d77" });

            migrationBuilder.DeleteData(
                table: "OrganizationUsers",
                keyColumns: new[] { "OrganizationId", "UserId" },
                keyValues: new object[] { "9a2a9e69-0096-41d7-b117-212e20dbfe36", "41cd4958-fc67-476d-8788-ecbde93b1d77" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be96181c-bace-451c-8fe7-e51640978123");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41cd4958-fc67-476d-8788-ecbde93b1d77");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: "9a2a9e69-0096-41d7-b117-212e20dbfe36");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "AspNetUsers");

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
    }
}
