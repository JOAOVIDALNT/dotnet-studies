    bool nonNullable = true; //recebe apenas os valores true ou false
    bool? desejaReceberEmail = null; //recebe, além de true e false o valor null

    // TIPOS NULLABtLE RECEBEM AS FUNÇÕES HASVALUE(checa se há valor) & VALUE (recebe o valor)
    // ex:
    if (desejaReceberEmail.HasValue && desejaReceberEmail.Value) 
    // desejaReceberEmail != null && desejaReceberEmail.Value == true
    {
        Console.WriteLine("O usuário optou por receber o email");
    }
    else 
    {
        Console.WriteLine("o usuário não respondeu ou optou por não receber o email");
    }
