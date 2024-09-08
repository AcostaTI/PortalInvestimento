using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalInvestimento.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class correcoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Transacoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Transacoes");
        }
    }
}
