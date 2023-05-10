### Comando COUNT
- Retorna a quantia de um dado parametrizado, útil para quando só se quer saber a quantidade de um dado específico.

ex: SELECT COUNT(*) FROM Produtos (retorna apenas a quantidade de linhas)
    SELECT COUNT(*) QuantidadeProdutos FROM Produtos (é possivel nomear a tebela de retorno)
    SELECT COUNT(*) QuantidadeProdutosTamM FROM Produtos WHERE Tamanho = 'M' 
                        '-> nome da tabela de resultado
