--SET STATISTICS IO ON
--SET STATISTICS TIME ON
USE ProcessoDB

SET NOCOUNT ON
--DROP TABLE IF EXISTS #T

SELECT CAST('' AS VARCHAR(MAX)) a INTO #T

BULK INSERT #T
FROM 'C:\Users\VitorOta\Documents\Visual Studio 2015\Projects\PS\scripts db\ARQUIVO_IMPORTACAO_USUARIO.TXT'--'C:\Users\vitor.ota\Documents\PS\scripts db\ARQUIVO_IMPORTACAO_USUARIO.TXT'--
WITH
(
FIRSTROW = 2,
--FIELDTERMINATOR = '\t', /*o arquivo n�o est� formatado, por isso n�o d� pra usar o FIELDTERMINATOR*/
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

WHILE @@FETCH_STATUS = 0
BEGIN


IF(@row  <> '')
BEGIN
	SET @left = CHARINDEX(' ',@row)
	SET @right = CHARINDEX(' ', REVERSE(@row))
	SET @login = LEFT(@row, @left-1)
	SET @email = RIGHT(@row, @right-1)
	SET @row = LTRIM(SUBSTRING(@row,@left,LEN(@row)))
	SET @right = CHARINDEX(' ', REVERSE(@row))
	SET @nome = RTRIM(LEFT(@row,LEN(@row)-@right))
	
	IF((SELECT COUNT(*) FROM USUARIO WHERE LOGIN = @login)=0)
    BEGIN
        INSERT INTO Usuario(login, nome, email) VALUES(@login,@nome, @email)
    END
    ELSE
        UPDATE Usuario SET nome=@nome, email = @email WHERE login = @login

     /*--confiando no �ndice do login -- n�o rola, se algum campo der biziu n�o vou saber;
	BEGIN TRY
	INSERT INTO Usuario(login, nome, email) VALUES(@login,@nome, @email)
	END TRY
	BEGIN CATCH
	UPDATE Usuario SET nome=@nome, email = @email WHERE login = @login
	END CATCH*/
END	


FETCH NEXT FROM mCURSOR INTO @row
END


CLOSE mCursor
DEALLOCATE mCursor

DROP TABLE #T


SELECT * FROM Usuario