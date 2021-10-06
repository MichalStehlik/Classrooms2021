using Microsoft.EntityFrameworkCore.Migrations;

namespace Classrooms2021.Migrations
{
    public partial class NewStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassroomId", "Firstname", "Lastname", "ShoeSize" },
                values: new object[] { 1, 1, "Adam", "Antl", 42 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassroomId", "Firstname", "Lastname", "ShoeSize" },
                values: new object[] { 2, 1, "Břetislav", "Bohatý", 40 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
