
Com o `Azure Devops` devidamente configurado e a extensão do `SonarCloud` instalada (aula de configuração do `Azure Devops`), vamos executar o seguinte processo:
![[Pasted image 20240823193010.png]]
![[Pasted image 20240823193056.png]]
![[Pasted image 20240823193132.png]]

### ORDEM DE EXECUÇÃO
Após a criação do `Pipeline`, já podemos ajustar e garantir que a ordem de execução está correta:
![[Pasted image 20240823193241.png]]

### OUTRAS CONFIGURAÇÕES

#### Configurações gerais do Pipeline
Onde definimos configurações como: nome, especificação de sistema e etc..
![[Pasted image 20240823193446.png]]
Observe que:
- utilizamos `windows-latest` pois o `SonarCloud` demanda isso

#### Preparando análise
![[Pasted image 20240823194125.png]]
Em `Prepare analysis on SonarCloud` primeiro vamos adicionar um novo `Service Endpoint`
que recuperaremos em sonarcloud.io:
![[Pasted image 20240823194222.png]]
Após resgatar o `Token` basta criar e nomear o `Service Endpoint`:
![[Pasted image 20240823194408.png]]

![[Pasted image 20240823194530.png]]
Após definido, podemos selecionar a organização e buscar o `Project Key` no `SonarCloud`:
![[Pasted image 20240823194648.png]]
![[Pasted image 20240823194651.png]]

##### VERSÃO
![[Pasted image 20240823194742.png]]
Garantir que a `Task Version` está atualizada em todas as instâncias do `SonarCloud` no agente

#### Configurando `Test`
A única instância `dotnet` que alteraremos é a de `test`, primeiro removendo o path, pois o comando `dotnet test` na raiz do projeto já executa os testes:![[Pasted image 20240823195613.png]]

Depois adicionamos o `Code coverage` que é um recurso disponível apenas no windows:
```text
Code coverage can be collected by adding `--collect "Code coverage"` option to the command line arguments. This is currently only available on the Windows platform.
```
![[Pasted image 20240823195732.png]]

##### TRIGGERS
Na aba `Triggers` habilitaremos a integração continua definiremos que a `branch develop` deve ser a filtrada:
![[Pasted image 20240823200029.png]]
Antes de tudo, é bom conferir se todos os testes estão com a biblioteca `coverlet.collector` que vem por padrão em projetos de testes c#:

![[Pasted image 20240823200105.png]]


#### SALVAR
Após configurar, basta selecionar `salve and queue` e confirmar as configurações:
![[Pasted image 20240823200307.png]]

#### ERRO DE PARALELISMO

![[Pasted image 20240823200754.png]]

Ao executar um `pipeline` em um projeto público no `Azure Devops`, teremos o problema de `paralelismo`, já solicitamos, lá no início do curso a permissão para executar essas `pipelines` à `microsoft`, mas essa permissão só é válida para projetos privados.
![[Pasted image 20240823200616.png]]
Tínhamos definido o projeto como público para que o `SonarCloud` pudesse se conectar, agora que já está conectado podemos voltar.

Uma observação é que o projeto continuará público no `SonarCloud`, ou seja, caso esteja fazendo isso com código confidencial, será necessário pagar a assinatura do `SonarCloud`

#### EXECUTANDO PIPELINE
Após redefinir a configuração de privacidade, basta voltar a página de `Pipelines`, clicar na `Pipeline` que deseja executar, e aguardar.
![[Pasted image 20240823201539.png]]
Após isso, o `SonarCloud` já deve refletir as análises:
![[Pasted image 20240823201704.png]]


<hr>