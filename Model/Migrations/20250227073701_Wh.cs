using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class Wh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pallet",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qrcode = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false),
                    place_id = table.Column<int>(type: "int", nullable: false),
                    isOrdered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pallet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    worker_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    incomingCargo_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    outgoingCargo_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    barcode = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    onPallet = table.Column<bool>(type: "bit", nullable: false),
                    pallet_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Pallet_pallet_id",
                        column: x => x.pallet_id,
                        principalTable: "Pallet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pallets",
                columns: table => new
                {
                    process_id = table.Column<int>(type: "int", nullable: false),
                    pallet_id = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pallets", x => new { x.process_id, x.pallet_id });
                    table.ForeignKey(
                        name: "FK_Pallets_Pallet_pallet_id",
                        column: x => x.pallet_id,
                        principalTable: "Pallet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pallets_Processes_process_id",
                        column: x => x.process_id,
                        principalTable: "Processes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    process_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => new { x.process_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_Products_Processes_process_id",
                        column: x => x.process_id,
                        principalTable: "Processes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_pallet_id",
                table: "Pallets",
                column: "pallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_pallet_id",
                table: "Product",
                column: "pallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_product_id",
                table: "Products",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pallets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Pallet");
        }
    }
}
