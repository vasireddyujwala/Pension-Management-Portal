using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pension_Management_Portal.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PensionerDetails",
                columns: table => new
                {
                    PensionerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Dateofbirth = table.Column<DateTime>(nullable: false),
                    PAN = table.Column<string>(nullable: false),
                    SalaryEarned = table.Column<int>(nullable: false),
                    Allowances = table.Column<int>(nullable: false),
                    AadharNumber = table.Column<string>(nullable: false),
                    PensionType = table.Column<int>(nullable: false),
                    BankName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    BankType = table.Column<int>(nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PensionerDetails", x => x.PensionerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PensionerDetails");
        }
    }
}
