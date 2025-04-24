using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniUdemyWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54572e6a-2a6d-424f-9d6c-4f4613276e7c", null, "Admin", "ADMIN" },
                    { "a8ba9b0c-31f5-489a-a318-146f0ca3f521", null, "Student", "STUDENT" },
                    { "c82b1129-5b88-4232-9fcc-559717bb5b60", null, "Instructor", "INSTRUCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54572e6a-2a6d-424f-9d6c-4f4613276e7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8ba9b0c-31f5-489a-a318-146f0ca3f521");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c82b1129-5b88-4232-9fcc-559717bb5b60");

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
    }
}
