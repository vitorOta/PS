USE ProcessoDB
GO

CREATE TRIGGER tg_alteracaoUsuarioLog
ON USUARIO
AFTER UPDATE
AS 
    INSERT INTO OPERACAO_USUARIO (ID_USUARIO) 
        SELECT ID_USUARIO FROM Inserted

GO
--------------------------------------------------------------------------------------------------------

CREATE PROCEDURE CREATE_USUARIO @login varchar(30), @nome varchar(50), @email varchar(70), @senha varchar(30)
AS 
	INSERT INTO USUARIO (LOGIN, NOME, EMAIL, SENHA) VALUES (@login, @nome, @email, @senha)
GO

--------------------------------------------------------------------------------------------------------
CREATE PROCEDURE READ_USUARIO @id INT
AS 
	SELECT * FROM USUARIO WHERE ID_USUARIO = @id
GO

--------------------------------------------------------------------------------------------------------
/*a procedure de UPDATE impede setar valores nulos, mas achei melhor fazer assim, pra permitir passar somente os valores das colunas desejadas*/
CREATE PROCEDURE UPDATE_USUARIO @login varchar(30) = NULL, @nome varchar(50) = NULL, @email varchar(70) = NULL, @senha varchar(30) = NULL, @ativo bit = NULL, @id  int
AS 
	UPDATE USUARIO SET LOGIN = ISNULL(@login, LOGIN), NOME = ISNULL(@nome, NOME), EMAIL= ISNULL(@email, EMAIL), SENHA = ISNULL(@senha, SENHA), ATIVO = ISNULL(@ativo, ATIVO)  WHERE ID_USUARIO = @id
GO

--------------------------------------------------------------------------------------------------------
CREATE PROCEDURE DELETE_USUARIO @id INT
AS 
	DELETE FROM USUARIO WHERE ID_USUARIO = @id
GO

--------------------------------------------------------------------------------------------------------

