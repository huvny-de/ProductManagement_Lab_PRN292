using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductManagement_Lab_PRN292.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "364a3d9b-7022-4353-a7b4-904eced25eb0", "0e71f3e0-6032-4318-a061-ba47b59eec9a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a0423453-2858-484f-a934-18a2ffe21aa2", "1d9a0ff2-564a-4640-91ec-3b8ab38a2785" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "364a3d9b-7022-4353-a7b4-904eced25eb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0423453-2858-484f-a934-18a2ffe21aa2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e71f3e0-6032-4318-a061-ba47b59eec9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d9a0ff2-564a-4640-91ec-3b8ab38a2785");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a0423453-2858-484f-a934-18a2ffe21aa2", "d1df1571-1463-457d-94ba-d96a8af8b954", "Administrator", "Administrator" },
                    { "364a3d9b-7022-4353-a7b4-904eced25eb0", "ce31eb9f-88b7-4a43-a935-077fa689814d", "Editor", "Editor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1d9a0ff2-564a-4640-91ec-3b8ab38a2785", 0, "2e5e7b7d-c531-4e73-93d1-d368422e4d0b", new DateTime(1997, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "huvny@gmail.com", true, "Henry", "de Aaron", false, null, "huvny@gmail.com", "huvny", "AQAAAAEAACcQAAAAEBtlt/aJHqe9GztrKGFQ095efuR4TLaWpyISCI+2p7GHo9+mLHx43T9UWvI+JUsTpA==", "0954683265", false, "8fc5764c-b2c9-4d40-96d1-dbcb3c97b87d", false, "huvny" },
                    { "0e71f3e0-6032-4318-a061-ba47b59eec9a", 0, "93c640b8-9f4b-4bb0-98a0-c91a9f4b0727", new DateTime(1987, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jess@gmail.com", true, "Jesse", "Livermore", false, null, "Jess@gmail.com", "Jess", "AQAAAAEAACcQAAAAEF4PCw7nzKUnHxqiryepyonEYSYURdtshLoPlGFNWo1y8gYiyelkwJ8LdCosiZ0fUw==", "6548521564", false, "7bfce413-2111-453b-95ba-acea9cf3abd4", false, "Jess" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a0423453-2858-484f-a934-18a2ffe21aa2", "1d9a0ff2-564a-4640-91ec-3b8ab38a2785" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "364a3d9b-7022-4353-a7b4-904eced25eb0", "0e71f3e0-6032-4318-a061-ba47b59eec9a" });
        }
    }
}
