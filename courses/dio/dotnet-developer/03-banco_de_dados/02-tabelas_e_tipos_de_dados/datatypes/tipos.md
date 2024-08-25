### Data Types
https://www.w3schools.com/sql/sql_datatypes.asp

#### String Data Types

- String possui inúmeros tipos de representação, os mais comuns são char(n) e varchar(n), sendo varchar o mais usado e indicado

- char(n) é usado quando se tem certeza do tamanho do dado informado ex: siglas de estados brasileiros, é sábido que possuem 2 caracteres, então se define um char(2) -> um char de 2 caracteres

- varchar(n) é usado quando o número de caracteres esperado é variável ex: é aconselhado, para nomes de pessoas usar o varchar(200) e para email varchar(255).

#### Int Data Types

- Na maior parte do tempo usaremos bit -> para representar um booleano
                                   int -> para inteiro
                                   bigint -> para inteiros de até 8bytes
                                   decimal -> para valores monetários

#### Date and Time Data Types

- é recomendado usar o datetime2 pois usa até menos bytes do que datetime e abrange uma aréa maior de tempo, além de ser mais preciso:
datetime - de 01/01/1753 até 31/12/9999 com precisão de 3.33 milesegundos
datetime2 - de 01/01/0001 até 31/12/9999 com precisão de 100 nanosegundos




