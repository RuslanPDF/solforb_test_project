using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixConfigUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReceiptResource_ReceiptDocumentId_ResourceId_UnitOfMeasurem~",
                table: "ReceiptResource");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptResource_ReceiptDocumentId_ResourceId",
                table: "ReceiptResource",
                columns: new[] { "ReceiptDocumentId", "ResourceId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReceiptResource_ReceiptDocumentId_ResourceId",
                table: "ReceiptResource");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptResource_ReceiptDocumentId_ResourceId_UnitOfMeasurem~",
                table: "ReceiptResource",
                columns: new[] { "ReceiptDocumentId", "ResourceId", "UnitOfMeasurementId" });
        }
    }
}
