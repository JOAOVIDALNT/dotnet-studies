### Injeção de dependencia

É uma técnica de programação usada para tornar uma classe independente de suas dependências

A injeção de dependência (DI) é um padrão usado para implementar a inversão de controle (IoC) e assim reduzir o acoplamento entre os objetos.

Ao aplicar a injeção de dependência fazemos com que o objeto forneça as dependências de outro objeto.

#### Apresentando o problema 

public class Cliente 
{
     Peido meuPedido = new Pedido();

    public List<Pedido> ObterPedidos()
    {
        return meuPedido.GetPedidos();
    }
}

> A classe cliente possui um forte acoplamento com a classe Pedido
> A classe cliente possui a responsabilidade de saber como criar uma instância de Pedido e depende desta instância
> A classe cliente é dependente da classe Pedido e de suas dependências 
> Qualquer mudança feita na classe Pedido afeta a classe Cliente
> Violação dos principíos SOLID SRP pois a classe Cliente possui mais de uma responsabilidade
> Se você for realizar testes unitários com a classe Cliente vai ter problemas pois ela possui uma instancia de outra classe sendo referenciados nela

#### Como resolver o problema?

- Temos que tirar da classe Cliente a responsabilidade de criar a classe Pedido
vamos inverter o controle na classe Cliente e tirar dela essa dependência 
vamos passar a responsabilidade de criar uma instância de Pedido para outra classe
Vamos inverter o controle na classe Cliente que agora vai passar o controle de como criar uma instancia de Pedido para a outra classe
- Temos aqui o princípio da inversãode controle ou dependência

> Devemos delegar a tarefa de criação de um objeto (classe Pedido) a uma outra entidade como uma outra classe, interface, componente, etc. de forma a termos um baixo acoplamento e minimizar as dependencias entre os objetos.
 
A classe Cliente não deverá depender diretamente da implementação da classe Pedido
Deveremos criar uma abstração entre as classes e as classes deverão depender somente desta abstração
Esta abstração poderá ser uma outra classe, interface ou um componente
Normalmente se usa interface

abstração:
public interface IPedido
{
    List<Pedido> GetPedidos();
}

implementação:
public class Pedido : IPedido
{
    public int PedidoId {get; set;}
    public int ClienteId {get; set;}

    public List<Pedido> GetPedidos()
    {
        var pedidos = new List<Pedido>();
        pedidos.Add(new Pedido { PedidoId = 1, ClienteId = 1});
        return pedidos;
    }
}

inversão de controle:
public class Cliente
{
    private readonly IPedido pedido;
    
    public Cliente(IPedido pedido)
    {
        this.pedido = pedido;
    }

    public  List<Pedido> ObterPedidos()
    {
        return pedido.GetPedidos();
    }
}

> agora a nossa classe cliente, depende de uma abstração que é uma interface, e não de uma implementação

> o container DI nativo do .NET é quem realiza a inversão de controle, fornecendo a classe Pedido para IPedido já que uma interface não pode ser instanciada
> config DI no .NET: services.AddTransient<IPedido, Pedido>();
> com essa config, toda vez que eu injetar uma interface IPedido no construtor de uma classe, o container DI sabe que ele precisa resolver uma instância da classe pedido e de suas dependências.

### Dependency Injection

- Não é um padrão (Design Pattern)
> Já foi descrito como uma técnica que implementa um padrão (IoC) > Inversão de controle
> Também serve o padrão DIP

Técnica é algo simples, um padrão é uma técnica que é repetida diversas vezes

- Ajuda no baixo acoplamento
- Provê uma melhor divisão de responsabilidades
> não interessa quem vai fornecer os serviços, será abordado da mesma maneira.




