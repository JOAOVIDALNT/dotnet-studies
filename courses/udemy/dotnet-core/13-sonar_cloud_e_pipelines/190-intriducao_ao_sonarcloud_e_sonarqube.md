`Sonarqube` é uma ferramenta `opnesource` que vai gerar métricas sobre seu código, que é utilizado em servidor e pode ter o `setup` um pouco complicado. 

`SonarCloud` é a versão na nuvem do `SonarQube`.


### MÉTRICAS

#### BUGS
Problemas no código que causam erros inesperados durante a execução.

#### VULNERABILIDADES
Identificar pontos fracos no código que podem ser explorados por ataques, comprometendo a segurança da aplicação.

#### CODE SMELLS 
Más práticas de programação que tornam o código confuso e difícil de manter e entender.

#### SECURITY HOTSPOTS
Problemas que o `sonarcloud` entende que pode ser um problema, então você deve validar manualmente e sinalizar no `app`.

#### COBERTURA DE CÓDIGO
A porcentagem de código coberta por testes de unidade. O programa considera o total de linhas da aplicação dividido pelo total de tinhas cobertas por testes e é possível indicar quais trechos do código não são passíveis de testes.

#### DUPLICIDADE DE CÓDIGO
Porcentagem de linhas duplicadas na aplicação.