using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MLA.OrderManagement.Infrustructure.Migrations
{
    public partial class ManyLawFirmInvolved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LawFirmInvolved_Capacity",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "LawFirmInvolved",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LawFirm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawFirmInvolved", x => new { x.OrdersId, x.Id });
                    table.ForeignKey(
                        name: "FK_LawFirmInvolved_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LawFirmInvolved");

            migrationBuilder.AddColumn<int>(
                name: "LawFirmInvolved_Capacity",
                table: "Orders",
                type: "int",
                nullable: true);
        }
    }
}
