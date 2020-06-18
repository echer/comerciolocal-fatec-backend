using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComercioLocalBackEnd.Migrations
{
    public partial class CreateTableUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    TelefoneMovel = table.Column<string>(nullable: false),
                    TelefoneFixo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Razao = table.Column<string>(nullable: false),
                    Fantasia = table.Column<string>(nullable: false),
                    DataAbertura = table.Column<string>(nullable: false),
                    CNPJ = table.Column<string>(nullable: false),
                    Site = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: false),
                    CEP = table.Column<string>(nullable: false),
                    Logradouro = table.Column<string>(nullable: false),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: false),
                    Pais = table.Column<string>(nullable: false),
                    Segmento = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfis_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promocoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PerfilId = table.Column<Guid>(nullable: false),
                    DataInicio = table.Column<string>(nullable: true),
                    DataFim = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: false),
                    MidiaPromocao = table.Column<string>(nullable: true),
                    CupomPromocao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promocoes_Perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_UsuarioId",
                table: "Perfis",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Promocoes_PerfilId",
                table: "Promocoes",
                column: "PerfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promocoes");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
