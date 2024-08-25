O middleware para a cultura vai interceptar a requisição sempre que o aplicativo solicitar informação da API.


### Estrutura
Vamos criar, na API, uma pasta 'Middleware' e dentro dela, teremos a classe com o nome de nossa escolha, nesse caso 'CultureMiddleware'.

![[Pasted image 20240619061951.png]]

Embora o nome da classe seja de nossa escolha, o método principal dela, deve ter um nome e tipo padrão:
![[Pasted image 20240619062051.png]]

### Configuração
Para utilizar a classe como um Middleware, basta adicionar essa opção no nosso program.cs:
![[Pasted image 20240619062221.png]]

Assim então, podemos realizar as alterações com o Invoke()
![[Pasted image 20240619062959.png]]

Para esse caso, recuperamos a cultura através do context e definimos uma nova cultura e cultura de UI.

Para reuso de código, podemos instanciar o 'CultureInfo' apenas uma vez:
![[Pasted image 20240619063209.png]]

### Fluxo
É importante informar no Middleware quando a aplicação deve seguir, para isso utilizaremos o 'RequestDelegate' (Task que representa um processo de requisição finalizado).

Instanciaremos o 'RequestDelegate' no construtor e utilizaremos no final do método 'Invoke'
![[Pasted image 20240619063842.png]]

Utilizaremos o Postman, para que possamos alterar o valor dos headers com facilidade. Como no exemplo:
![[Pasted image 20240619064355.png]]

Ao utilizar qualquer idioma definido no nosso communication, o culture info deve se adaptar e trazer a mensagem tratada.

Para idiomas válidos e não implementados, o idioma padrão será retornado.


### Possíveis problemas
Não foi o meu caso, mas é possível que uma configuração do dotnet barre a troca de cultura, para ajustar isso, basta no .csproj declarar a tag 'InvariantGlobalization' como falsa:
![[Pasted image 20240619064742.png]]