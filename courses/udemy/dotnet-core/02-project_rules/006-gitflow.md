
### Estrutura
![[Pasted image 20240416060230.png]]

Para todas as branchs, podemos criar script, para quando houver gatilho (commit) executarmos alguma ação, como por exemplo: criar a imagem e ajustar o ambiente de produção na main e gerar build na dev.

### Tamanho das branches Feature
Criar uma branch feature, por exemplo, para uma regra de login, implica inicialmente alterar nosso endpoint em controllers, nossa regra de negócios e o repositório. Todas essas alterações gerariam um pull request grande. O ideal é criar features pequenas, começando da menor relação para a maior, por exemplo: criar o repositório primeiro, pois não há como quebrar já que as outras funções convocam o repositório e não o contrário.

### Feature Branches
![[Pasted image 20240416061139.png]]
### Release e Hotfix
![[Pasted image 20240416061256.png]]

### Nomes para Branches
![[Pasted image 20240416061655.png]]![[Pasted image 20240416061735.png]]
Pode ser recomendado manter no repositório, pelo menos as 3 últimas Branches release, para manter o histórico.