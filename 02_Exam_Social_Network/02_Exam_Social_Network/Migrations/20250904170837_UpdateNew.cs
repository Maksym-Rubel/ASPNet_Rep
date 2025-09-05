using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _02_Exam_Social_Network.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Location", "UserId" },
                values: new object[] { 1, "", 1 });

            migrationBuilder.InsertData(
                table: "Coments",
                columns: new[] { "Id", "Message", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Hello maxyyy42", 1, 3 },
                    { 2, "my first post", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "PostImages",
                columns: new[] { "Id", "PostId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSFkYcWvynkUjRz8ME31vQoP2dyJXzLYObCQA&s" },
                    { 2, 1, "https://i.guim.co.uk/img/media/87929f76cb1cbd05350d5a7b8fe759857a2e7e78/388_698_3299_1979/master/3299.jpg?width=1200&quality=85&auto=format&fit=max&s=2e1386e2df9c479f2fe3061bed3ac6eb" }
                });
        }
    }
}
