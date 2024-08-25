### Constraints

- Constraints são regras que devem ser seguidas para permitir uma inserção em uma tabela.

ex: NOT NULL - Não permite valor nulo
    UNIQUE - Valor único em toda a tabela
    CHECK - Garante uma determinada condição
    DEFAULT - Valor padrão para inserção
    PRIMARY KEY - É uma combinação de NOT NULL e UNIQUE
    FOREIGN KEY - Garante que um registro exista em outra tabela


- OBS: ALT + F1 selecionando o nome da tabela na query exibe infos da tabela 


#### Apagando uma constraint

- Para remover uma constraint, copie o nome dela nas infos da tabela (ALT + F1) e execute a query:

    ALTER TABLE Produtos
    DROP CONSTRAINT UQ_Produtos_7D8FE3B2D9894E32
                        '-> exemplo de nome padrão que a constraint assume caso você não nomeie ela
                            a constraint check tem nome: Check_gender

