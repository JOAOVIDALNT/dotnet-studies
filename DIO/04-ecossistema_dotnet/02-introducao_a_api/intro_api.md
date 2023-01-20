### Introdução a API

- Uma API (Application Programming Interface) é uma forma de comunicação entre computadores ou programas de computadores.
Em outras palavras, é um software que fornece informações para outro software (integração entre sistemas).

#### Exemplo de API's

https://date.nager.at/
> É POSSIVEL CONSUMIR A API DE FERIADOS, EVITANDO O TRABALHO DE SETAR MANUALMENTE FERIADOS, PRINCIPALMENTE OS QUE VARIAM DE ACORDO COM O ANO
> UMA API TRABALHA COM REQUISIÇÕES PARAMETRIZADAS 

Request
GET /api/v3/PublicHolidays/{Year}/{CountryCode}
Parameter	Required	Example value
Year	    true	    2023
CountryCode	true	    AT

https://date.nager.at/api/v3/publicholidays/2023/AT
