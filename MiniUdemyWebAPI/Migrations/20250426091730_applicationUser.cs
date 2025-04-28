using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniUdemyWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class applicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19312e55-c082-43fb-96f5-589cc5975f77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1e15b79-262f-4563-9d6f-e605ac0156a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7646ced-8421-4922-8051-07802b15486e");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "085db52f-832b-4ce1-944e-edb15c9522ef", null, "Instructor", "INSTRUCTOR" },
                    { "7a2c51de-bb4a-48e0-adf7-246bfadd6352", null, "Admin", "ADMIN" },
                    { "eb4cae1d-4e5b-4e7f-9d01-1929df44bbd9", null, "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "085db52f-832b-4ce1-944e-edb15c9522ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a2c51de-bb4a-48e0-adf7-246bfadd6352");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb4cae1d-4e5b-4e7f-9d01-1929df44bbd9");

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
                    { "19312e55-c082-43fb-96f5-589cc5975f77", null, "Admin", "ADMIN" },
                    { "d1e15b79-262f-4563-9d6f-e605ac0156a5", null, "Instructor", "INSTRUCTOR" },
                    { "f7646ced-8421-4922-8051-07802b15486e", null, "Student", "STUDENT" }
                });
        }
    }
}
