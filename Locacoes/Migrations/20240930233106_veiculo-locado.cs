using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locacoes.Migrations
{
    /// <inheritdoc />
    public partial class veiculolocado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VeiculoLocados",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    LocacaoId = table.Column<int>(type: "int", nullable: false),
                    DataDevolucao = table.Column<DateOnly>(type: "date", nullable: false),
                    KilometragemInicial = table.Column<long>(type: "bigint", nullable: false),
                    KilometragemFinal = table.Column<long>(type: "bigint", nullable: false),
                    ValorDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoLocados", x => new { x.LocacaoId, x.VeiculoId });
                    table.ForeignKey(
                        name: "FK_VeiculoLocados_Locacoes_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeiculoLocados_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoLocados_VeiculoId",
                table: "VeiculoLocados",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeiculoLocados");
        }
    }
}
