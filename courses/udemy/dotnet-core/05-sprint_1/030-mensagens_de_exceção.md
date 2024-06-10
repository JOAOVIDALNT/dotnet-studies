
Para controlar as mensagens de exceção, podemos utilizar o .WithMessage("message") do FluentValidation, como nesse exemplo:
![[Pasted image 20240610072030.png]]

No caso do nosso projeto, para um controle melhor de linguagem, utilizaremos dentro do projeto de Exceptions arquivos do tipo 'ResourceItem' com as mensagens de validação:
![[Pasted image 20240610072244.png]]

Observe que: o arquivo tipo 'Resource' é um arquivo de chave e valor, poderemos referenciar ele em outros lugares através da chave e globalizar retornos iguais.

Além disso, podemos ter diferentes arquivos resource, especificando diferentes idiomas, por exemplo: 'ResourceMessagesException.pt-BT.resx'. Neste caso estamos especificando o arquivo que queremos acessar quando a região de acesso for o Brasil, também poderíamos abstrair para caso quiséssemos considerar apenas o idioma, como estamos fazendo com o francês, apenas definindo o '.fr.resx'.

No fim, podemos utilizar a referência do arquivo resource para definir o retorno:
![[Pasted image 20240610072756.png]]
