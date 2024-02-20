using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "74dbefe4-d753-4650-b831-5484677dc2cc", 0, "047c7342-8805-4f8f-8334-67801065e58a", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEBLTsT12RjMO/i6fZ5CTqtP2Oepk0P0ufAEZDpb6dPavPbM9qnfxYqA+JUzFpscd9A==", null, false, "a5311177-97f1-4496-a751-141f710138cf", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 25, 14, 6, 42, 581, DateTimeKind.Local).AddTicks(3213), "Implement better styling for all public pages", "74dbefe4-d753-4650-b831-5484677dc2cc", "Improve CSS styles", null },
                    { 2, 1, new DateTime(2023, 9, 10, 14, 6, 42, 581, DateTimeKind.Local).AddTicks(3264), "Create Android client app for the TaskBoard Restfull API", "74dbefe4-d753-4650-b831-5484677dc2cc", "Android Client App", null },
                    { 3, 2, new DateTime(2024, 1, 10, 14, 6, 42, 581, DateTimeKind.Local).AddTicks(3268), "Create windows Forms dekstop app client for the TaskBoard Restfull API", "74dbefe4-d753-4650-b831-5484677dc2cc", "Dekstop Client App", null },
                    { 4, 3, new DateTime(2023, 2, 10, 14, 6, 42, 581, DateTimeKind.Local).AddTicks(3272), "Implement [Create Task] page for adding new tasks", "74dbefe4-d753-4650-b831-5484677dc2cc", "Create Tasks", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "74dbefe4-d753-4650-b831-5484677dc2cc");
        }
    }
}
