### Introdução a API

- Uma API (Application Programming Interface) é uma forma de comunicação entre computadores ou programas de computadores.
Em outras palavras, é um software que fornece informações para outro software (integração entre sistemas).

> UMA API É UM SISTEMA BACKEND, PODENDO SER INTERNO COMO UM SISTEMA QUE RECEBE INFORMAÇÕES DO FRONT END E MANIPULA O BANCO DE DADOS E O ESTADO DO FRONT END, OU EXTERNO, COMO POR EXEMPLO UM E-COMMERCE QUE CONSOME A API DA TRANSPORTADORA PRA OBTER INFORMAÇÕES DE FRETE OU ATÉ RASTREAMENTO.

#### Exemplo de API's

https://date.nager.at/
> É POSSIVEL CONSUMIR A API DE FERIADOS, EVITANDO O TRABALHO DE SETAR MANUALMENTE FERIADOS, PRINCIPALMENTE OS QUE VARIAM DE ACORDO COM O ANO
> UMA API TRABALHA COM REQUISIÇÕES PARAMETRIZADAS 

Request
GET /api/v3/PublicHolidays/{Year}/{CountryCode}

Parameter:	    Required	Example value
Year:	        true	    2023
CountryCode:    true	    AT

https://date.nager.at/api/v3/publicholidays/2023/AT
