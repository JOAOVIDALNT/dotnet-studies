### Stack
- stack é um espaço de memória que armazena váriaveis simples (LIFO)
- Ao término do programa deleta na ordem, começando pelo último a entrar na pilha
- A stack abriga tipos referêcia para objetos armazenados no HEAP

### Heap
- é um espaço na memória que armazena dados mais complexos como instancias de classes
- os dados no heap abrigam uma referência para eles no STACK
- o garbage collector é o responsável por limpar a memória heap, ele executa quando não há referência na stack ao objeto no heap
