using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PaternalSurname = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    MaternalSurname = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CellphonePrefix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CellphoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pk", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "BirthDate", "CellphoneNumber", "CellphonePrefix", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "MaternalSurname", "Name", "PaternalSurname", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "", new DateTime(1995, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "311 125 4488", "+52", null, null, null, null, "luis@mail.com", "Camacho", "Luis Eduardo", "Silva", null, null },
                    { 2, "", new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "323 125 4488", "+52", null, null, null, null, "joel@mail.com", "Torres", "Joel", "Ramirez", null, null },
                    { 3, "", new DateTime(1994, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "311 178 4488", "+52", null, null, null, null, "ximena@mail.com", "Perez", "Ximena", "Rios", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
