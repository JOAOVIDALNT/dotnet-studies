using System.Globalization;

DateTime data = DateTime.Now;


Console.WriteLine(data);
Console.WriteLine(data.ToString("dd/MM/yyyy HH:mm")); // 04
Console.WriteLine(data.ToString("dd/M/yyyy HH:mm")); // 4
Console.WriteLine(data.ToString("dd/M/yyyy hh:mm")); // formato 12h

Console.WriteLine(data.ToShortDateString()); // apenas data
Console.WriteLine(data.ToShortTimeString()); // apenas hora

// CONVERTER STRING PRA DATE TIME
DateTime data2 = DateTime.Parse("22/12/2022 19:00");
Console.WriteLine(data2);
/* Caso a data não seja válida ex: "32/12/2022" retornará um excepcion */

// DATETIME COM TRYPARSE
string dataString = "2022-12-12 20:50";

DateTime data3 = DateTime.Parse(dataString); // caso a data seja inválida gera um erro
Console.WriteLine(data3);
// tenta parsear (converter) o datastring que pode não ser válido para o dateTime
bool success = DateTime.TryParseExact(dataString, // componente 
                         "yyyy-MM-dd HH:mm", // formato exato que ele espera
                          CultureInfo.InvariantCulture, // independe de cultura pois ja foi definico o que se espera no formato a cima
                           DateTimeStyles.None, // também não é setado pois já fora definido
                            out DateTime data4); // método de saída 

Console.WriteLine(data4); // caso a data seja inválida ex "2022-14-20" não lança exceção apenas exibe um valor padrão e não encerra o programa

/* O TRYPARSEEXACT RETORNA UM BOOLEANO */


// VALIDANDO O RETORNO COM TRYPARSE
if (success) 
{
    Console.WriteLine($"Convertido com sucesso Data: {data4}");
}
else 
{
    Console.WriteLine($"{dataString} não é uma data válida");
}



