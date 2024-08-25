using classe_object.Models;

Computer c = new Computer();

// APENAS DIGITANDO "c." JÁ SÃO DISPONIBILIZADOS MÉTODOS DA CLASSE OBJECT (ToString(), Equals(), etc..)
// VAMOS SOBREESCREVER O MÉTODO ToString() PELA CLASSE Computer

Console.WriteLine(c.ToString());