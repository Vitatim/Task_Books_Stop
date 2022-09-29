using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books_Spot_Task.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingCode = table.Column<Guid>(type: "uuid", nullable: false),
                    LibraryCardId = table.Column<string>(type: "text", nullable: false),
                    IsbnCode = table.Column<string>(type: "text", nullable: false),
                    DateBorrowed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateReserved = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateReturned = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingCode);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    IsbnCode = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    AuthorName = table.Column<string>(type: "text", nullable: false),
                    Publisher = table.Column<string>(type: "text", nullable: false),
                    PublishingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false),
                    BookStatus = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.IsbnCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
