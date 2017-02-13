--SET STATISTICS IO ON
--SET STATISTICS TIME ON
USE ProcessoDB

SET NOCOUNT ON
DROP TABLE IF EXISTS #T 

SELECT CAST('' AS VARCHAR(MAX)) a INTO #T

TRUNCATE TABLE #T

BULK INSERT #T
FROM 'C:\Users\VitorOta\Documents\Visual Studio 2015\Projects\PS\scripts db\ARQUIVO_IMPORTACAO_USUARIO.txt'
WITH
(
FIRSTROW = 2,
--FIELDTERMINATOR = '\t', /*o arquivo não está formatado, por isso não dá pra usar o FIELDTERMINATOR*/
ROWTERMINATOR = '\n'
)


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

SELECT * FROM Usuario