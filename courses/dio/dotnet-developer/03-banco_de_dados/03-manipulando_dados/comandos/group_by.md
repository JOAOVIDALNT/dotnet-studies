### Group By

- Agrupar dados para obter informações sobre eles

ex: SELECT Tamanho, 
    COUNT(*) Quantidade    
    FROM Produtos
    GROUP BY Tamanho
> EXIBE AGRUPADO POR TAMANHO
>  TAMANHO  QUANTIDADE
> 1- G         11
> 2- M         11
> 3- P         9
> 4- GG        3
> 5-           1 -> NULL SOLUÇÃO A SEGUIR

    SELECT Tamanho, 
    COUNT(*) Quantidade    
    FROM Produtos
    WHERE Tamanho <> '' -> diferente de vazio
    GROUP BY Tamanho
>  TAMANHO  QUANTIDADE
> 1- G         11
> 2- M         11
> 3- P         9
> 4- GG        3

    SELECT Tamanho, 
    COUNT(*) Quantidade    
    FROM Produtos
    WHERE Tamanho <> '' -> também é possivel usar '!='
    GROUP BY Tamanho
    ORDER BY Quantidade -> PARA ORDENAR (ASC como default, use DESC para descrescente)
>  TAMANHO  QUANTIDADE
> 1- GG        3
> 2- P         9
> 3- M         11
> 4- G         11
