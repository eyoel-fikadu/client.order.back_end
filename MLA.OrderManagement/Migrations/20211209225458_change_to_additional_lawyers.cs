using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MLA.OrderManagement.Infrustructure.Migrations
{
    public partial class change_to_additional_lawyers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrossJudiciaries_Lookups_JudiciariesId",
                schema: "NewOrderMgt",
                table: "CrossJudiciaries");

            migrationBuilder.DropForeignKey(
                name: "FK_LawFirmInvolved_Lookups_LawFirmId",
                schema: "NewOrderMgt",
                table: "LawFirmInvolved");

            migrationBuilder.DropTable(
                name: "OtherLawyers",
                schema: "NewOrderMgt");

            migrationBuilder.AlterColumn<Guid>(
                name: "LawFirmId",
                schema: "NewOrderMgt",
                table: "LawFirmInvolved",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JudiciariesId",
                schema: "NewOrderMgt",
                table: "CrossJudiciaries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AdditionalLawyers",
                schema: "NewOrderMgt",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LawyersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalLawyers", x => new { x.OrdersId, x.Id });
                    table.ForeignKey(
                        name: "FK_AdditionalLawyers_Lawyers_LawyersId",
                        column: x => x.LawyersId,
                        principalSchema: "NewOrderMgt",
                        principalTable: "Lawyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalLawyers_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalSchema: "NewOrderMgt",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalLawyers_LawyersId",
                schema: "NewOrderMgt",
                table: "AdditionalLawyers",
                column: "LawyersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrossJudiciaries_Lookups_JudiciariesId",
                schema: "NewOrderMgt",
                table: "CrossJudiciaries",
                column: "JudiciariesId",
                principalSchema: "NewOrderMgt",
                principalTable: "Lookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LawFirmInvolved_Lookups_LawFirmId",
                schema: "NewOrderMgt",
                table: "LawFirmInvolved",
                column: "LawFirmId",
                principalSchema: "NewOrderMgt",
                principalTable: "Lookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrossJudiciaries_Lookups_JudiciariesId",
                schema: "NewOrderMgt",
                table: "CrossJudiciaries");

            migrationBuilder.DropForeignKey(
                name: "FK_LawFirmInvolved_Lookups_LawFirmId",
                schema: "NewOrderMgt",
                table: "LawFirmInvolved");

            migrationBuilder.DropTable(
                name: "AdditionalLawyers",
                schema: "NewOrderMgt");

            migrationBuilder.AlterColumn<Guid>(
                name: "LawFirmId",
                schema: "NewOrderMgt",
                table: "LawFirmInvolved",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "JudiciariesId",
                schema: "NewOrderMgt",
                table: "CrossJudiciaries",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                name: "FK_CrossJudiciaries_Lookups_JudiciariesId",
                schema: "NewOrderMgt",
                table: "CrossJudiciaries",
                column: "JudiciariesId",
                principalSchema: "NewOrderMgt",
                principalTable: "Lookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LawFirmInvolved_Lookups_LawFirmId",
                schema: "NewOrderMgt",
                table: "LawFirmInvolved",
                column: "LawFirmId",
                principalSchema: "NewOrderMgt",
                principalTable: "Lookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
