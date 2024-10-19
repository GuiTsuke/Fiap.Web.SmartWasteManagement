using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fiap.Web.SmartWasteManagement.Migrations
{
    /// <inheritdoc />
    public partial class TabelasNoMySQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBL_CAMINHOES",
                columns: table => new
                {
                    CD_CAMINHAO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DS_PLACA = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    VL_CAPACIDADE_CARGA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CD_STATUS = table.Column<int>(type: "int", nullable: false),
                    DS_LOCALIZACAO_ATUAL = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CAMINHOES", x => x.CD_CAMINHAO);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBL_MORADORES",
                columns: table => new
                {
                    CD_MORADOR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DS_NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DS_EMAIL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DS_TELEFONE = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    DS_ENDERECO = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MORADORES", x => x.CD_MORADOR);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBL_ROTAS",
                columns: table => new
                {
                    CD_ROTA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CD_CAMINHAO = table.Column<int>(type: "int", nullable: false),
                    DT_COLETA = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DT_HORA_INICIO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DT_HORA_FIM = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DS_PONTOS_COLETA = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ROTAS", x => x.CD_ROTA);
                    table.ForeignKey(
                        name: "FK_TBL_ROTAS_TBL_CAMINHOES_CD_CAMINHAO",
                        column: x => x.CD_CAMINHAO,
                        principalTable: "TBL_CAMINHOES",
                        principalColumn: "CD_CAMINHAO",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBL_RECIPIENTES",
                columns: table => new
                {
                    CD_RECIPIENTE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DS_ENDERECO = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    DS_TIPO_RESIDUOS = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    VL_CAPACIDADE_TOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VL_NIVEL_OCUPACAO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CD_MORADOR = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_RECIPIENTES", x => x.CD_RECIPIENTE);
                    table.ForeignKey(
                        name: "FK_TBL_RECIPIENTES_TBL_MORADORES_CD_MORADOR",
                        column: x => x.CD_MORADOR,
                        principalTable: "TBL_MORADORES",
                        principalColumn: "CD_MORADOR",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBL_AGENDAMENTOS_COLETA",
                columns: table => new
                {
                    CD_AGENDAMENTO_COLETA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CD_RECIPIENTE = table.Column<int>(type: "int", nullable: false),
                    CD_ROTA = table.Column<int>(type: "int", nullable: false),
                    DT_AGENDAMENTO = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_AGENDAMENTOS_COLETA", x => x.CD_AGENDAMENTO_COLETA);
                    table.ForeignKey(
                        name: "FK_TBL_AGENDAMENTOS_COLETA_TBL_RECIPIENTES_CD_RECIPIENTE",
                        column: x => x.CD_RECIPIENTE,
                        principalTable: "TBL_RECIPIENTES",
                        principalColumn: "CD_RECIPIENTE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_AGENDAMENTOS_COLETA_TBL_ROTAS_CD_ROTA",
                        column: x => x.CD_ROTA,
                        principalTable: "TBL_ROTAS",
                        principalColumn: "CD_ROTA",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBL_NOTIFICACOES",
                columns: table => new
                {
                    CD_NOTIFICACAO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DT_ENVIO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CD_STATUS_NOTIFICACAO = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CD_STATUS_LEITURA = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    CD_MORADOR = table.Column<int>(type: "int", nullable: false),
                    CD_RECIPIENTE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_NOTIFICACOES", x => x.CD_NOTIFICACAO);
                    table.ForeignKey(
                        name: "FK_TBL_NOTIFICACOES_TBL_MORADORES_CD_MORADOR",
                        column: x => x.CD_MORADOR,
                        principalTable: "TBL_MORADORES",
                        principalColumn: "CD_MORADOR",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_NOTIFICACOES_TBL_RECIPIENTES_CD_RECIPIENTE",
                        column: x => x.CD_RECIPIENTE,
                        principalTable: "TBL_RECIPIENTES",
                        principalColumn: "CD_RECIPIENTE",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_AGENDAMENTOS_COLETA_CD_RECIPIENTE",
                table: "TBL_AGENDAMENTOS_COLETA",
                column: "CD_RECIPIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_AGENDAMENTOS_COLETA_CD_ROTA",
                table: "TBL_AGENDAMENTOS_COLETA",
                column: "CD_ROTA");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_NOTIFICACOES_CD_MORADOR",
                table: "TBL_NOTIFICACOES",
                column: "CD_MORADOR");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_NOTIFICACOES_CD_RECIPIENTE",
                table: "TBL_NOTIFICACOES",
                column: "CD_RECIPIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_RECIPIENTES_CD_MORADOR",
                table: "TBL_RECIPIENTES",
                column: "CD_MORADOR");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ROTAS_CD_CAMINHAO",
                table: "TBL_ROTAS",
                column: "CD_CAMINHAO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_AGENDAMENTOS_COLETA");

            migrationBuilder.DropTable(
                name: "TBL_NOTIFICACOES");

            migrationBuilder.DropTable(
                name: "TBL_ROTAS");

            migrationBuilder.DropTable(
                name: "TBL_RECIPIENTES");

            migrationBuilder.DropTable(
                name: "TBL_CAMINHOES");

            migrationBuilder.DropTable(
                name: "TBL_MORADORES");
        }
    }
}
