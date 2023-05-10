### Functions

- Functions são códigos SQL que você pode salvar diretamente no banco de dados, semelhante a uma procedure, mas com usos específicos e limitações, como por exemplo, devem sempre ter um retorno e aceita apenas parâmetros de entrada

ex: 
> QUEREMOS OTIMIZAR O SEGUINTE TRECHO DE CÓDIGO:
    SELECT
    Nome,
    Preco,
    FORMAT(Preco - Preco / 100 * 10, 'N2') PrecoComDesconto -> 'N2' indica o tipo de formatação: 2 casas decimais
    FROM Produtos WHERE Tamanho = 'M'

> CRIANDO FUNCTION PARA DESCONTO
    CREATE FUNCTION CalcularDesconto(@Preco DECIMAL(13,2), @Porcentagem INT)
    RETURNS DECIMAL(13,2) -> tipo de retorno da função

    BEGIN
    RETURN @Preco - @Preco / 100 * @Porcentagem -> retorno da função
    END

> USANDO A FUNCTION CALCULAR DESCONTO
    SELECT
    Nome,
    Preco,
    dbo.CalculcarDesconto(Preco, 10) PrecoComDesconto 
    FROM Produtos WHERE Tamanho = 'M'