try 
{
string[] lines = File.ReadAllLines("Archives/letter1.txt"); // file reader do c#

foreach(string line in lines) 
{
    Console.WriteLine(line);
}

} catch(Exception e) 
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("Chegou até aqui");