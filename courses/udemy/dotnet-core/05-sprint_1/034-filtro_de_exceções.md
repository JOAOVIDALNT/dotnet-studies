
#### Por que um filtro de exceções?
Seria possível, tratar exceções apenas através de um try catch no controller, mas criar um filtro de exceções é ideal, pois além de reduzir o código no controller, garante que um desenvolvedor não esquecerá de lidar com o tratamento de exceções.

#### Estrutura inicial
![[Pasted image 20240708062256.png]]
Dentro da nossa API, definiremos os filtros através de uma classe que estende de 'IExceptionFilter'.

#### Configuração
![[Pasted image 20240708062506.png]]
No arquivo de configuração instanciaremos um serviço para o filtro.


#### Lógica

![[Pasted image 20240708065500.png]]
Observe que no filtro de exceções, primeiro checamos se é uma exceção tratada, ou seja, alguma exceção que estenda no nosso tipo base 'MyCookBookException' e ai direcionamos pro Handle que vai validar um tipo específico e definir os retornos para status code e mensagem.


![[Pasted image 20240708065609.png]]

E assim ficou o retorno de uma requisição com erro de validação:
![[Pasted image 20240708071035.png]]