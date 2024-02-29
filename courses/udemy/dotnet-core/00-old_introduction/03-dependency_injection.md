
## Tipos de injeção

### "TRANSIENT"
A cada chamada o objeto que você configurou na injeção será instanciado novamente.

### "SCOPED"
Cria uma nova instância de um mesmo objeto e é compartilhada dentro do ciclo de vida de um mesmo objeto, ou seja, até encerrar a requisição

#### EXEMPLO:
Supondo que haja duas regras de negócio na aplicação que instanciam e utilizam um repository, caso a instância seja do tipo "TRANSIENT" para cada chamada deverá ser instanciado um novo objeto, no caso do "SCOPED", o objeto será o mesmo para as duas chamadas nas regras de negócio.

### "SINGLETON"
Instância uma classe e em todo o ciclo de vida da aplicação a instancia será a mesma.

Utilizar "SINGLETON" pode gerar mais problemas, é preferencial utilizar "SCOPED" pois dura apenas no ciclo de vida da request, logo não gera tantos problemas quanto "SINGLETON" e não ocupa tanto espaço desnecessário como "TRANSIENT".

