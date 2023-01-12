### Comando INSERT

- Insere informação na tabela através de uma ordem de parâmetros estabelecidos no comando
ex: INSERT INTO Clientes (Nome, Sobrenome, Email, AceitaComunicados, DataCadastro)
    VALUES ('João', 'Vidal', 'joao@fejota.dev', 1, GETDATE())

ou  INSERT INTO Clientes VALUES ('João', 'Vidal', 'joao@fejota.dev', 1, GETDATE())
    (é mais simples porém deve obedecer a ordem da tabela enquanto com o INTO é possível denominar a ordem)