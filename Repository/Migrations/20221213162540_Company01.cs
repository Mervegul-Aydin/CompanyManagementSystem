using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Company01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyWebUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TaxAdministration = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InvoiceAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InvoiceMailAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LogoBase64Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyWebUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TaxAdministration = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InvoiceAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InvoiceMailAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LogoBase64Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchOffices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDealers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyWebUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TaxAdministration = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InvoiceAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InvoiceMailAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LogoBase64Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyDealers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchOffices_CompanyId",
                table: "BranchOffices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDealers_CompanyId",
                table: "CompanyDealers",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchOffices");

            migrationBuilder.DropTable(
                name: "CompanyDealers");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
