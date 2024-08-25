Após, alterar as informações, assim que fizermos um `push` na `branch develop`, o pipeline executará

```bash
~/.../workspace/MyCookBook ( feature/fix-sonar-metrics ✓ )
❯  git flow feature finish fix-sonar-metrics
Switched to branch 'develop'
Your branch is up to date with 'origin/develop'.
Updating 5abaeef..83daae5
Fast-forward
 src/Backend/MyCookBook.API/Filters/ExceptionFilter.cs               | 6 +++---
 src/Backend/MyCookBook.API/Middleware/CultureMiddleware.cs          | 4 ++--
 src/Backend/MyCookBook.API/Program.cs                               | 2 +-
 .../Services/Cryptography/PasswordEncrypter.cs                      | 2 --
 .../MyCookBook.Infrastructure/DependencyInjectionExtension.cs       | 2 +-
 tests/UseCases.Test/User/Register/RegisterUserUseCaseTest.cs        | 2 +-
 tests/WebApi.Test/User/Register/RegisterUserTest.cs                 | 2 +-
 7 files changed, 9 insertions(+), 11 deletions(-)
Deleted branch feature/fix-sonar-metrics (was 83daae5).

Summary of actions:
- The feature branch 'feature/fix-sonar-metrics' was merged into 'develop'
- Feature branch 'feature/fix-sonar-metrics' has been locally deleted
- You are now on branch 'develop'


~/.../workspace/MyCookBook ( develop ↑1 ✓ )
❯  git push
Enumerating objects: 48, done.
Counting objects: 100% (48/48), done.
Delta compression using up to 8 threads
Compressing objects: 100% (19/19), done.
Writing objects: 100% (25/25), 1.79 KiB | 918.00 KiB/s, done.
Total 25 (delta 13), reused 0 (delta 0), pack-reused 0
remote: Analyzing objects... (25/25) (6 ms)
remote: Validating commits... (1/1) done (0 ms)
remote: Storing packfile... done (81 ms)
remote: Storing index... done (39 ms)
To https://dev.azure.com/joaovidal/MyCookBook/_git/MyCookBook
   5abaeef..83daae5  develop -> develop
```

![[Pasted image 20240823212805.png]]

### RECOMENDAÇÃO
Para a continuação do curso, sempre confira as métricas do `SonarCloud` a cada alteração. O Werley fará só no fim, mas ele já está habituado.