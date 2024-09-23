using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.POC.Project.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class updatedseedvalueofapplicationuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d87d319-7a8f-4110-a399-5a57525fb11c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d7bec7d-6425-4210-9269-de92b8515ab9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "63c5c376-65e9-4465-a0d9-c38766b27a19", "61cb7f15-a37d-4672-b3a1-21b640fc98d5" });

            migrationBuilder.DeleteData(
                table: "OrganizationUsers",
                keyColumns: new[] { "OrganizationId", "UserId" },
                keyValues: new object[] { "dd6f42a2-afeb-4ac8-9881-701c0ba08966", "61cb7f15-a37d-4672-b3a1-21b640fc98d5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63c5c376-65e9-4465-a0d9-c38766b27a19");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61cb7f15-a37d-4672-b3a1-21b640fc98d5");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: "dd6f42a2-afeb-4ac8-9881-701c0ba08966");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1d87d319-7a8f-4110-a399-5a57525fb11c", null, "Employee", "EMPLOYEE" },
                    { "3d7bec7d-6425-4210-9269-de92b8515ab9", null, "HR", "HR" },
                    { "63c5c376-65e9-4465-a0d9-c38766b27a19", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "61cb7f15-a37d-4672-b3a1-21b640fc98d5", 0, "a4f2cce3-b47d-43a7-88e4-82afcfd23684", "IdentityUser", "namraravani8@gmail.com", false, false, null, null, null, "449ED546C921FE530F94E99FBF7EF1C437E5B066940AB606C345576C0457332A", null, false, "9a273e48-5141-499f-93f8-429d239fa665", false, "Namra" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "address", "orgName" },
                values: new object[] { "dd6f42a2-afeb-4ac8-9881-701c0ba08966", "Gandhinagar", "Evision" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "63c5c376-65e9-4465-a0d9-c38766b27a19", "61cb7f15-a37d-4672-b3a1-21b640fc98d5" });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "OrganizationId", "UserId" },
                values: new object[] { "dd6f42a2-afeb-4ac8-9881-701c0ba08966", "61cb7f15-a37d-4672-b3a1-21b640fc98d5" });
        }
    }
}
