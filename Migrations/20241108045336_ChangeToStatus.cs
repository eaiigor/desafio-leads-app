using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace desafio_leads.Migrations
{
    public partial class ChangeToStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Accepted",
                table: "Leads",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Leads",
                newName: "Accepted");
        }
    }
}
