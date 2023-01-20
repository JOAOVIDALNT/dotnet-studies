### WEB SOCKET

- web socket é uma api que trabalha na fraqueza do método http, ou seja, em aplicações web que demandam muitas requisições causando alto overhead.

> OUTROS PROBLEMAS DO MÉTODO HTTP PARA ALGUMAS APLICAÇÕES SÃO CONEXÕES SUBJACENTES E MAPEAMENTO VIA SCRIPT PELA PARTE DO CLIENTE, TENDO QUE SABER EXATAMENTE O QUE CHEGA E ASSOCIAR A UM RECURSO OU RESPOSTA CORRETA

- WEB SOCKET é uma conexão bi-dimensional, muito usada por aplicações que necessitam dessa comunicação frequente, twitter usa, trello usa, assim como varios jogos web.

> O WEB SOCKET RODA ENCAPSULADO NO HTTP, UTILIZANDO TODA A INFRAESTRUTURA EXISTENTE NO HTTP.
> WEB SOCKET É COMO UM UPGRADE DO PROTOCOLO HTTP, HTTP NÃO FOI CRIADO PARA RECEBER TANTAS REQUISIÇÕES SIMULTÂNEAS ASSIM, O WEB SOCKET EXPLORA ESSA DEMANDA.