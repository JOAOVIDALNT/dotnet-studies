### Criando uma nova coluna

- É possivel criar colunas, tanto visualmente quanto através de comandos.

- Para criar através da interface, use botão direito no db, selecione 'design' e insira os dados

- Para criar através de comandos siga o exemplo:

ex: ALTER TABLE Produtos 
    ADD DataCadastro DATETIME2
        '-> column name   '-> column type
> COLUNA CRIADA!

    UPDATE Produtos SET DataCadastro = GETDATE()
    -> SETA DATA E HORA ATUAL PARA TODAS AS LINHAS

    ALTER TABLE Produtos
    DROP COLUMN DataCadastro
> COLUNA APAGADA!

