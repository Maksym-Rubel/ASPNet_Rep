using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _02_Exam_Social_Network.Migrations
{
    /// <inheritdoc />
    public partial class Adw32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coments_Posts_PostId",
                table: "Coments");

            migrationBuilder.AddForeignKey(
                name: "FK_Coments_Posts_PostId",
                table: "Coments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coments_Posts_PostId",
                table: "Coments");

            migrationBuilder.AddForeignKey(
                name: "FK_Coments_Posts_PostId",
                table: "Coments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
