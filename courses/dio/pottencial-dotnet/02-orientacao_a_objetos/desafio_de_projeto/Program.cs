using desafio_de_projeto.Models;

Console.WriteLine("--- iPhone ---");
iPhone iphone = new iPhone("99999", "14 Pro", "000", 64);
iphone.RecebendoLigação();
iphone.Ligar();
iphone.InstalarApp("Instagram");


Console.WriteLine("--- Nokia ---");
Nokia nokia = new Nokia("66666", "N10 Max", "888", 128);
nokia.RecebendoLigação();
nokia.Ligar();
nokia.InstalarApp("Facebook");