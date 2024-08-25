using System.Globalization;


Dictionary<string, string> estados = new Dictionary<string, string>();
// <Chave, Valor>, você escolhe o tipo do valor
// o primeiro elemento (chave) tem que ser único

estados.Add("SP", "São Paulo");
estados.Add("BA", "Bahia");
estados.Add("MG", "Minas Gerais");

foreach (var item in estados) // KeyValuePair<string, string> é o tipo declarado de dictionary, porém o var reconhece o tipo automaticamente
{
    Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value}");
}

// estados.Add("BA", "Bahia"); // lança uma exceção pois a chave já existe

Console.WriteLine("-----------------------");
estados.Remove("SP");
estados["MG"] = "Minas Gerais - Valor alterado";

foreach (var item in estados)
{
    Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value}");
}

string chave = "BA2";

Console.WriteLine($"Verificando o elemento: {chave}");

if (estados.ContainsKey(chave)) // verificando se a chave existe
{
    Console.WriteLine($"A chave: {chave} já existe.");
}
else
{
    Console.WriteLine($"A chave: {chave} não existe, Adicionando o elemento... ");

    estados.Add($"{chave}", "Bahia");
}

foreach (var item in estados)
{
    Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value}");
}

Console.WriteLine(estados["MG"]); // acessando o elemento