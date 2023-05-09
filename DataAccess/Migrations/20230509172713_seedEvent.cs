using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ad2b7c1-bd8d-4b7f-baa0-9ff35d01093a", "AQAAAAEAACcQAAAAEItgAcmnnSUobY5VzpUdvt4evJm07ACKn6C4AUp9v0odWisB2f3syTkIkWr9GTt7MA==", "d692f0fd-b95c-470e-beba-cef9d819d903" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88c0f46b-8ed0-4dfc-b707-6da20e0ef79d", "AQAAAAEAACcQAAAAEKY7mtzwVMzX1HLTiFOsczpA7IPLr9Exx1i2geCf7vQnEB4scDwdeuJ7vsKvufmx6w==", "bbd9126b-c0db-493b-a437-b194a44dd47f" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EvenetID", "CategoryID", "CityID", "DateTime", "Description", "Id", "IsConfirmed", "LeftTickets", "Name", "Quoto" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5", true, 100, "Belediye Konseri", 100 },
                    { 2, 2, 1, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5", true, 100, "Açık Hava Tiyatrosu", 100 },
                    { 3, 2, 5, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiyatro Akademi - HBV", "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5", true, 100, "Gergadanlar Oyunu", 100 },
                    { 4, 2, 2, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiyatro Akademi - HBV", "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5", true, 100, "Gergadanlar Oyunu", 100 },
                    { 5, 2, 2, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiyatro Akademi - HBV", "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5", false, 100, "Gergadanlar Oyunu", 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EvenetID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EvenetID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EvenetID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EvenetID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EvenetID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd59d5a8-0121-4f9d-9375-b8fbf22169da", "AQAAAAEAACcQAAAAEJ6ZAZmP8ODjCGTjfj2jZeh8l1cXzSHe7iHPhDkCn+XejmeIV2MwWOtJMZrxo7iyvA==", "628cedb4-1557-448a-a6de-f23c2b7cd523" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efd73a78-b32d-4e3f-ab0c-e2d7e13e220b", "AQAAAAEAACcQAAAAEALMFH2cxDDgqCl2uPpoClirKC+Tzx4IDS2vrgCpsHBWpMTUloWPn315oxSlZ5Pejg==", "470352b1-d805-4764-9425-93ac07838b6d" });
        }
    }
}
