

### Projetos que utilizaremos

![[Pasted image 20240507055117.png]]
*ordem hierárquica onde, o projeto acima consegue enxergar o assinalado*

### API
Onde definiremos os nossos controllers, a responsabilidade dele é receber uma requisição e devolver uma resposta.

### Application
Onde definiremos as **regras de negócios**, ou seja, quando recebemos a requisição a chamada é repassada para o projeto de application. Para um caso onde a requisição é um registro de usuários, nosso application deve realizar todas as validações e solicitar o registro da operação.

### Infraestructure
Utilizaremos para se comunicar com serviços externos à nossa API, como por exemplo, o próprio banco de dados ou a integração com API's, Google e serviços de e-mail.

### Domain
Projeto independente, que tanto Application quando Infraestructure enxergam.
O Domain guarda as nossas **entidades e as interfaces** de bancos de dados, utilizaremos a injeção de dependência para garantir a comunicação.

### Fluxo
Chegou a requisição na API -> Repassa para a regra de negócio (Application) -> A classe responsável requisita uma implementação que siga determinada interface -> A injeção de dependência vai fornecer pra Application validar -> O projeto de infraestrutura persiste os dados da operação, se necessário.


