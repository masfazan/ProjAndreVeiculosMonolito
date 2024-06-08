using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAPICarro.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boleto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boleto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartaoNumeroCartao = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BoletoId = table.Column<int>(type: "int", nullable: false),
                    PixId = table.Column<int>(type: "int", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Boleto_BoletoId",
                        column: x => x.BoletoId,
                        principalTable: "Boleto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamento_Cartao_CartaoNumeroCartao",
                        column: x => x.CartaoNumeroCartao,
                        principalTable: "Cartao",
                        principalColumn: "NumeroCartao");
                    table.ForeignKey(
                        name: "FK_Pagamento_Pix_PixId",
                        column: x => x.PixId,
                        principalTable: "Pix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroPlaca = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteDocumento = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FuncionarioDocumento = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PagamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Carro_CarroPlaca",
                        column: x => x.CarroPlaca,
                        principalTable: "Carro",
                        principalColumn: "Placa");
                    table.ForeignKey(
                        name: "FK_Venda_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Pessoas_ClienteDocumento",
                        column: x => x.ClienteDocumento,
                        principalTable: "Pessoas",
                        principalColumn: "Documento");
                    table.ForeignKey(
                        name: "FK_Venda_Pessoas_FuncionarioDocumento",
                        column: x => x.FuncionarioDocumento,
                        principalTable: "Pessoas",
                        principalColumn: "Documento");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_BoletoId",
                table: "Pagamento",
                column: "BoletoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_CartaoNumeroCartao",
                table: "Pagamento",
                column: "CartaoNumeroCartao");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_PixId",
                table: "Pagamento",
                column: "PixId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_CarroPlaca",
                table: "Venda",
                column: "CarroPlaca");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteDocumento",
                table: "Venda",
                column: "ClienteDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_FuncionarioDocumento",
                table: "Venda",
                column: "FuncionarioDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_PagamentoId",
                table: "Venda",
                column: "PagamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Boleto");
        }
    }
}
