namespace HotelApp.Models;

public class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public Person(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public Person(string name)
    {
        Name = name;
    }

    public Person()
    {
    }

    public string FullName => $"{Name} {Surname}".ToUpper();
}