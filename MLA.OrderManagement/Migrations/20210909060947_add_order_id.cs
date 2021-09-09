using Microsoft.EntityFrameworkCore.Migrations;

namespace MLA.OrderManagement.Infrustructure.Migrations
{
    public partial class add_order_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                schema: "NewOrderMgt",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "NewOrderMgt",
                table: "Orders");
        }
    }
}
