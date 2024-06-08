using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAPICarro.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Cargo_CargoId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Pessoas_ClienteDocumento",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Pessoas_FuncionarioDocumento",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_CargoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Comissao",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Renda",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "ValorComissao",
                table: "Pessoas");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Documento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Renda = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Documento);
                    table.ForeignKey(
                        name: "FK_Clientes_Pessoas_Documento",
                        column: x => x.Documento,
                        principalTable: "Pessoas",
                        principalColumn: "Documento");
                });

            migrationBuilder.CreateTable(
                name: "Funcionários",
                columns: table => new
                {
                    Documento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    ValorComissao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comissao = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionários", x => x.Documento);
                    table.ForeignKey(
                        name: "FK_Funcionários_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionários_Pessoas_Documento",
                        column: x => x.Documento,
                        principalTable: "Pessoas",
                        principalColumn: "Documento");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionários_CargoId",
                table: "Funcionários",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Clientes_ClienteDocumento",
                table: "Venda",
                column: "ClienteDocumento",
                principalTable: "Clientes",
                principalColumn: "Documento");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Funcionários_FuncionarioDocumento",
                table: "Venda",
                column: "FuncionarioDocumento",
                principalTable: "Funcionários",
                principalColumn: "Documento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Clientes_ClienteDocumento",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Funcionários_FuncionarioDocumento",
                table: "Venda");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Funcionários");

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Pessoas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Comissao",
                table: "Pessoas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Renda",
                table: "Pessoas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorComissao",
                table: "Pessoas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CargoId",
                table: "Pessoas",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Cargo_CargoId",
                table: "Pessoas",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Pessoas_ClienteDocumento",
                table: "Venda",
                column: "ClienteDocumento",
                principalTable: "Pessoas",
                principalColumn: "Documento");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Pessoas_FuncionarioDocumento",
                table: "Venda",
                column: "FuncionarioDocumento",
                principalTable: "Pessoas",
                principalColumn: "Documento");
        }
    }
}
