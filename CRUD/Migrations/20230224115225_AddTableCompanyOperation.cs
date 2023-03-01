using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CRUD.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCompanyOperation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameCompany",
                table: "MoneyOperations");

            migrationBuilder.DropColumn(
                name: "NameOperation",
                table: "MoneyOperations");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "MoneyOperations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperationID",
                table: "MoneyOperations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DateOpening = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "MoneyOperations");

            migrationBuilder.DropColumn(
                name: "OperationID",
                table: "MoneyOperations");

            migrationBuilder.AddColumn<string>(
                name: "NameCompany",
                table: "MoneyOperations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOperation",
                table: "MoneyOperations",
                type: "text",
                nullable: true);
        }
    }
}
