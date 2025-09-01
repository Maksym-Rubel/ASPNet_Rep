using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _02_Exam_Social_Network.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImgUrl", "NickName" },
                values: new object[] { "https://randomuser.me/api/portraits/men/32.jpg", "maxyyy42" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImgUrl", "NickName" },
                values: new object[] { "https://randomuser.me/api/portraits/men/14.jpg", "igor21" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImgUrl", "NickName" },
                values: new object[] { "https://randomuser.me/api/portraits/men/45.jpg", "denys88" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImgUrl", "NickName" },
                values: new object[] { "https://randomuser.me/api/portraits/men/52.jpg", "petya09" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImgUrl", "NickName" },
                values: new object[] { "https://randomuser.me/api/portraits/women/21.jpg", "vika_sun" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImgUrl", "NickName" },
                values: new object[] { "https://randomuser.me/api/portraits/women/35.jpg", "katya_star" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "Users");
        }
    }
}
