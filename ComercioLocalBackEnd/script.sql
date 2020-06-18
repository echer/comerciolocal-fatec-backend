CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "Usuarios" (
    "Id" uuid NOT NULL,
    "Nome" text NOT NULL,
    "DataNascimento" text NULL,
    "Email" text NOT NULL,
    "Senha" text NOT NULL,
    "TelefoneMovel" text NOT NULL,
    "TelefoneFixo" text NULL,
    CONSTRAINT "PK_Usuarios" PRIMARY KEY ("Id")
);

CREATE TABLE "Perfis" (
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
    CONSTRAINT "PK_Perfis" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Perfis_Usuarios_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Promocoes" (
    "Id" uuid NOT NULL,
    "PerfilId" uuid NOT NULL,
    "DataInicio" text NULL,
    "DataFim" text NULL,
    "Descricao" text NOT NULL,
    "MidiaPromocao" text NULL,
    "CupomPromocao" text NULL,
    CONSTRAINT "PK_Promocoes" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Promocoes_Perfis_PerfilId" FOREIGN KEY ("PerfilId") REFERENCES "Perfis" ("Id") ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_Perfis_UsuarioId" ON "Perfis" ("UsuarioId");

CREATE INDEX "IX_Promocoes_PerfilId" ON "Promocoes" ("PerfilId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200618003447_CreateTableUsuario', '3.1.5');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200618003458_CreateTablePerfil', '3.1.5');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200618003508_CreateTablePromocao', '3.1.5');

