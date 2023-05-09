using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd59d5a8-0121-4f9d-9375-b8fbf22169da", "AQAAAAEAACcQAAAAEJ6ZAZmP8ODjCGTjfj2jZeh8l1cXzSHe7iHPhDkCn+XejmeIV2MwWOtJMZrxo7iyvA==", "628cedb4-1557-448a-a6de-f23c2b7cd523" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5", 0, "efd73a78-b32d-4e3f-ab0c-e2d7e13e220b", "testuser@testuser.com", false, "Test", "User", false, null, "TESTUSER@TESTUSER.COM", "TESTUSER@TESTUSER.COM", "AQAAAAEAACcQAAAAEALMFH2cxDDgqCl2uPpoClirKC+Tzx4IDS2vrgCpsHBWpMTUloWPn315oxSlZ5Pejg==", null, false, "470352b1-d805-4764-9425-93ac07838b6d", false, "testuser@testuser.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfdc4a1a-2ea3-4f31-b1e3-034e8da835a5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d020305-cf0f-4065-95c1-c75af46a7e00", "AQAAAAEAACcQAAAAEPMcyELd6GGjcguDv6iVXYId/y9yvUDN70Fz8u9G1K7eaA86fBls+GK4yhBVuVmYGQ==", "717a5193-be45-496a-bff1-32228151cc81" });
        }
    }
}
