### Comando MAX, MIN E AVG

- Retorna o maior valor, menor valor e média de determinado parâmetro respectivamente.

- MAX
ex: SELECT MAX(Preco) ProdutoMaisCaro FROM Produtos
ou  SELECT MAX(Preco) ProdutoMaisCaroM FROM Produtos WHERE Tamanho = 'M'

- MIN
ex: SELECT MIN(Preco) ProdutoMaisBarato FROM Produtos
ou  SELECT MIN(Preco) ProdutoMaisBaratoP FROM Produtos WHERE Tamanho = 'P'

- AVG
ex: SELECT AVG(Preco) FROM Produtos
ou  SELECT AVG(Preco) FROM Produtos WHERE Tamanho = 'G'
> NENHUMA FORMULA PRECISA OBRIGATORIAMENTE DE NOME