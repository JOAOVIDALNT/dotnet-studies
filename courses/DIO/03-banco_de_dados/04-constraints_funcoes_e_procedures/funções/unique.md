### Função Unique

- Define que um dado em coluna deve ser único

> DETERMINANDO UMA COLUNA COMO UNIQUE
    ALTER TABLE Produtos
    ADD UNIQUE(Nome)
> A COLUNA NOME EM PRODUTOS AGORA SÓ ACEITA NOMES ÚNICOS

- O comando UNIQUE é ideal para colunas tipo documento de indentificação, etc..