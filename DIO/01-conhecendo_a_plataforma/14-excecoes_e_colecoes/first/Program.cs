string[] lines = File.ReadAllLines("Archives/letter.txt");

foreach(string line in lines) 
{
    Console.WriteLine(line);
}