using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniUdemyWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class adderole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27c7c3de-4127-44d5-8f6a-96c2a11cebff", null, "Student", "STUDENT" },
                    { "42275477-f55b-4efd-8817-e1629e15996f", null, "Admin", "ADMIN" },
                    { "7236126e-d26e-4878-bed3-ca69d1b80bbc", null, "Instructor", "INSTRUCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27c7c3de-4127-44d5-8f6a-96c2a11cebff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42275477-f55b-4efd-8817-e1629e15996f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7236126e-d26e-4878-bed3-ca69d1b80bbc");
        }
    }
}
