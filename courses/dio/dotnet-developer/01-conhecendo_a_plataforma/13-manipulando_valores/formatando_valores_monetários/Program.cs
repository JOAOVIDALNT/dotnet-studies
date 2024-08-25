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

Console.WriteLine(valorMonetario2.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));
/* Aplica uma cultura específica independente da cultura do sistema */

Console.WriteLine(valorMonetario2.ToString("C3")); 
/* 
formata de acordo com o sistema e o número corresponde as casas decimais 
"N4" por exemplo não exibiria o sinal de dólar antes do número e possuiria 4 casas decimais
*/

double porcentagem = .3421;

Console.WriteLine(porcentagem.ToString("P")); // exibe a porcentagem 34.210% ou 34,21% (pt-BR)

int numero = 123456;

Console.WriteLine(numero.ToString("##-##-##")); // exibe 12-34-56
