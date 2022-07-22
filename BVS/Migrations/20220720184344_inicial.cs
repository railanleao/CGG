using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVS.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compradores",
                columns: table => new
                {
                    CadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compradores", x => x.CadastroId);
                });

            migrationBuilder.CreateTable(
                name: "Associados",
                columns: table => new
                {
                    CadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fazenda = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    DataDaParceria = table.Column<DateTime>(type: "date", nullable: false),
                    IdComprador = table.Column<Guid>(type: "uuid", nullable: true),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associados", x => x.CadastroId);
                    table.ForeignKey(
                        name: "FK_Associados_Compradores_IdComprador",
                        column: x => x.IdComprador,
                        principalTable: "Compradores",
                        principalColumn: "CadastroId");
                });

            migrationBuilder.CreateTable(
                name: "InicioParcerias",
                columns: table => new
                {
                    BoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdComprador = table.Column<Guid>(type: "uuid", nullable: false),
                    IdAssociado = table.Column<Guid>(type: "uuid", nullable: false),
                    DataInicioParceria = table.Column<DateTime>(type: "date", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Origem = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Lote = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Classificacao = table.Column<string>(type: "text", nullable: false),
                    CompraVenda = table.Column<string>(type: "text", nullable: false),
                    PesoBruto = table.Column<decimal>(type: "numeric(7,2)", nullable: false),
                    RendimentoCarcaca = table.Column<decimal>(type: "numeric(7,2)", nullable: false),
                    Arroba = table.Column<decimal>(type: "numeric(7,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InicioParcerias", x => x.BoiId);
                    table.ForeignKey(
                        name: "FK_InicioParcerias_Associados_IdAssociado",
                        column: x => x.IdAssociado,
                        principalTable: "Associados",
                        principalColumn: "CadastroId");
                    table.ForeignKey(
                        name: "FK_InicioParcerias_Compradores_IdComprador",
                        column: x => x.IdComprador,
                        principalTable: "Compradores",
                        principalColumn: "CadastroId");
                });

            migrationBuilder.CreateTable(
                name: "AlteracaoSaidas",
                columns: table => new
                {
                    BoiId = table.Column<Guid>(type: "uuid", nullable: false),
                    PesoMedioAlterado = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Saida = table.Column<DateTime>(type: "date", nullable: false),
                    IdComprador = table.Column<Guid>(type: "uuid", nullable: false),
                    IdAssociado = table.Column<Guid>(type: "uuid", nullable: false),
                    InicioParceriaId = table.Column<Guid>(type: "uuid", nullable: true),
                    Classificacao = table.Column<string>(type: "text", nullable: true),
                    CompraVenda = table.Column<string>(type: "text", nullable: true),
                    PesoBruto = table.Column<decimal>(type: "numeric(7,2)", nullable: false),
                    RendimentoCarcaca = table.Column<decimal>(type: "numeric(7,2)", nullable: false),
                    Arroba = table.Column<decimal>(type: "numeric(7,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlteracaoSaidas", x => x.BoiId);
                    table.ForeignKey(
                        name: "FK_AlteracaoSaidas_Associados_IdAssociado",
                        column: x => x.IdAssociado,
                        principalTable: "Associados",
                        principalColumn: "CadastroId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AlteracaoSaidas_Compradores_IdComprador",
                        column: x => x.IdComprador,
                        principalTable: "Compradores",
                        principalColumn: "CadastroId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AlteracaoSaidas_InicioParcerias_InicioParceriaId",
                        column: x => x.InicioParceriaId,
                        principalTable: "InicioParcerias",
                        principalColumn: "BoiId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlteracaoSaidas_IdAssociado",
                table: "AlteracaoSaidas",
                column: "IdAssociado");

            migrationBuilder.CreateIndex(
                name: "IX_AlteracaoSaidas_IdComprador",
                table: "AlteracaoSaidas",
                column: "IdComprador");

            migrationBuilder.CreateIndex(
                name: "IX_AlteracaoSaidas_InicioParceriaId",
                table: "AlteracaoSaidas",
                column: "InicioParceriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Associados_IdComprador",
                table: "Associados",
                column: "IdComprador");

            migrationBuilder.CreateIndex(
                name: "IX_InicioParcerias_IdAssociado",
                table: "InicioParcerias",
                column: "IdAssociado");

            migrationBuilder.CreateIndex(
                name: "IX_InicioParcerias_IdComprador",
                table: "InicioParcerias",
                column: "IdComprador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlteracaoSaidas");

            migrationBuilder.DropTable(
                name: "InicioParcerias");

            migrationBuilder.DropTable(
                name: "Associados");

            migrationBuilder.DropTable(
                name: "Compradores");
        }
    }
}
