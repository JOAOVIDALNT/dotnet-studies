
A partir daqui, iniciaremos com os primeiros testes de unidade.

Para começar, criaremos um novo projeto do tipo xUnit na pasta ~/tests (importante criar a pasta também no File Explorer)
![[Pasted image 20240805054757.png]]

Nosso primeiro projeto será o Validators.Test
![[Pasted image 20240805054804.png]]

#### Common Test Utilities
Também criaremos uma class library para guardar código compartilhado entre testes
![[Pasted image 20240805055020.png]]

### Testes que utilizaremos:
- Testes de unidade para Validators
- Testes de unidade para UseCases
- Testes de integração
- Testes de arquitetura


Testes de unidade devem ser independentes, ou seja, testar isoladamente. Seguindo o padrão dos 3 A's-> Arrange, Act, Assert