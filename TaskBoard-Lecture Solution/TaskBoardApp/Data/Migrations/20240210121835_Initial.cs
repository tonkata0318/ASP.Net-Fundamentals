using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b82e6bc-0294-4f7e-a421-530a16acfa3b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1047bfa5-2e31-4299-8bce-3452eeddcb70", 0, "6220fbaa-6a1b-46a1-a73a-9ac2ce573588", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEFLx7JpzhVUPnOqsg9TaMwwT1Ocn6O7kY70QfZtlUALJebN061CMO6bniHVSiEBiVQ==", null, false, "d5da12da-47a8-45a3-a9e7-3b93922be4c5", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 7, 25, 14, 18, 30, 691, DateTimeKind.Local).AddTicks(5015), "1047bfa5-2e31-4299-8bce-3452eeddcb70" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 9, 10, 14, 18, 30, 691, DateTimeKind.Local).AddTicks(5051), "1047bfa5-2e31-4299-8bce-3452eeddcb70" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 1, 10, 14, 18, 30, 691, DateTimeKind.Local).AddTicks(5055), "1047bfa5-2e31-4299-8bce-3452eeddcb70" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 2, 10, 14, 18, 30, 691, DateTimeKind.Local).AddTicks(5077), "1047bfa5-2e31-4299-8bce-3452eeddcb70" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1047bfa5-2e31-4299-8bce-3452eeddcb70");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1b82e6bc-0294-4f7e-a421-530a16acfa3b", 0, "1ef82be5-310e-415d-babe-9ecf13d16ee8", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEENP2F2vxyuCpFaVqD+pQlIQYpotjTBzU/99vdj+xjGYWxntAIJsT1bhQGRDeEoqhA==", null, false, "4f0cddda-5a04-42f7-8829-e059560d3dc9", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 10, 19, 16, 34, 59, 679, DateTimeKind.Local).AddTicks(7707), "1b82e6bc-0294-4f7e-a421-530a16acfa3b" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 12, 7, 16, 34, 59, 679, DateTimeKind.Local).AddTicks(7758), "1b82e6bc-0294-4f7e-a421-530a16acfa3b" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 4, 7, 16, 34, 59, 679, DateTimeKind.Local).AddTicks(7761), "1b82e6bc-0294-4f7e-a421-530a16acfa3b" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 5, 7, 16, 34, 59, 679, DateTimeKind.Local).AddTicks(7764), "1b82e6bc-0294-4f7e-a421-530a16acfa3b" });
        }
    }
}
