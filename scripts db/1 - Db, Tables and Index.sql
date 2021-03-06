/*Estou utilizando o EF CodeFirst para criar o banco, por isso, não é necessário executar esse script*/

/*
CREATE DATABASE ProcessoDB
GO

USE ProcessoDB
GO


CREATE TABLE USUARIO(
    ID_USUARIO INT IDENTITY PRIMARY KEY,
    LOGIN VARCHAR(30) NOT NULL,
    NOME VARCHAR(50) NOT NULL,
    EMAIL VARCHAR(70), 
    SENHA VARCHAR(30),
    ATIVO BIT DEFAULT 1,
    DT_INCLUSAO DATETIME DEFAULT GETDATE()
)
GO

CREATE UNIQUE INDEX ix_usuario_login ON USUARIO(LOGIN)
GO


CREATE TABLE OPERACAO_USUARIO(
    ID_OPERACAO_ACESSO INT IDENTITY PRIMARY KEY,
    DT_LOG DATETIME DEFAULT GETDATE(),
    ID_USUARIO INT,
    CONSTRAINT fk_OperacaoUsuario_Usuario FOREIGN KEY (ID_USUARIO) REFERENCES USUARIO(ID_USUARIO)
)
GO

CREATE TABLE PERFIL(
    ID_PERFIL INT IDENTITY PRIMARY KEY,
    NOME VARCHAR(50),
    ATIVO BIT DEFAULT 1
)
GO

CREATE TABLE USUARIO_PERFIL(
    ID_PERFIL INT,
    ID_USUARIO INT,
    ATIVO BIT DEFAULT 1,

    CONSTRAINT fk_UsuarioPerfil_Perfil FOREIGN KEY (ID_PERFIL) REFERENCES PERFIL(ID_PERFIL),
    CONSTRAINT fk_UsuarioPerfil_Usuario FOREIGN KEY (ID_USUARIO) REFERENCES USUARIO(ID_USUARIO),
    CONSTRAINT pk_UsuarioPerfil PRIMARY KEY (ID_PERFIL, ID_USUARIO)
)
GO
*/
