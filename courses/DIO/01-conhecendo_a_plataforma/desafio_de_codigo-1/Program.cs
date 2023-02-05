using System; 

    double salario = 100.00; 
    double reajuste = 0.00; 
    double novoSalario = 0.00; 
    double percentual = 0.00; 
  
    salario = Convert.ToDouble(Console.ReadLine()); 

//TODO: Complete os espaços em branco com uma possível solução para o problema:
   
    if(salario < 0) { 
      Console.WriteLine("O salário não pode ser menor do que 0"); 

    } else if (salario <= 400.00) { 
      percentual = 15.00 / 100.00; 
      novoSalario = salario + (salario * percentual); 
      reajuste =  novoSalario - salario; 


    } else if (salario <= 800.00) { 
      percentual = 12.00 / 100.00; 
      novoSalario = salario + (salario * percentual); 
      reajuste =  novoSalario - salario;         

    } else if (salario <= 1200.00) { 
      percentual = 10.00 / 100.00; 
      novoSalario = salario + (salario * percentual); 
      reajuste = novoSalario - salario; 

    } else if (salario <= 2000.00 ) { 
      percentual = 7.00 / 100.00 ; 
      novoSalario = salario + (salario * percentual); 
      reajuste = novoSalario - salario; 

    } else { 
      percentual = 4.00 / 100.00; 
      novoSalario = salario + (salario * percentual); 
      reajuste = novoSalario - salario; 

    } 

    Console.WriteLine($"Novo salario: {novoSalario}"); 
    Console.WriteLine($"Reajuste ganho: {reajuste}"); 
    Console.WriteLine($"Em percentual: {percentual} %"); 

