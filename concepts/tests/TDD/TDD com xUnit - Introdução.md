
### Problemas
![[Pasted image 20240609130002.png]]Com uma cobertura de testes, por mais que a estrutura do código seja confusa, você consegue testar se as alterações que você realizou na regra de negócios não irá impactar em outros lugares do código.


### 3 REGRAS DO TDD
![[Pasted image 20240609140346.png]]
- Devemos escrever nosso código de testes antes mesmo da produção.


![[Pasted image 20240609140445.png]]

![[Pasted image 20240609140504.png]]

O TDD implementa o conceito de "Tests first", orientando que primeiro montamos os testes, que falharão pois não existe regra de negócio e ai então vamos criamos as regras.

### Prática
##### Sistema de gerenciamento de Tarefas Inteligente
###### Cadastro de tarefas:
Os usuários podem criar tarefas manualmente ou importá-las de outras fontes, como e-mails ou aplicativos de calendário. Cada tarefa pode incluir detalhes como título, descrição, data de vencimento, prioridade e etiquetas.

