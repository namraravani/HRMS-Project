using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.POC.Project.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class changedcreatedbyfieldmakingitnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Is_Delete",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Is_Delete",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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
    }
}
