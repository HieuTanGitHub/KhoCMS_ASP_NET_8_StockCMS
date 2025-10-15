using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagementMVC.Migrations
{
    /// <inheritdoc />
    public partial class CapNhatNhaCungCap_NhaKho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "WarehouseTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseTransactions_SupplierId",
                table: "WarehouseTransactions",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseTransactions_Supplier_SupplierId",
                table: "WarehouseTransactions",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseTransactions_Supplier_SupplierId",
                table: "WarehouseTransactions");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseTransactions_SupplierId",
                table: "WarehouseTransactions");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "WarehouseTransactions");
        }
    }
}
