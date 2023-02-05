### Constraint CHECK

- Verifica uma determinada condição

ex: 
> QUEREMOS QUE A COLUNA GÊNERO ACEITE APENAS 3 VALORES: 'F','M' E 'U'
    ALTER TABLE Produtos
    ADD CHECK(Genero =  'U' OR Genero = 'M' OR Genero = 'F')

> É POSSIVEL NOMEAR A CONSTRAINT:
    ALTER TABLE Produtos
    ADD CONSTRAINT Check_gender CHECK(Genero =  'U' OR Genero = 'M' OR Genero = 'F')
