
## Configuração Azure Devops

### Passo 1
Após criar a conta, vinculada ao github, configuramos as 'Policies' da organização para que ela aceite projetos públicos, pois ao longo do curso utilizaremos o SonarCloud e ele demanda que o projeto seja público para ser utilizado.

![[Pasted image 20240416051152.png]]


### Passo 2
Definir que o processo default dos projetos será o Agile.
![[Pasted image 20240416051352.png]]

### Passo 3
Instalar as extensões
![[Pasted image 20240416051753.png]]

### Passo 4
Desabilitar alguns processos da Pipeline
![[Pasted image 20240416051923.png]]
Desmarcamos essas opções, para que essa opção esteja disponível na criação do Pipeline:
![[Pasted image 20240416052233.png]]