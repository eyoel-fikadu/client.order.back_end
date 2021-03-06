using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MLA.OrderManagement.Infrustructure.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NewOrderMgt");

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "NewOrderMgt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Client_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Industry_sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Person = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_person_Email_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_person_Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registration_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_AddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "NewOrderMgt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdustrySector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadLayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsLawFirmInvolved = table.Column<bool>(type: "bit", nullable: false),
                    CroossJudiciaryExistt = table.Column<bool>(type: "bit", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionValue = table.Column<double>(type: "float", nullable: false),
                    IsConfidential = table.Column<bool>(type: "bit", nullable: false),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "NewOrderMgt",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrossJudiciaries",
                schema: "NewOrderMgt",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Judiciaries = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossJudiciaries", x => new { x.OrdersId, x.Id });
                    table.ForeignKey(
                        name: "FK_CrossJudiciaries_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalSchema: "NewOrderMgt",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LawFirmInvolved",
                schema: "NewOrderMgt",
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
                        principalSchema: "NewOrderMgt",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Layers",
                schema: "NewOrderMgt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Layers_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalSchema: "NewOrderMgt",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Layers_OrdersId",
                schema: "NewOrderMgt",
                table: "Layers",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                schema: "NewOrderMgt",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LeadLayerId",
                schema: "NewOrderMgt",
                table: "Orders",
                column: "LeadLayerId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Layers_Orders_OrdersId",
                schema: "NewOrderMgt",
                table: "Layers");

            migrationBuilder.DropTable(
                name: "CrossJudiciaries",
                schema: "NewOrderMgt");

            migrationBuilder.DropTable(
                name: "LawFirmInvolved",
                schema: "NewOrderMgt");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "NewOrderMgt");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "NewOrderMgt");

            migrationBuilder.DropTable(
                name: "Layers",
                schema: "NewOrderMgt");
        }
    }
}
