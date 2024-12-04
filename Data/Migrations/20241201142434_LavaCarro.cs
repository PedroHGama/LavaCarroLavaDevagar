using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WashCarLavaDevagar.Data.Migrations
{
    /// <inheritdoc />
    public partial class LavaCarro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IDCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoneCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IDCliente);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeF = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EnderecoF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNasc = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioID);
                });

            migrationBuilder.CreateTable(
                name: "TipoLavagem",
                columns: table => new
                {
                    IDTipoLavagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValorBase = table.Column<double>(type: "float", nullable: false),
                    TipoLavagemIDTipoLavagem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLavagem", x => x.IDTipoLavagem);
                    table.ForeignKey(
                        name: "FK_TipoLavagem_TipoLavagem_TipoLavagemIDTipoLavagem",
                        column: x => x.TipoLavagemIDTipoLavagem,
                        principalTable: "TipoLavagem",
                        principalColumn: "IDTipoLavagem");
                });

            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    IDCarro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.IDCarro);
                    table.ForeignKey(
                        name: "FK_Carro_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "IDCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lavagem",
                columns: table => new
                {
                    IDLavagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoLavagemID = table.Column<int>(type: "int", nullable: false),
                    DataLavagem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorLavagem = table.Column<double>(type: "float", nullable: false),
                    DescontoLavagem = table.Column<double>(type: "float", nullable: false),
                    CarroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lavagem", x => x.IDLavagem);
                    table.ForeignKey(
                        name: "FK_Lavagem_Carro_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carro",
                        principalColumn: "IDCarro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lavagem_TipoLavagem_TipoLavagemID",
                        column: x => x.TipoLavagemID,
                        principalTable: "TipoLavagem",
                        principalColumn: "IDTipoLavagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carro_ClienteID",
                table: "Carro",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Lavagem_CarroID",
                table: "Lavagem",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_Lavagem_TipoLavagemID",
                table: "Lavagem",
                column: "TipoLavagemID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoLavagem_TipoLavagemIDTipoLavagem",
                table: "TipoLavagem",
                column: "TipoLavagemIDTipoLavagem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Lavagem");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "TipoLavagem");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
