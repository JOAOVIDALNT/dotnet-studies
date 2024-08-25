### Comando UPDATE

- Atualiza informações da tabela
ex: UPDATE Clientes
    SET Email = 'emailnovo@email.com'
    WHERE Id = 1001

ou  UPDATE Clientes
    SET Email = 'emailnovo@email.com', AceitaComunicados = 0 (para atualizar mais de um campo)
    WHERE Id = 1001
ou  WHERE Nome = 'João' (atualizaria todos com nome João)