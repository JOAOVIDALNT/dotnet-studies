### Protocolo HTTP

- Protocolo de comunicação responsável pelo intermédio da comunicação entre cliente e servidor.

> BROWSER -> IMPLEMENTA O CLIENTE HTTP
> SERVIDOR -> HOSPEDA OS OBJETOS WEB (RECURSOS QUE O CLIENTE SOLICITA)

- CLIENTE -> MENSAGENS DE REQUEST (HTTP)
> O CLIENTE IRÁ REQUISITAR OBJETOS WEB (RECURSOS) QUE ELE PRECISE CONSUMIR

- SERVIDOR -> MENSAGENS DE RESPONSE (HTTP)
> O SERVIDOR RESPONDE COM UMA MENSAGEM DO TIPO RESPONSE ATRAVÉS DO PROTOCOLO TCP/IP, QUE PRINCIPALMENTE GARANTE A SEGURANÇA DA RESPONSE CASO ELA SEJA PERDIDA

> TCP - CAMADA DE TRANSPORTE / HTTP - CAMADA DE APLICAÇÃO

> SERVIDOR É STATELESS, OU SEJA, NÃO GUARDA ESTADO: SE VOCÊ REQUISITAR X VEZES, ELE RESPONDERÁ X VEZES

- GET -> Solicita algum conteúdo ao servidor, quando o servidor recebe ele responde a requisição

- POST ->  Submete algum contéudo ao servidor, que é obrigado a tratar ele, ou seja, ele não busca uma página mas sim envia contéudo para o servidor, o servidor atualiza o banco de dados e responde com o status da requisição, ou seja, se ele conseguiu ou não executar as ações baseado na sua requisição.




