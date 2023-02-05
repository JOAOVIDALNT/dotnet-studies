
dynamic variavelDinamica = 4;

Console.WriteLine($"Tipo da variável: {variavelDinamica.GetType()}, Valor da variável {variavelDinamica}");
// return: > Tipo da variável: System.Int32, Valor da variável 4

variavelDinamica = "Texto";

Console.WriteLine($"Tipo da variável: {variavelDinamica.GetType()}, Valor da variável {variavelDinamica}");
// return: > Tipo da variável: System.String, Valor da variável Texto

// ASSIM FUNCIONA PARA QUAISQUER OUTROS TIPOS.
// O INTELISENSE DA VARIAVEL DINÂMICA NÃO AJUDA MUITO