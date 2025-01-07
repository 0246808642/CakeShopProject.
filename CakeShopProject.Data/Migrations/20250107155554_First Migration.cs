using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeShopProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Situation = table.Column<byte>(type: "tinyint", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIdCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdModified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdDeleted = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CodeCity = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    Situation = table.Column<byte>(type: "tinyint", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIdCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdModified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdDeleted = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    NumberOfHouse = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    Situation = table.Column<byte>(type: "tinyint", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIdCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdModified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdDeleted = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    OrderStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    Situation = table.Column<byte>(type: "tinyint", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIdCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdModified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdDeleted = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Size = table.Column<byte>(type: "tinyint", nullable: false),
                    Flavor = table.Column<byte>(type: "tinyint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrdersId = table.Column<long>(type: "bigint", nullable: false),
                    Situation = table.Column<byte>(type: "tinyint", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIdCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdModified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIdDeleted = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CityId",
                table: "Client",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrdersId",
                table: "Product",
                column: "OrdersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
