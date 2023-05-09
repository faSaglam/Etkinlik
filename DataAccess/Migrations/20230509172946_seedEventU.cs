using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedEventU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EvenetID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dc5ce32-8101-4fc7-8bb1-35d76ca0aaa6", "AQAAAAEAACcQAAAAEHqsFq6NHHHsNJdQNrkL3P5+7ZyGyEuOoy52NPLKg9vjPdSWcdpsxi1lMZN+qsehfQ==", "e32dcc62-aa8f-44a4-b633-d59c137993c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "670c0396-33af-4d61-b2a4-72cfc3bffbbd", "AQAAAAEAACcQAAAAEFy4JNU+kU7cty7gAedD2gRiLGirET+dR2rq0L/WQCm8HJt2AMiJnh7GND9DYiQjrw==", "d4745356-46f1-4a59-9a48-06721cf7bf4b" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EvenetID",
                keyValue: 4,
                columns: new[] { "IsConfirmed", "Name" },
                values: new object[] { false, "Fizikçiler Oyunu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EvenetID",
                keyValue: 4,
                columns: new[] { "IsConfirmed", "Name" },
                values: new object[] { true, "Gergadanlar Oyunu" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EvenetID", "CategoryID", "CityID", "DateTime", "Description", "Id", "IsConfirmed", "LeftTickets", "Name", "Quoto" },
                values: new object[] { 5, 2, 2, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiyatro Akademi - HBV", "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5", false, 100, "Gergadanlar Oyunu", 100 });
        }
    }
}
