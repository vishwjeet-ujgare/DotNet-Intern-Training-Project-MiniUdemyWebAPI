using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniUdemyWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedsomecoursecategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CourseCategories",
                newName: "CourseCategoryId");

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "CourseCategoryId", "CategoryName", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Programming", null },
                    { 2, "Data Science", null },
                    { 3, "Web Development", null },
                    { 4, "Mobile Development", null },
                    { 5, "Game Development", null },
                    { 6, "Cloud Computing", null },
                    { 7, "Cyber Security", null },
                    { 8, "Artificial Intelligence", null },
                    { 9, "Machine Learning", null },
                    { 10, "Blockchain", null },
                    { 11, "Data Analysis", null },
                    { 12, "Digital Marketing", null },
                    { 13, "Graphic Design", null },
                    { 14, "UI/UX Design", null },
                    { 15, "Web Design", 3 },
                    { 16, "Web Development", 3 },
                    { 17, "Mobile App Development", 4 },
                    { 18, "Game Design", 5 },
                    { 19, "Game Development", 5 },
                    { 20, "Cloud Security", 7 },
                    { 21, "Cloud Development", 6 },
                    { 22, "Data Visualization", 11 },
                    { 23, "Data Engineering", 2 },
                    { 24, "Java", 1 },
                    { 25, "C#", 1 },
                    { 26, "C++", 1 },
                    { 27, "JavaScript", 1 },
                    { 28, "Python", 1 },
                    { 29, "PHP", 1 },
                    { 30, "Ruby", 1 },
                    { 31, "Swift", 1 },
                    { 32, "Kotlin", 1 },
                    { 33, ".NET", 1 },
                    { 34, "ASP.NET", 1 },
                    { 35, "Django", 1 },
                    { 36, "Flask", 1 },
                    { 37, "Node.js", 1 },
                    { 38, "React.js", 1 },
                    { 39, "Angular", 1 },
                    { 40, "Vue.js", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "CourseCategoryId",
                keyValue: 11);

            migrationBuilder.RenameColumn(
                name: "CourseCategoryId",
                table: "CourseCategories",
                newName: "CategoryId");
        }
    }
}
