try 
{
string[] lines = File.ReadAllLines("Archives/letter1.txt"); // file reader do c#

foreach(string line in lines) 
{
    Console.WriteLine(line);
}

} 
catch (FileNotFoundException e) 
{
    Console.WriteLine($"Arquivo não encontrado {e.Message}");
} 
catch (DirectoryNotFoundException e) 
{
    Console.WriteLine($"Caminho da pasta não encontrado {e.Message}");
} 
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally // independe de exceção ou não
{
    Console.WriteLine("Chegou até aqui");
}

