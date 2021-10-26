using Microsoft.EntityFrameworkCore.Migrations;

namespace MLA.OrderManagement.Infrustructure.Migrations
{
    public partial class change_client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Client_ID",
                schema: "NewOrderMgt",
                table: "Client",
                newName: "Address_Address2");

            migrationBuilder.RenameColumn(
                name: "Address_AddressDescription",
                schema: "NewOrderMgt",
                table: "Client",
                newName: "Address_Address1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Address2",
                schema: "NewOrderMgt",
                table: "Client",
                newName: "Client_ID");

            migrationBuilder.RenameColumn(
                name: "Address_Address1",
                schema: "NewOrderMgt",
                table: "Client",
                newName: "Address_AddressDescription");
        }
    }
}
