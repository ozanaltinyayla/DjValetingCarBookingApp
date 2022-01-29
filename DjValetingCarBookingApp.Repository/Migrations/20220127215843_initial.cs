using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DjValetingCarBookingApp.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Flexibility = table.Column<int>(type: "int", nullable: false),
                    VehicleSize = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingInfos_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ContactNumber", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "5559998877", "linustorvalds@gmail.com", "Linus Torvalds" },
                    { 2, "3337775544", "adalovelace@gmail.com", "Ada Lovelace" },
                    { 3, "6668889955", "alanturing@gmail.com", "Alan Turing" },
                    { 4, "7779005544", "kenthompson@gmail.com", "Ken Thompson" },
                    { 5, "1116667799", "dennisritchie@gmail.com", "Dennis Ritchie" }
                });

            migrationBuilder.InsertData(
                table: "BookingInfos",
                columns: new[] { "Id", "BookingDate", "CustomerId", "Flexibility", "VehicleSize" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 28, 0, 58, 42, 604, DateTimeKind.Local).AddTicks(145), 1, 1, 3 },
                    { 2, new DateTime(2022, 1, 29, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2107), 1, 2, 2 },
                    { 3, new DateTime(2022, 1, 31, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2214), 1, 3, 1 },
                    { 4, new DateTime(2022, 2, 1, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2218), 2, 1, 2 },
                    { 5, new DateTime(2022, 2, 2, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2220), 2, 2, 1 },
                    { 6, new DateTime(2022, 2, 3, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2221), 2, 3, 3 },
                    { 7, new DateTime(2022, 1, 31, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2223), 3, 1, 4 },
                    { 8, new DateTime(2022, 2, 4, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2225), 3, 2, 3 },
                    { 9, new DateTime(2022, 2, 11, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2226), 3, 3, 2 },
                    { 10, new DateTime(2022, 2, 8, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2227), 4, 1, 4 },
                    { 11, new DateTime(2022, 2, 9, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2229), 4, 2, 1 },
                    { 12, new DateTime(2022, 2, 12, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2231), 4, 3, 3 },
                    { 13, new DateTime(2022, 2, 18, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2232), 5, 1, 1 },
                    { 14, new DateTime(2022, 2, 21, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2234), 5, 2, 2 },
                    { 15, new DateTime(2022, 2, 22, 0, 58, 42, 609, DateTimeKind.Local).AddTicks(2235), 5, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingInfos_CustomerId",
                table: "BookingInfos",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingInfos");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
