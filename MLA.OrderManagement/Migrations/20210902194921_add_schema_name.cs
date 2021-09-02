using Microsoft.EntityFrameworkCore.Migrations;

namespace MLA.OrderManagement.Infrustructure.Migrations
{
    public partial class add_schema_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NewOrderMgt");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "NewOrderMgt");

            migrationBuilder.RenameTable(
                name: "Layers",
                newName: "Layers",
                newSchema: "NewOrderMgt");

            migrationBuilder.RenameTable(
                name: "LawFirmInvolved",
                newName: "LawFirmInvolved",
                newSchema: "NewOrderMgt");

            migrationBuilder.RenameTable(
                name: "CrossJudiciaries",
                newName: "CrossJudiciaries",
                newSchema: "NewOrderMgt");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Client",
                newSchema: "NewOrderMgt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "NewOrderMgt",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Layers",
                schema: "NewOrderMgt",
                newName: "Layers");

            migrationBuilder.RenameTable(
                name: "LawFirmInvolved",
                schema: "NewOrderMgt",
                newName: "LawFirmInvolved");

            migrationBuilder.RenameTable(
                name: "CrossJudiciaries",
                schema: "NewOrderMgt",
                newName: "CrossJudiciaries");

            migrationBuilder.RenameTable(
                name: "Client",
                schema: "NewOrderMgt",
                newName: "Client");
        }
    }
}
