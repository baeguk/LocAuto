using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locacoes.Migrations
{
    /// <inheritdoc />
    public partial class locacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Kilometragem",
                table: "Veiculos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ModeloID",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLocacao = table.Column<DateOnly>(type: "date", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ModeloID",
                table: "Veiculos",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_ClienteId",
                table: "Locacoes",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Modelos_ModeloID",
                table: "Veiculos",
                column: "ModeloID",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Modelos_ModeloID",
                table: "Veiculos");

            migrationBuilder.DropTable(
                name: "Locacoes");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_ModeloID",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "Kilometragem",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "ModeloID",
                table: "Veiculos");
        }
    }
}
