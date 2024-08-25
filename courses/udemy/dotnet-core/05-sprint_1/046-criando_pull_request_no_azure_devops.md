
### Problema
![[Pasted image 20240722070418.png]]
Ao todo, são 33 alterações na branch develop desde o último commit. O problema é que não devemos subir tantas alterações assim de uma só vez, para que a aprovação de idealmente o que seria um pull request não ficar comprometida.

#### Importância do Pull Request
Nesse tipo de operação, dentro de uma empresa, os desenvolvedores tem muito a ganhar. Tanto a nível de integridade do código, quanto a nível de aprendizagem. Pois se eu identifico algo que pode ser melhor implementado em um pull request, o criador do pull request vai aprender algo comigo que talvez ele não conheça.

Pull request não deve demanda explicação, ou seja, em um ambiente de trabalho, enviar um pull request e ter que explicar para o outro desenvolvedor significa que tem algo errado. Pull request é sobre ponto de vista, a explicação polui isso.
Pull request grande também não devem ser considerados. O ideal é dividir as alterações, bem como faremos aqui:

### Dividindo os commits
#### Ordem de prioridade
![[Pasted image 20240722071308.png]]
Devemos garantir que a branch develop nunca quebre, ou seja, na hora de dar merge nas alterações devemos seguir uma ordem que considera primeiro as alterações que não dependem de outras, ex: não podemos subir de primeira a regra de negócio, considerando que ela depende de alterações no repositório, nas interfaces de Domain, na configuração do AutoMapper e etc..

##### 1 - Communication

```bash
~/.../workspace/MyCookBook ( develop ↑1 U:7 ?:17 ⊘ )
❯  git flow feature start add-response-error
Branches 'develop' and 'origin/develop' have diverged.
And local branch 'develop' is ahead of 'origin/develop'.
Switched to a new branch 'feature/add-response-error'
M       src/Backend/MyCookBook.API/Controllers/UserController.cs
M       src/Backend/MyCookBook.API/MyCookBook.API.csproj
M       src/Backend/MyCookBook.API/Program.cs
M       src/Backend/MyCookBook.API/appsettings.Development.json
M       src/Backend/MyCookBook.Application/MyCookBook.Application.csproj
M       src/Backend/MyCookBook.Infrastructure/MyCookBook.Infrastructure.csproj
M       src/Shared/MyCookBook.Exceptions/MyCookBook.Exceptions.csproj

Summary of actions:
- A new branch 'feature/add-response-error' was created, based on 'develop'
- You are now on branch 'feature/add-response-error'

Now, start committing on your feature. When done, use:

     git flow feature finish add-response-error


~/.../workspace/MyCookBook ( feature/add-response-error U:7 ?:17 ⊘ )
❯
```

Ao iniciar o git flow, as alterações já vem pra branch atual, sendo assim adicionaremos a fase 'STAGED' as alterações de response error em Communication:

##### STAGE
![[Pasted image 20240722072109.png]]

##### COMMIT
![[Pasted image 20240722072317.png]]

##### PUSH
![[Pasted image 20240722072334.png]]
![[Pasted image 20240722072421.png]]

#### Algumas conferências no Azure Devops
Garantir que o acesso dos usuários em Organization settings -> Users, esteja como Basic para que eles enxerguem os pull requests:
![[Pasted image 20240722072659.png]]
Além disso, garantir que o usuário esteja no time do projeto em Project settings -> Teams -> Project

### Criando pull request
![[Pasted image 20240722073409.png]]

Através da aba 'Pull Requests' podemos enxergar as alterações feitas e criar pull requests delas.

![[Pasted image 20240722073459.png]]
Lembrar de ajustar a branch de merge.

Ao enviar o pull request, ele ficará aberto para aprovação, onde através da aba Files, aprovadores podem realizar comentários que iniciam um chat local
![[Pasted image 20240722074134.png]]
![[Pasted image 20240722074220.png]]

### Aprovação e complete
![[Pasted image 20240722074324.png]]

Após aprovado, podemos realizar o complete, confirmando o tipo de merge e subindo a alteração:

![[Pasted image 20240722074456.png]]