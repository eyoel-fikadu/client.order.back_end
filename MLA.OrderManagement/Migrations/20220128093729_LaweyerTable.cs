using Microsoft.EntityFrameworkCore.Migrations;

namespace MLA.OrderManagement.Infrustructure.Migrations
{
    public partial class LaweyerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                schema: "NewOrderMgt",
                table: "Lawyers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "NewOrderMgt",
                table: "Lawyers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "NewOrderMgt",
                table: "Lawyers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                schema: "NewOrderMgt",
                table: "Lawyers");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "NewOrderMgt",
                table: "Lawyers");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "NewOrderMgt",
                table: "Lawyers");
        }
    }
}
