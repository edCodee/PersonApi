using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    person_serial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    person_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    person_firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    person_lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    person_dateOfBirth = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.person_serial);
                });

            migrationBuilder.CreateIndex(
                name: "IX_person_person_id",
                table: "person",
                column: "person_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
