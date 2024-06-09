Um teste unitário, tem como objetivo testar uma parte isolada do seu software e ele não deve depender, de forma alguma, de algum recurso externo (como uma API ou base de dados). Qualquer coisa que dependa pode até ser um teste, mas não um teste unitário.


![[Pasted image 20240609122251.png]]
	Este é um exemplo do escopo padrão de um projeto XUNIT de teste.
	Repare que para os testes, é importante e anotação [Fact], para que o framework entende que o método é um teste.
	Também é importante referenciar o projeto principal nas dependências do projeto de teste.


### Escopo de Teste
![[Pasted image 20240609123134.png]]

#### Arrange
Preparação do teste, onde são preparados variáveis e objetos a serem testados.
#### Act
Gatilho do teste, área onde disparamos o método a ser testado.
#### Assert
Verificação do teste, área onde verificamos para garantir que o teste deu certo.

- É importante manter a delimitação das áreas. Esse é um caso de teste pequeno, mas para testes maiores a organização vai ser de extrema importancia.

### Nomemclatura

A sugestão é utilizar o BDD (Behavior Driven Development), nesse caso de testes o escopo da nomemclatura do método é definido com o seguinte padrão: 
*Given_When_Then*

#### DisplayName
![[Pasted image 20240609124443.png]]
Utilizado para exibir no explorador de maneira mais amigável.