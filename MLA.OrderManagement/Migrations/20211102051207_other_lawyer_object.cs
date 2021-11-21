using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MLA.OrderManagement.Infrustructure.Migrations
{
    public partial class other_lawyer_object : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Layers_Orders_OrdersId",
                schema: "NewOrderMgt",
                table: "Layers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Layers_LeadLayerId",
                schema: "NewOrderMgt",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Layers",
                schema: "NewOrderMgt",
                table: "Layers");

            migrationBuilder.DropIndex(
                name: "IX_Layers_OrdersId",
                schema: "NewOrderMgt",
                table: "Layers");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                schema: "NewOrderMgt",
                table: "Layers");

            migrationBuilder.RenameTable(
                name: "Layers",
                schema: "NewOrderMgt",
                newName: "Lawyers",
                newSchema: "NewOrderMgt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lawyers",
                schema: "NewOrderMgt",
                table: "Lawyers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OtherLawyers",
                schema: "NewOrderMgt",
                columns: table => new
                {
                    LawyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherLawyers", x => new { x.LawyerId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OtherLawyers_Lawyers_LawyerId",
                        column: x => x.LawyerId,
                        principalSchema: "NewOrderMgt",
                        principalTable: "Lawyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherLawyers_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "NewOrderMgt",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtherLawyers_OrderId",
                schema: "NewOrderMgt",
                table: "OtherLawyers",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Lawyers_LeadLayerId",
                schema: "NewOrderMgt",
                table: "Orders",
                column: "LeadLayerId",
                principalSchema: "NewOrderMgt",
                principalTable: "Lawyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Lawyers_LeadLayerId",
                schema: "NewOrderMgt",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OtherLawyers",
                schema: "NewOrderMgt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lawyers",
                schema: "NewOrderMgt",
                table: "Lawyers");

            migrationBuilder.RenameTable(
                name: "Lawyers",
                schema: "NewOrderMgt",
                newName: "Layers",
                newSchema: "NewOrderMgt");

            migrationBuilder.AddColumn<Guid>(
                name: "OrdersId",
                schema: "NewOrderMgt",
                table: "Layers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Layers",
                schema: "NewOrderMgt",
                table: "Layers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Layers_OrdersId",
                schema: "NewOrderMgt",
                table: "Layers",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Layers_Orders_OrdersId",
                schema: "NewOrderMgt",
                table: "Layers",
                column: "OrdersId",
                principalSchema: "NewOrderMgt",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Layers_LeadLayerId",
                schema: "NewOrderMgt",
                table: "Orders",
                column: "LeadLayerId",
                principalSchema: "NewOrderMgt",
                principalTable: "Layers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
