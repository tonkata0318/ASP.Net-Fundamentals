using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class CreatedTables : Migration
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
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[] { "1b82e6bc-0294-4f7e-a421-530a16acfa3b", 0, "1ef82be5-310e-415d-babe-9ecf13d16ee8", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEENP2F2vxyuCpFaVqD+pQlIQYpotjTBzU/99vdj+xjGYWxntAIJsT1bhQGRDeEoqhA==", null, false, "4f0cddda-5a04-42f7-8829-e059560d3dc9", false, "test@softuni.bg" });

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
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 19, 16, 34, 59, 679, DateTimeKind.Local).AddTicks(7707), "Implement better styling for all public pages", "1b82e6bc-0294-4f7e-a421-530a16acfa3b", "Improve CSS styles" },
                    { 2, 1, new DateTime(2022, 12, 7, 16, 34, 59, 679, DateTimeKind.Local).AddTicks(7758), "Create Android client app for the TaskBoard RESTful API", "1b82e6bc-0294-4f7e-a421-530a16acfa3b", "Android Client App" },
                    { 3, 2, new DateTime(2023, 4, 7, 16, 34, 59, 679, DateTimeKind.Local).AddTicks(7761), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "1b82e6bc-0294-4f7e-a421-530a16acfa3b", "Desktop Client App" },
                    { 4, 3, new DateTime(2022, 5, 7, 16, 34, 59, 679, DateTimeKind.Local).AddTicks(7764), "Implement [Create Task] page for adding new tasks", "1b82e6bc-0294-4f7e-a421-530a16acfa3b", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
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
                keyValue: "1b82e6bc-0294-4f7e-a421-530a16acfa3b");
        }
    }
}
