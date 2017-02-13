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
/*Procedure importar txt (considerando que o arquivo passado como parametro terá a mesma estrutura do ARQUIVO_IMPORTACAO_USUARIO.txt)*/
CREATE PROCEDURE IMPORTAR_TXT @path varchar(max)
AS

SET NOCOUNT ON
DROP TABLE IF EXISTS #T 

SELECT CAST('' AS VARCHAR(MAX)) a INTO #T

TRUNCATE TABLE #T

EXEC('BULK INSERT #T
FROM '''+@path+
''' WITH
(
FIRSTROW = 2,
--FIELDTERMINATOR = ''\t'', /*o arquivo não está formatado, por isso não dá pra usar o FIELDTERMINATOR*/
ROWTERMINATOR = ''\n''
)')



DECLARE @row VARCHAR(MAX)

DECLARE @login VARCHAR(MAX)
DECLARE @nome VARCHAR(MAX)
DECLARE @email VARCHAR(MAX)

DECLARE @left INT
DECLARE @right INT


DECLARE mCursor CURSOR FOR
SELECT LTRIM(RTRIM(a)) FROM #T

OPEN mCursor
FETCH NEXT FROM mCURSOR INTO @row

WHILE @@FETCH_STATUS =0
BEGIN


	SET @left = CHARINDEX(' ',@row)
	SET @right = CHARINDEX(' ', REVERSE(@row))
	SET @login = LEFT(@row, @left-1)
	SET @email = RIGHT(@row, @right-1)
	SET @row = LTRIM(SUBSTRING(@row,@left,LEN(@row)))
	SET @right = CHARINDEX(' ', REVERSE(@row))
	SET @nome = RTRIM(LEFT(@row,LEN(@row)-@right))
	
	--confiando no índice do login
	BEGIN TRY
	INSERT INTO Usuario(login, nome, email) VALUES(@login,@nome, @email)
	END TRY
	BEGIN CATCH
	UPDATE Usuario SET nome=@nome, email = @email WHERE login = @login
	END CATCH
	


FETCH NEXT FROM mCURSOR INTO @row
END


CLOSE mCursor
DEALLOCATE mCursor
GO