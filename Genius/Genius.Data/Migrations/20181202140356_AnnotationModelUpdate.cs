using Microsoft.EntityFrameworkCore.Migrations;

namespace Genius.Data.Migrations
{
    public partial class AnnotationModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_AspNetUsers_AuthorId",
                table: "Annotations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5d17ad35-9934-4488-85c2-9a6621858cfa", "b5f0d2e4-4a7a-4771-a47a-17f516b808c7" });

            migrationBuilder.DropColumn(
                name: "EndIndex",
                table: "Annotations");

            migrationBuilder.DropColumn(
                name: "StartIndex",
                table: "Annotations");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Annotations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Annotations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Annotations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d0c5700-0018-4870-8349-8d33cb4effc9", "d1120f53-c74d-49f6-b976-4d4e53317fca", "Admin", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_AspNetUsers_AuthorId",
                table: "Annotations",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_AspNetUsers_AuthorId",
                table: "Annotations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0d0c5700-0018-4870-8349-8d33cb4effc9", "d1120f53-c74d-49f6-b976-4d4e53317fca" });

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Annotations");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Annotations");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Annotations",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "EndIndex",
                table: "Annotations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartIndex",
                table: "Annotations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d17ad35-9934-4488-85c2-9a6621858cfa", "b5f0d2e4-4a7a-4771-a47a-17f516b808c7", "Admin", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_AspNetUsers_AuthorId",
                table: "Annotations",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
