using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _02_Exam_Social_Network.Migrations
{
    /// <inheritdoc />
    public partial class AddNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coments",
                columns: new[] { "Id", "Message", "PostId", "UserId" },
                values: new object[] { 2, "my first post", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coments",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
