using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalInvestimento.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoOperacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Transacoes",
                type: "decimal(16,4)",
                precision: 16,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Operacao",
                table: "Transacoes",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operacao",
                table: "Transacoes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Transacoes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,4)",
                oldPrecision: 16,
                oldScale: 4);
        }
    }
}
