using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReportService.Api.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedDemoSignInEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "sign_in_events",
                columns: new[] { "id", "occurred_at", "user_id" },
                values: new object[,]
                {
                    { new Guid("5eed0000-0000-0000-0000-000000000001"), new DateTimeOffset(new DateTime(2026, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000002"), new DateTimeOffset(new DateTime(2026, 1, 3, 9, 7, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000003"), new DateTimeOffset(new DateTime(2026, 1, 6, 9, 14, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000004"), new DateTimeOffset(new DateTime(2026, 1, 8, 9, 21, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000005"), new DateTimeOffset(new DateTime(2026, 1, 11, 9, 28, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000006"), new DateTimeOffset(new DateTime(2026, 1, 13, 9, 35, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000007"), new DateTimeOffset(new DateTime(2026, 1, 16, 9, 42, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000008"), new DateTimeOffset(new DateTime(2026, 1, 19, 9, 49, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000009"), new DateTimeOffset(new DateTime(2026, 1, 21, 9, 56, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-00000000000a"), new DateTimeOffset(new DateTime(2026, 1, 24, 10, 3, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-00000000000b"), new DateTimeOffset(new DateTime(2026, 1, 26, 10, 10, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-00000000000c"), new DateTimeOffset(new DateTime(2026, 1, 29, 10, 17, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-00000000000d"), new DateTimeOffset(new DateTime(2026, 2, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-00000000000e"), new DateTimeOffset(new DateTime(2026, 2, 4, 9, 7, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-00000000000f"), new DateTimeOffset(new DateTime(2026, 2, 8, 9, 14, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000010"), new DateTimeOffset(new DateTime(2026, 2, 11, 9, 21, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000011"), new DateTimeOffset(new DateTime(2026, 2, 15, 9, 28, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000012"), new DateTimeOffset(new DateTime(2026, 2, 18, 9, 35, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000013"), new DateTimeOffset(new DateTime(2026, 2, 22, 9, 42, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000014"), new DateTimeOffset(new DateTime(2026, 2, 25, 9, 49, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000015"), new DateTimeOffset(new DateTime(2026, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000016"), new DateTimeOffset(new DateTime(2026, 3, 7, 9, 7, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000017"), new DateTimeOffset(new DateTime(2026, 3, 13, 9, 14, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000018"), new DateTimeOffset(new DateTime(2026, 3, 19, 9, 21, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-000000000019"), new DateTimeOffset(new DateTime(2026, 3, 25, 9, 28, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b28d0ced-8af5-4c94-8650-c7946241fd1a") },
                    { new Guid("5eed0000-0000-0000-0000-00000000001a"), new DateTimeOffset(new DateTime(2026, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-00000000001b"), new DateTimeOffset(new DateTime(2026, 1, 11, 9, 7, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-00000000001c"), new DateTimeOffset(new DateTime(2026, 1, 21, 9, 14, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-00000000001d"), new DateTimeOffset(new DateTime(2026, 2, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-00000000001e"), new DateTimeOffset(new DateTime(2026, 2, 2, 9, 7, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-00000000001f"), new DateTimeOffset(new DateTime(2026, 2, 4, 9, 14, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000020"), new DateTimeOffset(new DateTime(2026, 2, 6, 9, 21, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000021"), new DateTimeOffset(new DateTime(2026, 2, 8, 9, 28, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000022"), new DateTimeOffset(new DateTime(2026, 2, 10, 9, 35, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000023"), new DateTimeOffset(new DateTime(2026, 2, 12, 9, 42, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000024"), new DateTimeOffset(new DateTime(2026, 2, 14, 9, 49, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000025"), new DateTimeOffset(new DateTime(2026, 2, 15, 9, 56, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000026"), new DateTimeOffset(new DateTime(2026, 2, 17, 10, 3, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000027"), new DateTimeOffset(new DateTime(2026, 2, 19, 10, 10, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000028"), new DateTimeOffset(new DateTime(2026, 2, 21, 10, 17, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000029"), new DateTimeOffset(new DateTime(2026, 2, 23, 10, 24, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-00000000002a"), new DateTimeOffset(new DateTime(2026, 2, 25, 10, 31, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-00000000002b"), new DateTimeOffset(new DateTime(2026, 2, 27, 10, 38, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-00000000002c"), new DateTimeOffset(new DateTime(2026, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-00000000002d"), new DateTimeOffset(new DateTime(2026, 3, 4, 9, 7, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-00000000002e"), new DateTimeOffset(new DateTime(2026, 3, 7, 9, 14, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-00000000002f"), new DateTimeOffset(new DateTime(2026, 3, 11, 9, 21, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000030"), new DateTimeOffset(new DateTime(2026, 3, 14, 9, 28, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000031"), new DateTimeOffset(new DateTime(2026, 3, 18, 9, 35, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000032"), new DateTimeOffset(new DateTime(2026, 3, 21, 9, 42, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000033"), new DateTimeOffset(new DateTime(2026, 3, 25, 9, 49, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000034"), new DateTimeOffset(new DateTime(2026, 3, 28, 9, 56, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c") },
                    { new Guid("5eed0000-0000-0000-0000-000000000035"), new DateTimeOffset(new DateTime(2026, 1, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e2d4b6a-1c3f-4a5e-9b7d-0f2a4c6e8b1d") },
                    { new Guid("5eed0000-0000-0000-0000-000000000036"), new DateTimeOffset(new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e2d4b6a-1c3f-4a5e-9b7d-0f2a4c6e8b1d") },
                    { new Guid("5eed0000-0000-0000-0000-000000000037"), new DateTimeOffset(new DateTime(2026, 2, 28, 23, 59, 59, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e2d4b6a-1c3f-4a5e-9b7d-0f2a4c6e8b1d") },
                    { new Guid("5eed0000-0000-0000-0000-000000000038"), new DateTimeOffset(new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("8e2d4b6a-1c3f-4a5e-9b7d-0f2a4c6e8b1d") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000000a"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000000b"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000000c"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000000d"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000000e"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000000f"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000001a"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000001b"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000001c"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000001d"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000001e"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000001f"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000002a"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000002b"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000002c"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000002d"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000002e"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-00000000002f"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "sign_in_events",
                keyColumn: "id",
                keyValue: new Guid("5eed0000-0000-0000-0000-000000000038"));
        }
    }
}
