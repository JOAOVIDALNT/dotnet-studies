### Comando JOIN
- Existem vários tipos de JOIN, sendo o mais comum o INNER JOIN


- Serve para ajudar na exibição de duas tabelas que se relacionam, para que não seja necessário fazer 2 SELECTS como no exemplo:

SELECT * FROM Enderecos WHERE IdCliente = 4
SELECT * FROM Clientes WHERE Id = 4

ex: SELECT * FROM Clientes INNER JOIN Enderecos ON Clientes.Id = Enderecos.IdCliente
    WHERE Clientes.Id = 4
> Junta as duas tabelas em uma única linha

SELECT
    Clientes.Nome,
    Clientes.Sobrenome,
    Clientes.Eamil,
    Enderecos.Rua,
    Enderecos.Bairro,
    Enderecos.Cidade,
    Enderecos.Estado
FROM
    Clientes
INNER JOIN Enderecos ON Clientes.Id = Enderecos.IdCliente
WHERE Clientes.Id = 4
> FORMA UMA TABELA COM AS INFORMAÇÕES PEDIDAS

- É possivel encurtar as referências de tabela
SELECT
    C.Nome,
    C.Sobrenome,
    C.Eamil,
    E.Rua,
    E.Bairro,
    E.Cidade,
    E.Estado
FROM
    Clientes C -> nomeia a referencia
INNER JOIN Enderecos E ON C.Id = E.IdCliente
WHERE C.Id = 4

