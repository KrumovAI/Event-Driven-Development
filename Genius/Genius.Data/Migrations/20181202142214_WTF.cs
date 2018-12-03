using Microsoft.EntityFrameworkCore.Migrations;

namespace Genius.Data.Migrations
{
    public partial class WTF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0d0c5700-0018-4870-8349-8d33cb4effc9", "d1120f53-c74d-49f6-b976-4d4e53317fca" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "daae6cd8-2df3-4c10-86fa-6635fb733eea", "aeb80aab-c2bb-418a-b8b9-861cfc3adeed", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "daae6cd8-2df3-4c10-86fa-6635fb733eea", "aeb80aab-c2bb-418a-b8b9-861cfc3adeed" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d0c5700-0018-4870-8349-8d33cb4effc9", "d1120f53-c74d-49f6-b976-4d4e53317fca", "Admin", "Admin" });
        }
    }
}
