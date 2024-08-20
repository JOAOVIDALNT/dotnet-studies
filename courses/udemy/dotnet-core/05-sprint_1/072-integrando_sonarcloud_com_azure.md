
#### Configuração do `SonarCloud` com  o `AzureDevops`

Ao entrar no `SonarCloud` com o login do `AzureDevops` teremos a opção de associar a organização através de um `access token`:
![[Pasted image 20240819203058.png]]

Para recuperar o `access token`, basta acessar `User settings -> Personal access token` no na sua organização do `AzureDevops` e selecionar o opção `new token` para criar um.
![[Pasted image 20240819203342.png]]
A visualização desse token, para cópia só ficará disponível no instante após a criação, depois disso ele constará como um token salvo mas inacessível.

![[Pasted image 20240819203501.png]]
Após vincular o token, basta selecionar o projeto e por fim definir algumas configurações, como plano e orientação de validação, no caso dessa orientação utilizamos `Previous version` para que o `SonarCloud` compare com o `commit` anterior.

![[Pasted image 20240819203531.png]]