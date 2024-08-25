
Após as alterações, criação e aprovação do pull request e merge, podemos retornar localmente a branch develop, confirmando as alterações.

![[Pasted image 20240722074710.png]]

Podemos também deletar a branch de feature:
![[Pasted image 20240722074838.png]]

E ai então realizar o pull, para trazer as informações remotas:
![[Pasted image 20240722074921.png]]

#### Ajuste
![[Pasted image 20240722075044.png]]
Definir a branch develop como default para que, por padrão, os pull requests sejam sugeridos nela.


#### 2 - Exceptions
```bash
~/.../workspace/MyCookBook ( develop U:7 ?:16 ⊘ )
❯  git flow feature start add-exceptions
Switched to a new branch 'feature/add-exceptions'
M       src/Backend/MyCookBook.API/Controllers/UserController.cs
M       src/Backend/MyCookBook.API/MyCookBook.API.csproj
M       src/Backend/MyCookBook.API/Program.cs
M       src/Backend/MyCookBook.API/appsettings.Development.json
M       src/Backend/MyCookBook.Application/MyCookBook.Application.csproj
M       src/Backend/MyCookBook.Infrastructure/MyCookBook.Infrastructure.csproj
M       src/Shared/MyCookBook.Exceptions/MyCookBook.Exceptions.csproj

Summary of actions:
- A new branch 'feature/add-exceptions' was created, based on 'develop'
- You are now on branch 'feature/add-exceptions'

Now, start committing on your feature. When done, use:

     git flow feature finish add-exceptions


~/.../workspace/MyCookBook ( feature/add-exceptions U:7 ?:16 ⊘ )
❯
```

![[Pasted image 20240722075526.png]]

No azure devops, podemos selecionar o aprovador, assim não precisamos enviar o link para a pessoa:
![[Pasted image 20240722080317.png]]

Também é possível associar a tarefa ao pull request:
![[Pasted image 20240722080435.png]]
Existe a opção de fechar automaticamente tarefas com pr's bem sucedidos.

