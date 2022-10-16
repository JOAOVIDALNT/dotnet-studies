

// CASTING

int teste = Convert.ToInt32("10"); // converte para int convencional a string 
int teste2 = int.Parse("11"); // também converte para int convencional a string
/* a principal diferença entre os dois métodos é que o Convert. converte valor nulo para 0
enquanto o Parse lança uma exceção caso o valor seja nulo */


int inteiro = 5;
string teste3 = Convert.ToString(5);
string teste4 = inteiro.ToString(); // melhor forma de converter para string pois pertence a todos os métodos

// TRY PARSE
// - maneira segura de realizar uma conversão
string h = "15-";
int.TryParse(h, out int i); // caso não consiga converter o a, o inteiro recebe b que por padrão é 0

// cast implicito - realiza o casting automáticamente
int a = 5;
double b = a;
long c = a; 

// inverso
long d = 10;
int e = Convert.ToInt32(d); /* long não cabe em inteiro, ou seja, é necessário o casting manual 
não funciona caso o numéro não seja suportado. ex: long.MaxValue */


// ORDEM DOS OPERADORES
// - funciona como na matemática, prioriza operações e parentêses
double f = 4 / 2 + 2; //return 4
double g = 4 / (2+2); //return 1 
