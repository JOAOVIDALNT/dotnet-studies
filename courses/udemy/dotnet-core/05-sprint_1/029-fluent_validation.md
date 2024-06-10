
Para validar os dados de entrada, ao invés de fazer através do if's, faremos utilizando a biblioteca FluentValidation.

![[Pasted image 20240610063550.png]]

Através de uma classe, que herda de AbstractValidator. Realizaremos algumas validações:

![[Pasted image 20240610063918.png]]
 - Validação de que não é vazio .NotEmpty(): simula o que faria um if (string.IsNullOrEmpty), retornando uma mensagem de erro padrão de acordo com a validação e propriedade.
 - Validação de que é email: valida se o email informado é um email valido em sua construção, retornando uma mensagem de erro padrão de acordo com a validação e propriedade.
 - Validação de tamanho de senha: valida se a senha segue de acordo com o determinado, retornando uma mensagem de erro padrão de acordo com a validação e propriedade.

Para esta requisição:
![[Pasted image 20240610064630.png]]

Devem ser retornado os seguintes erros de validação:
![[Pasted image 20240610064809.png]]
