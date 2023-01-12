### Comando select

- É possível ordenar a seleção de tabela utilizando o comando ORDER
ex : SELECT * FROM Clientes
     ORDER BY Nome
     ORDER BY Nome DESC (para ordenar na ordem decrescente)
     ORDER BY Nome, Sobrenome (ordena primeiro por nome e depois por sobrenome)

- O * serve para selecionar tudo, mas é possível selecionar apenas colunas que desejamos
ex: SELECT Nome, Sobrenome, Email FROM Clientes

- O Comando WHERE serve para filtrar informações
ex: SELECT * FROM Clientes
    WHERE Nome = 'Adam' (o padrão sql é com aspas simples)

ou  WHERE Nome = 'Adam' AND Sobrenome = 'Reynolds'
ou  WHERE Nome = 'Adam' OR Sobrenome = 'Reynolds' 
(AND E OR seguem os mesmos principios lógicos da programação "&& e ||")

    SELECT * FROM Clientes
    WHERE Nome LIKE 'G%' (filtra todos com inicial 'G' e o '%' implica que pouco importa o resto)
    também é possivel usar:
    WHERE Nome LIKE '%G%' (filtra todos quem possuem a letra 'G' no nome, pouco importa o que vem antes e depois)