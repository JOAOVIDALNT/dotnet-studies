### Comando UPDATE

- Atualiza informações da tabela
ex: UPDATE Clientes
    SET Email = 'emailnovo@email.com'
    WHERE Id = 1001

ou  UPDATE Clientes
    SET Email = 'emailnovo@email.com', AceitaComunicados = 0 (para atualizar mais de um campo)
    WHERE Id = 1001
ou  WHERE Nome = 'João' (atualizaria todos com nome João)

### BEGIN TRAN & ROLLBACK

- BEGIN TRAN entra em um modo onde é possivel desfazer as mudanças, é necessário executar ele antes de executar algum erro
- ROLLBACK é executado depois de executar o erro, voltando para o ponto onde foi executado o BEGIN TRAN
