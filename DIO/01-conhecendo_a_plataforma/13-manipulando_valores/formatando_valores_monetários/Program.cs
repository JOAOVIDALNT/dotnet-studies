using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
/* seta a configuração de moeda como en-US (Dólar) 
ou seja: $1,582.70

obs: essa configuração trava a cultura para todo o sistema, enquanto o default
se adapta de acordo com o sistema do computador de acesso.
*/


decimal valorMonetario2 = 1582.70M; 
/* o formatador vai corrigir ponto e virgular para a moeda real 
ou seja: R$ 1.582,70
*/

Console.WriteLine($"{valorMonetario2:C}"); 
/* :C formata para o padrão da moeda de acordo com o sistema */
/* ":" significa que você quer formatar a string | "C" significa Currency (Moeda)*/

