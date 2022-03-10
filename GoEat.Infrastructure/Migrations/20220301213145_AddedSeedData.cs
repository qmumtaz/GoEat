using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoEat.Infrastructure.Migrations
{
    public partial class AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Order",
                column: "Id",
                value: new Guid("b61cfc10-90ee-46ae-b1a2-78e3c529cd7e"));

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "ItemQuantity", "OrderId", "Price" },
                values: new object[] { new Guid("e1c1ffcf-1427-4672-8272-1c8a6e575a37"), 1, new Guid("b61cfc10-90ee-46ae-b1a2-78e3c529cd7e"), 0.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: new Guid("e1c1ffcf-1427-4672-8272-1c8a6e575a37"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("b61cfc10-90ee-46ae-b1a2-78e3c529cd7e"));
        }
    }
}
