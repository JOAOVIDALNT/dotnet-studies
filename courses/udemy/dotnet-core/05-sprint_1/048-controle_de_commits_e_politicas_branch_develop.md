
#### 3 - Entidades

```bash
~/.../workspace/MyCookBook ( feature/add-exceptions U:7 ?:16 ⊘ )
❯  git flow feature start add-user-entity
Switched to a new branch 'feature/add-user-entity'
M       src/Backend/MyCookBook.API/Controllers/UserController.cs
M       src/Backend/MyCookBook.API/MyCookBook.API.csproj
M       src/Backend/MyCookBook.API/Program.cs
M       src/Backend/MyCookBook.API/appsettings.Development.json
M       src/Backend/MyCookBook.Application/MyCookBook.Application.csproj
M       src/Backend/MyCookBook.Infrastructure/MyCookBook.Infrastructure.csproj

Summary of actions:
- A new branch 'feature/add-user-entity' was created, based on 'develop'
- You are now on branch 'feature/add-user-entity'

Now, start committing on your feature. When done, use:

     git flow feature finish add-user-entity


~/.../workspace/MyCookBook ( feature/add-user-entity U:6 ?:10 ⊘ )
❯
```

### Algumas configurações
![[Pasted image 20240722082110.png]]
Em gerenciar repositórios, selecionaremos o repositório que queremos administrar alterações

E ai então acessaremos a aba Polices -> develop para configurar aos detalhes da branch
![[Pasted image 20240722082212.png]]


![[Pasted image 20240722082447.png]]
Essas são algumas das configurações disponíveis, vale a pena checar mais alguns casos, como o 'When chages are pushed', que lida com alterações no próprio pull request.

### Politica atualizada
Com as configurações setadas, agora não podemos aprovar e completar nosso próprio pull request, mas podemos definir o 'set auto complete' para que quando alguém aprove, o merge seja realizado:
![[Pasted image 20240722082837.png]]

#### Tela do aprovador
![[Pasted image 20240722083025.png]]

##### Pull request aprovada
![[Pasted image 20240722083059.png]]


#### 4 - Repositorios
```bash
~/.../workspace/MyCookBook ( feature/add-user-entity U:6 ?:10 ⊘ )
❯  git flow feature start add-repositories
Switched to a new branch 'feature/add-repositories'
M       src/Backend/MyCookBook.API/Controllers/UserController.cs
M       src/Backend/MyCookBook.API/MyCookBook.API.csproj
M       src/Backend/MyCookBook.API/Program.cs
M       src/Backend/MyCookBook.API/appsettings.Development.json
M       src/Backend/MyCookBook.Application/MyCookBook.Application.csproj
M       src/Backend/MyCookBook.Infrastructure/MyCookBook.Infrastructure.csproj

Summary of actions:
- A new branch 'feature/add-repositories' was created, based on 'develop'
- You are now on branch 'feature/add-repositories'

Now, start committing on your feature. When done, use:

     git flow feature finish add-repositories


~/.../workspace/MyCookBook ( feature/add-repositories U:6 ?:9 ⊘ )
❯
```

#### 5 - ENUM
```bash
~/.../workspace/MyCookBook ( feature/add-repositories U:6 ?:9 ⊘ )
❯  git flow feature start add-datatype-enum
Switched to a new branch 'feature/add-datatype-enum'
M       src/Backend/MyCookBook.API/Controllers/UserController.cs
M       src/Backend/MyCookBook.API/MyCookBook.API.csproj
M       src/Backend/MyCookBook.API/Program.cs
M       src/Backend/MyCookBook.API/appsettings.Development.json
M       src/Backend/MyCookBook.Application/MyCookBook.Application.csproj
M       src/Backend/MyCookBook.Infrastructure/MyCookBook.Infrastructure.csproj

Summary of actions:
- A new branch 'feature/add-datatype-enum' was created, based on 'develop'
- You are now on branch 'feature/add-datatype-enum'

Now, start committing on your feature. When done, use:

     git flow feature finish add-datatype-enum


~/.../workspace/MyCookBook ( feature/add-datatype-enum U:6 ?:8 ⊘ )
❯ 
```

#### 6 - MAIN CHANGES
```bash
~/.../workspace/MyCookBook ( feature/add-datatype-enum U:6 ?:8 ⊘ )
❯  git flow feature start add-main-changes
Switched to a new branch 'feature/add-main-changes'
M       src/Backend/MyCookBook.API/Controllers/UserController.cs
M       src/Backend/MyCookBook.API/MyCookBook.API.csproj
M       src/Backend/MyCookBook.API/Program.cs
M       src/Backend/MyCookBook.API/appsettings.Development.json
M       src/Backend/MyCookBook.Application/MyCookBook.Application.csproj
M       src/Backend/MyCookBook.Infrastructure/MyCookBook.Infrastructure.csproj

Summary of actions:
- A new branch 'feature/add-main-changes' was created, based on 'develop'
- You are now on branch 'feature/add-main-changes'

Now, start committing on your feature. When done, use:

     git flow feature finish add-main-changes


~/.../workspace/MyCookBook ( feature/add-main-changes U:6 ?:7 ⊘ )
❯
```