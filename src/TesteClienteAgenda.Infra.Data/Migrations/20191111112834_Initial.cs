using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteClienteAgenda.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razao_social = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    data_fundacao = table.Column<DateTime>(nullable: false),
                    cnpj = table.Column<string>(type: "varchar(14)", fixedLength: true, maxLength: 14, nullable: false),
                    capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quarentena = table.Column<bool>(nullable: false),
                    status_cliente = table.Column<bool>(nullable: false),
                    classificacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agenda",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor_bruto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_liquido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    taxa = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    data_liquidacao = table.Column<DateTime>(nullable: false),
                    num_titulo = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agenda", x => x.id);
                    table.ForeignKey(
                        name: "cliente_id",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_agenda_ClienteId",
                table: "agenda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_cnpj_razao_social",
                table: "cliente",
                columns: new[] { "cnpj", "razao_social" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agenda");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
