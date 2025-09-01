using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _02_Exam_Social_Network.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNL-OXfUdlkKCgDFYV9WXavaJucZsprpGiTA&s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://randomuser.me/api/portraits/men/32.jpg");
        }
    }
}
