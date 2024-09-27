
A interface do VS mudou e não da mais pra definir a visibilidade pela seleção.
Ao entrar no design e alterar os métodos `internal` para `public`, a alteração não é mantida e é refeita assim que o arquivo `resource` atualiza.

Para resolver o problema, basta abrir as propriedades do arquivo `resource` e na segunda aba, substituir o `ResXFileCodeGenerator` por `PublicResXFileCodeGenerator`: