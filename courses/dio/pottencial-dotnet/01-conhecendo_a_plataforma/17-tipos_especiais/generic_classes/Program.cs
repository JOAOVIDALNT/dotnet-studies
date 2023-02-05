using generic_classes.Models;

MeuArray<int> meuArrayInteiro = new MeuArray<int>();

meuArrayInteiro.AddElementToArray(20);
Console.WriteLine(meuArrayInteiro[0]);
// return: > 20

MeuArray<string> meuArrayString = new MeuArray<string>();

meuArrayString.AddElementToArray("Vinte");
Console.WriteLine(meuArrayString[0]);
// return: > vinte

List<int> list = new List<int>(); // LISTA É UM TIPO GENÉRICO (use f12 to access)