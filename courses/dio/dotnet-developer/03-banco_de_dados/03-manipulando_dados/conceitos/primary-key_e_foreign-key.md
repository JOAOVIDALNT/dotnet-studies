### Primary Key (ou chave primária)

- Chave única que identifica cada registro na tabela.

- É possivel setar primary key pela interface, basta ir em desing com botão direito sobre o db clicar no id com botão direito e setar como pk.

### Foreign Key (ou chave estrangeira)

- Chave que identifica um registro existente em outra tabela.

Em um exemplo do tipo onde temos uma tabela para informações do Cliente e outra para o Endereço
a chave estrangeira está na tabela Endereço como coluna IdCliente.
É um apontamento para outra tabela.

##### Criando a tabela Enderecos com FK para Clientes

CREATE TABLE Enderecos (
	Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdCliente int NULL,
	Rua varchar(255) NULL,
	Bairro varchar(255) NULL,
	Cidade varchar(255) NULL,
	Estado char(2) NULL,

	CONSTRAINT FK_Enderecos_Clientes FOREIGN KEY(IdCliente) REFERENCES Clientes(Id)
               '-> nome da restrição '-> tipo da restrição  '-> a quem referencia
                                         + coluna que fara referencia
> CONSTRAINT SIGNIFICA 'RESTRIÇÃO'
    )

INSERT INTO Enderecos VALUES (4, 'Rua teste', 'Bairro teste', 'Cidade teste', 'SP')
                               '-> IdCliente 4

SELECT * FROM Enderecos WHERE IdCliente = 4
SELECT * FROM Clientes WHERE Id = 4