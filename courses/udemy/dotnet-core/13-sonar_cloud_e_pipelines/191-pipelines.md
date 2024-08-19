#### O que é?
Uma sequência automatizada de processos que serão executados em sequência no nosso código.

### Exemplo

#### Etapas
- Build
- Testes
- Imagem Docker

#### Triggers
Gatilhos para executar um pipeline, por exemplo:
- Pipeline executado através de um `push`
- Pipeline executado através de um `push` em determinada `branch`.
- Pipeline executado através de um agendamento diário, semanal, mensal, condicional ou etc..
- Pipeline executado manualmente.


#### YAML
Pipelines serão configurados dentro de um arquivo YAML.

#### Exemplo
```yaml
name: Build .NET API

trigger:
	branches:
		include:
		  - develop
	paths:
		include:
		  - src/*

pool:
	vmImage: 'ubuntu-latest'

variables:
	buildConfiguration: 'Release'

steps:
	- task: DotNetCoreCLI@2
	  displayName: Build Project
	  inputs:
		  command: 'build'
		  arguments: '--configuration $(buildConfiguration)'
		  
	- script: |
		echo "Success! Your code is so clean, even your mom would be proud!"
```

- Em `triggers->branches->include` colocamos todas as `branches` que queremos envolver no trigger.
- Em paths determinamos que o trigger deve agir sobre uma das `branchs` informadas e que alterou algo dentro da pasta `src/`.
- `vmImage` vai definir em que máquina virtual devemos executar o nosso pipeline, após toda execução as configurações são deletadas e esquecidas.
- em `variables` nós mesmos atribuímos o nome à variável, `ex `: `buildConfiguration`
- em `steps` definimos as etapas através dos hifens.
- em `DotNetCoreCLI@2` é uma tarefa já definida da plataforma de execução dos pipelines, que vai baixar tudo o que é necessário para executar uma aplicação `dotnet`.
- em  `inputs` informamos o comando e os argumentos, incluindo a nossa variável `buildConfiguration`.
- em `script` executamos um comando direto, diferente de uma `task` previamente descrita.
