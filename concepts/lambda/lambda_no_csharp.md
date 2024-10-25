As expressões lambda em C# são uma forma concisa de representar funções anônimas. Elas permitem criar métodos inline que podem ser usados como argumentos para outras funções, facilitando a programação funcional e o uso de LINQ (Language Integrated Query).

### Estrutura de uma Lambda

A estrutura básica de uma expressão lambda é a seguinte:
```csharp
(parameters) => expression_or_statement_block
```

- **`parameters`**: Uma lista de parâmetros, que pode ser vazia, ter um único parâmetro sem tipo explícito ou múltiplos parâmetros.
- **`=>`**: O operador "lambda" que separa os parâmetros da expressão.
- **`expression_or_statement_block`**: O corpo da lambda, que pode ser uma única expressão ou um bloco de código.

### Exemplos

#### 1. Lambda com um único parâmetro

Se você tiver um único parâmetro, pode omitir os parênteses:
```csharp
Func<int, int> square = x => x * x;

int result = square(5); // result = 25
```
Observe que:
- o último parâmetro de `Func` define o retorno.

#### 2. Lambda com múltiplos parâmetros

Para múltiplos parâmetros, você precisa usar parênteses:
```csharp
Func<int, int, int> add = (x, y) => x + y;

int sum = add(5, 10); // sum = 15
```

#### 3. Lambda com um bloco de instruções

Se a lógica for mais complexa, você pode usar um bloco de instruções com chaves:

```csharp
Func<int, int, int> subtract = (x, y) => {
    int result = x - y;
    return result;
};

int difference = subtract(10, 5); // difference = 5
```

### Retornos de Lambda

A expressão lambda pode retornar diferentes tipos, dependendo do que você define como tipo de retorno da função que a está utilizando. Abaixo estão alguns exemplos de possíveis retornos:

1. **Tipo explícito**: Quando você define o tipo de retorno, como `Func<int, int>` (que retorna um `int`).
2. **Tipo implícito**: Quando o compilador infere o tipo de retorno da expressão, como em `Predicate<string>` que retorna um `bool`.