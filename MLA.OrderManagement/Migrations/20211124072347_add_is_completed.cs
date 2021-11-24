using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MLA.OrderManagement.Infrustructure.Migrations
{
    public partial class add_is_completed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LawFirm",
                schema: "NewOrderMgt",
                table: "LawFirmInvolved");

            migrationBuilder.DropColumn(
                name: "Judiciaries",
                schema: "NewOrderMgt",
                table: "CrossJudiciaries");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                schema: "NewOrderMgt",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "LawFirmId",
                schema: "NewOrderMgt",
                table: "LawFirmInvolved",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JudiciariesId",
                schema: "NewOrderMgt",
                table: "CrossJudiciaries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LawFirmInvolved_LawFirmId",
                schema: "NewOrderMgt",
                table: "LawFirmInvolved",
                column: "LawFirmId");

            migrationBuilder.CreateIndex(
                name: "IX_CrossJudiciaries_JudiciariesId",
                schema: "NewOrderMgt",
                table: "CrossJudiciaries",
                column: "JudiciariesId");

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

            migrationBuilder.DropIndex(
                name: "IX_LawFirmInvolved_LawFirmId",
                schema: "NewOrderMgt",
                table: "LawFirmInvolved");

            migrationBuilder.DropIndex(
                name: "IX_CrossJudiciaries_JudiciariesId",
                schema: "NewOrderMgt",
                table: "CrossJudiciaries");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                schema: "NewOrderMgt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LawFirmId",
                schema: "NewOrderMgt",
                table: "LawFirmInvolved");

            migrationBuilder.DropColumn(
                name: "JudiciariesId",
                schema: "NewOrderMgt",
                table: "CrossJudiciaries");

            migrationBuilder.AddColumn<string>(
                name: "LawFirm",
                schema: "NewOrderMgt",
                table: "LawFirmInvolved",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Judiciaries",
                schema: "NewOrderMgt",
                table: "CrossJudiciaries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
