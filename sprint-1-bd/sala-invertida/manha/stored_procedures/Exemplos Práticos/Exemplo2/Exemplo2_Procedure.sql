-- Usar banco de dados --
USE RedeSocialGenerica
GO

-- Criar procedure --
CREATE PROCEDURE VazaDSados
	-- Declarar variáveis --
	@Tag VARCHAR(30)

WITH ENCRYPTION -- Ativar criptografia --
AS

-- Execução da procedure --
BEGIN
	SELECT Descricao, Imagem, Username, Nome, Email, Endereco FROM Post
	LEFT JOIN Usuario
	ON Post.UserId = Usuario.UserId

	WHERE Post.Descricao LIKE '%' + @Tag + '%'
END
GO

EXECUTE VazaDados ''
GO

EXEC sp_helptext VazaDados