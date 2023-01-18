### Stored Procedures

- Stored Procedures são códigos SQL que você pode salvar diretamente no banco de dados, permitindo assim aproveitar um script comumente usado.

> É POSSIVEL CRIAR UMA PROCEDURE PARA INSERIR NOVOS DADOS NA TABELA conforme exemplo:
    CREATE PROCEDURE InserirNovoProduto 
    @Nome varchar(255),
    @Cor varchar(50),
    @Preco decimal,
    @Tamanho varchar(5),
    @Genero char(1)

    AS 

    INSERT INTO Produtos(Nome, Cor, Preco, Tamanho, Genero)
    VALUES(@Nome, @Cor, @Preco, @Tamanho, @Genero)

> EXECUTANDO A PROCEDURE
    EXEC InserirNovoProduto
    'Novo Produto',
    'Colorido',
    50,
    'G',
    'U'

> PODE-SE TAMBÉM NOMEAR NA INSTANCIA ex:
    EXEC InserirNovoProduto
    @Nome = 'Novo Produto',
    @Cor = 'Colorido',
    @Preco = 50,
    @Tamanho = 'G',
    @Genero = 'U'


> PROCEDURE COM SELECT
    CREATE PROCEDURE ObterProdutosPorTamanho
    @TamanhoProduto varchar(5)

    AS

    SELECT * FROM Products WHERE Tamanho = @TamanhoProduto

> F5 PARA CRIAR A PROCEDURE

    EXEC ObterProdutosPorTamanho 'M'

> NEM TODA PROCEDURE PRECISA TER PARÂMETRO exemplo:
    CREATE PROCEDURE ObterTodosProdutos
    AS 
    SELECT * FROM Produtos  
