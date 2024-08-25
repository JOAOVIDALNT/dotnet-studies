using System;
using extensions_methods.Models;

// EXTENSIONS EXTENDE UM TIPO COM MÉTODOS ADICIONAIS

int number = 20;
bool par = false;

par = number.EhPar();
// this extende o comportamento do int, ou seja: toda variável int vai ter acesso à esse método e o parâmetro vira ele mesmo


string message = $"O número {number} é {(par ? "par" : "impar")}";
Console.WriteLine(message);