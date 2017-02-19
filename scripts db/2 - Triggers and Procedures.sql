USE ProcessoDB
GO


/*Trigger log alteração*/
CREATE TRIGGER tg_alteracaoUsuarioLog
ON USUARIO
AFTER UPDATE
AS 
    INSERT INTO OPERACAO_USUARIO (ID_USUARIO) 
        SELECT ID_USUARIO FROM Inserted

GO
--------------------------------------------------------------------------------------------------------

/*Procedure create Usuario*/
CREATE PROCEDURE CREATE_USUARIO @login varchar(30), @nome varchar(50), @email varchar(70), @senha varchar(30)
AS 
	INSERT INTO USUARIO (LOGIN, NOME, EMAIL, SENHA) VALUES (@login, @nome, @email, @senha)
GO

--------------------------------------------------------------------------------------------------------
/*Procedure List Usuarios*/
CREATE PROCEDURE LIST_USUARIOS
AS 
	SELECT * FROM USUARIO
GO

--------------------------------------------------------------------------------------------------------
/*Procedure read Usuario*/
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
/*Procedure delete Usuario*/
CREATE PROCEDURE DELETE_USUARIO @id INT
AS 
	DELETE FROM USUARIO WHERE ID_USUARIO = @id
GO

--------------------------------------------------------------------------------------------------------
/*Procedure exportar txt (o arquivo deve ter permissão de escrita !!!)*/
CREATE PROCEDURE EXPORTAR_USUARIOS @path varchar(max)
AS

EXEC sp_configure 'show advanced option',1
reconfigure

EXEC sp_configure 'xp_cmdshell',1
reconfigure


DECLARE @L VARCHAR(4);
DECLARE @N VARCHAR(4);
DECLARE @E VARCHAR(4);
SELECT @L=MAX(LEN(LOGIN)) +1 , @N=MAX(LEN(NOME))+1 , @E=MAX(LEN(EMAIL))+1  FROM Usuario

DECLARE @command VARCHAR(8000) = 'bcp "SELECT ''USUARIOS FRANQUIA'' AS x UNION ALL SELECT Login + REPLICATE('' '',' + @L  + '-LEN(LOGIN)) + Nome + REPLICATE('' '',' + @N +'-LEN(Nome)) + Email +REPLICATE('' '','+ @E +'-LEN(Email)) AS x FROM ProcessoDB.dbo.Usuario" queryout %temp%/ARQUIVO_IMPORTACAO_USUARIO.txt -c -T'
--select @command
EXEC xp_cmdshell @command


EXEC sp_configure 'xp_cmdshell',0
reconfigure

EXEC sp_configure 'show advanced option',0
reconfigure



GO