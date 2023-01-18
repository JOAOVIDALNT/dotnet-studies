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