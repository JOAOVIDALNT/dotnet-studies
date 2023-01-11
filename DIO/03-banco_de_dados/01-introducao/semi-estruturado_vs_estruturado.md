### Semi estruturado
ex: documento Json
- Segue algumas regras como campo dos dados, valor seguido de nome mas não segue regras tão rigidas quanto as regras de tabelas estruturadas dos bancos relacionais. Pode conter mais atributos sobre um do que sobre outro, assim como pode conter atributos diferentes, e os dados em si são flexiveis para receber valores
ex:
{
    "Id": 1,
    "Preço": "25.00",
    "Desconto": null
}
{
    "Id": 2,
    "Preço": 37.00,
    "Desconto": 10,
    "Cupom": "888"
}

## Estruturado
ex: Tabelas de sql
- é muito menos flexível do que o semi-estruturado, por exemplo, se quisessemos adicionar a coluna cupom à tabela, todos os usuários teriam o atributo cupom e o tipo das colunas também tem que ser estabelecidos, se definirmos preço como decimal, não podemos receber o mesmo em string e vice-versa.