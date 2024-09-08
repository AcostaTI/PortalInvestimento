using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalInvestimento.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoDominio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AporteMinimo",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "RentabilidadeUltimo_3meses",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "Rentabilidade_Ultimo_12meses",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "Rentabilidade_Ultimo_24meses",
                table: "Ativos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AporteMinimo",
                table: "Ativos",
                type: "decimal(16,4)",
                precision: 16,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RentabilidadeUltimo_3meses",
                table: "Ativos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rentabilidade_Ultimo_12meses",
                table: "Ativos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rentabilidade_Ultimo_24meses",
                table: "Ativos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
