using Microsoft.EntityFrameworkCore.Migrations;

namespace ComercioLocalBackEnd.Migrations
{
    public partial class CreateTablePerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfil_Usuario_UsuarioId",
                table: "Perfil");

            migrationBuilder.DropForeignKey(
                name: "FK_Promocao_Perfil_PerfilId",
                table: "Promocao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promocao",
                table: "Promocao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Perfil",
                table: "Perfil");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Promocao",
                newName: "Promocoes");

            migrationBuilder.RenameTable(
                name: "Perfil",
                newName: "Perfis");

            migrationBuilder.RenameIndex(
                name: "IX_Promocao_PerfilId",
                table: "Promocoes",
                newName: "IX_Promocoes_PerfilId");

            migrationBuilder.RenameIndex(
                name: "IX_Perfil_UsuarioId",
                table: "Perfis",
                newName: "IX_Perfis_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promocoes",
                table: "Promocoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Perfis",
                table: "Perfis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfis_Usuarios_UsuarioId",
                table: "Perfis",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promocoes_Perfis_PerfilId",
                table: "Promocoes",
                column: "PerfilId",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_Usuarios_UsuarioId",
                table: "Perfis");

            migrationBuilder.DropForeignKey(
                name: "FK_Promocoes_Perfis_PerfilId",
                table: "Promocoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promocoes",
                table: "Promocoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Perfis",
                table: "Perfis");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "Promocoes",
                newName: "Promocao");

            migrationBuilder.RenameTable(
                name: "Perfis",
                newName: "Perfil");

            migrationBuilder.RenameIndex(
                name: "IX_Promocoes_PerfilId",
                table: "Promocao",
                newName: "IX_Promocao_PerfilId");

            migrationBuilder.RenameIndex(
                name: "IX_Perfis_UsuarioId",
                table: "Perfil",
                newName: "IX_Perfil_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promocao",
                table: "Promocao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Perfil",
                table: "Perfil",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfil_Usuario_UsuarioId",
                table: "Perfil",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promocao_Perfil_PerfilId",
                table: "Promocao",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
