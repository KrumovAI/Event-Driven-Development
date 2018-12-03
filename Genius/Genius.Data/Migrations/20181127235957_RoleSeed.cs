using Microsoft.EntityFrameworkCore.Migrations;

namespace Genius.Data.Migrations
{
    public partial class RoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d17ad35-9934-4488-85c2-9a6621858cfa", "b5f0d2e4-4a7a-4771-a47a-17f516b808c7", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5d17ad35-9934-4488-85c2-9a6621858cfa", "b5f0d2e4-4a7a-4771-a47a-17f516b808c7" });
        }
    }
}
