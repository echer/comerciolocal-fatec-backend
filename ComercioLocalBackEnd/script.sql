CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "Usuario" (
    "Id" uuid NOT NULL,
    "Nome" text NOT NULL,
    "DataNascimento" text NULL,
    "Email" text NOT NULL,
    "Senha" text NOT NULL,
    "TelefoneMovel" text NOT NULL,
    "TelefoneFixo" text NULL,
    CONSTRAINT "PK_Usuario" PRIMARY KEY ("Id")
);

CREATE TABLE "Perfil" (
    "Id" uuid NOT NULL,
    "UsuarioId" uuid NOT NULL,
    "Razao" text NOT NULL,
    "Fantasia" text NOT NULL,
    "DataAbertura" text NOT NULL,
    "CNPJ" text NOT NULL,
    "Site" text NULL,
    "Descricao" text NOT NULL,
    "CEP" text NOT NULL,
    "Logradouro" text NOT NULL,
    "Numero" text NULL,
    "Complemento" text NULL,
    "UF" text NOT NULL,
    "Pais" text NOT NULL,
    "Segmento" text NOT NULL,
    CONSTRAINT "PK_Perfil" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Perfil_Usuario_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "Usuario" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Promocao" (
    "Id" uuid NOT NULL,
    "PerfilId" uuid NOT NULL,
    "DataInicio" text NULL,
    "DataFim" text NULL,
    "Descricao" text NOT NULL,
    "MidiaPromocao" text NULL,
    "CupomPromocao" text NULL,
    CONSTRAINT "PK_Promocao" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Promocao_Perfil_PerfilId" FOREIGN KEY ("PerfilId") REFERENCES "Perfil" ("Id") ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_Perfil_UsuarioId" ON "Perfil" ("UsuarioId");

CREATE UNIQUE INDEX "IX_Promocao_PerfilId" ON "Promocao" ("PerfilId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200617230044_CreateTableUsuario', '3.1.5');

ALTER TABLE "Perfil" DROP CONSTRAINT "FK_Perfil_Usuario_UsuarioId";

ALTER TABLE "Promocao" DROP CONSTRAINT "FK_Promocao_Perfil_PerfilId";

ALTER TABLE "Usuario" DROP CONSTRAINT "PK_Usuario";

ALTER TABLE "Promocao" DROP CONSTRAINT "PK_Promocao";

ALTER TABLE "Perfil" DROP CONSTRAINT "PK_Perfil";

ALTER TABLE "Usuario" RENAME TO "Usuarios";

ALTER TABLE "Promocao" RENAME TO "Promocoes";

ALTER TABLE "Perfil" RENAME TO "Perfis";

ALTER INDEX "IX_Promocao_PerfilId" RENAME TO "IX_Promocoes_PerfilId";

ALTER INDEX "IX_Perfil_UsuarioId" RENAME TO "IX_Perfis_UsuarioId";

ALTER TABLE "Usuarios" ADD CONSTRAINT "PK_Usuarios" PRIMARY KEY ("Id");

ALTER TABLE "Promocoes" ADD CONSTRAINT "PK_Promocoes" PRIMARY KEY ("Id");

ALTER TABLE "Perfis" ADD CONSTRAINT "PK_Perfis" PRIMARY KEY ("Id");

ALTER TABLE "Perfis" ADD CONSTRAINT "FK_Perfis_Usuarios_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE;

ALTER TABLE "Promocoes" ADD CONSTRAINT "FK_Promocoes_Perfis_PerfilId" FOREIGN KEY ("PerfilId") REFERENCES "Perfis" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200617230131_CreateTablePerfil', '3.1.5');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200617230141_CreateTablePromocao', '3.1.5');

