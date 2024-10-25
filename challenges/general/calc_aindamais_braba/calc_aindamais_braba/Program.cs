var soma = 0;

for (int i = 101; i <= 200; i++)
{
    if (i.Mod())
        soma += i;
}
Console.WriteLine(soma);

public static class Extension
{
    public static bool Mod(this int num)
    {
        return num % 2 != 0;
    }
}