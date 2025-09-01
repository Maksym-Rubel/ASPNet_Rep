using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _02_Exam_Social_Network.Migrations
{
    /// <inheritdoc />
    public partial class AddComents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Coments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Coments",
                columns: new[] { "Id", "Message", "PostId", "UserId" },
                values: new object[] { 1, "Hello maxyyy42", 1, 3 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "");

            migrationBuilder.CreateIndex(
                name: "IX_Coments_PostId",
                table: "Coments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Coments_UserId",
                table: "Coments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coments");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Posts");
        }
    }
}
