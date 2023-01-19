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

#### Estrutura do HTTP request

Get: /somedir/page.htmlHTTP/1.1 -> Método HTTP & Versão
Host: www.someschool.edu -> URL
Connection: close -> tipo de conexão*
User-agent: Mozilla/5.0 -> agente que realiza a requisição
Accept-language: en -> preferencia de idioma do cliente

> *tipo de conexão: close -> conexão NÃO PERSISTENTE, ou seja, uma vez que eu recebo a response, o servidor encerra essa conexão

A estrutura do método get carrega mais infos, como:
User-agent: Mozilla/5.0 (linux;...) Firefox 51.0
Accept: text/html, application/xhtml+xml,...,*/*;q=0.8
Accept-language: en-US, en=0.5
Accept-Enconding: gzip, deflate

POST: / HTTP/1.1
Host: localhost:8080
Connection: close
User-agent: Mozilla/5.0 (linux;...) Firefox 51.0
Accept: text/html, application/xhtml+xml, ..., */*; q=0.8
Accept-language: em-US, em=0.5
Accept-Enconding: gzip, deflate
Contente-Type: multipart/form-data; boundary=12656974
Content-Length: 345
(more data) -> entity body (JSON, XML)

#### Estrutura HTTP response

HTTP/1.1 200 OK -> status line
Connection: close                           {
Date: Tue, 09 Aug 2011 15:44:04 GMT
Server: Apache/2.2.3 (CentOS)                   -> header lines
Last-Modified: Tue, 09 Aug 2011 15:11:03 GMT
Content-Length: 6821
Content-Type: text/html                     }
(data , data, ....) -> entity body

> STATUS CODE: 
>200 OK: request bem sucedida e objeto enviado
>301 Moved Permanently: objeto realocado nova URL no campo Location
>400 Bad Request: resposta genérica - servidor não entendeu a mensagem
>404 Not Found: o documento solicitado é inexistente
>505 HTTP Version Not Supported: versão do protocolo não suportada pelo servidor

• Information response (100 – 199)
• Successful response (200 – 299)
• Redirection response (300 – 399)
• Client error response (400 – 499)
• Server error response (500 – 599)



#### Principais comandos

GET* solicita um recurso do servidor
HEAD* GET sem corpo de resposta
POST submete uma entidade a um recurso
PUT substituição de recursos pelos dados da requisição
DELETE remoção de um recurso
TRACE chamada de loop-back a um determinado recurso
OPTION* opções de comunicação com recurso
CONNECT tunelamento identificado pelo recurso
PATCH modificação parcial

> * - Métodos seguros: não alteram o estado do servidor - operação de leitura (READONLY)
> UM MÉTODO SEGURO GARANTE QUE NÃO HAVERÁ ALTERAÇÃO NO SERVIDOR PELO LADO DO CLIENTE

#### Cookies e cache

- O client/server é statless, ou seja, não guarda o estado do cliente, aumentando a performance porém consumindo mais banda 

> COOKIES:
>Pequenos pedaços ou blocos de dados criados e utilizados pelo servidor para persistir dados no dispositivo do cliente.

> Cookies de sessão -> são deletados quando a sessão se encerra
> Cookies persistentes -> são armazenados dentro do cookie file por um tempo indeterminado

> Solicita o concentimento graças a lgpd


