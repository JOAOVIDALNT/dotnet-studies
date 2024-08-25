### Concatenando colunas

- É possivel, além de exibir as colunas em tabela, concatena-las em uma única linha podendo personaliza-las

ex: SELECT Nome + ', Cor:' + Cor FROM Produtos
ou  SELECT Nome + ', Cor:' + Cor NomeProduto FROM Produtos
                                  '-> nome da coluna

um select normal de tabela seria:
    SELECT Nome, Cor FROM Produtos
