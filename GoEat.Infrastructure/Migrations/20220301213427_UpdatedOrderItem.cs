using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoEat.Infrastructure.Migrations
{
    public partial class UpdatedOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: new Guid("e1c1ffcf-1427-4672-8272-1c8a6e575a37"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("b61cfc10-90ee-46ae-b1a2-78e3c529cd7e"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Order",
                column: "Id",
                value: new Guid("80949e6c-1ed8-41ac-8f10-03aef52ae0da"));

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "Description", "ItemQuantity", "Name", "OrderId", "Price" },
                values: new object[] { new Guid("849623eb-1a6b-4626-b41a-a2751bacf066"), "Delicious cheese burger", 1, "King Burger", new Guid("80949e6c-1ed8-41ac-8f10-03aef52ae0da"), 2.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: new Guid("849623eb-1a6b-4626-b41a-a2751bacf066"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("80949e6c-1ed8-41ac-8f10-03aef52ae0da"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderItem");

            migrationBuilder.InsertData(
                table: "Order",
                column: "Id",
                value: new Guid("b61cfc10-90ee-46ae-b1a2-78e3c529cd7e"));

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "ItemQuantity", "OrderId", "Price" },
                values: new object[] { new Guid("e1c1ffcf-1427-4672-8272-1c8a6e575a37"), 1, new Guid("b61cfc10-90ee-46ae-b1a2-78e3c529cd7e"), 0.00m });
        }
    }
}
