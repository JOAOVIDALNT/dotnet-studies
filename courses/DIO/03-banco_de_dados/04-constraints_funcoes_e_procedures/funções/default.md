### Constraint DEFAULT

- Assume um padrão pra uma coluna caso você queira omitir o valor

ex: ALTER TABLE Produtos
    ADD DEFAULT GETDATE() FOR DataCadastro

> AGORA, CASO O VALOR NÃO SEJA PASSADO NA INSERÇÃO NÃO OCORRE ERRO E A COLUNA ASSUME O VALOR PADRÃO