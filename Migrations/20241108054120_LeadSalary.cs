using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace desafio_leads.Migrations
{
    public partial class LeadSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SalaryProposed",
                table: "Leads",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryProposed",
                table: "Leads");
        }
    }
}
