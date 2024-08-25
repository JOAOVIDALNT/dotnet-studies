### Programação assíncrona

Programação assíncrona permite que a sua aplicação responda de maneira mais rápida e com fluidez, 
mas pode também causar bastante problema e confusão se não for utilizada da maneira correta.

>Síncrono: Quando você executa um código de maneira síncrona, significa que você precisa esperar o código terminar para poder prosseguir.

> Assíncrono: Neste modelo você não precisa esperar o código terminar para poder prosseguir. É comum neste modelo de programação o uso de “call-backs”, que são chamados ao final da operação.

> MultiThreding: No multithreading você pode executar vários códigos ao mesmo tempo. Entenda que uma "theard" é uma execução de código de podemos ter dezenas, centenas delas executando neste exato momento em seu computador. O Windows é um sistema multithread, pois consegue realizar várias tarefas em paralelo, como copiar um arquivo enquanto você navega na internet

> Concorrente: Significa que temos duas ou mais tarefas sendo executadas em conjunto, não necessariamente ao mesmo tempo, mas juntas.

> Paralelismo: Neste cenário temos duas ou mais tarefas sendo executadas ao mesmo tempo, por exemplo em um computador com vários núcleos (cores).

#### Quando devemos usar síncrono ou assíncrono?

Se você tem processamentos longos, como acesso a dados, rede, leitura e escrita de arquivos, você pode usar programação assíncrona. Códigos com alto uso de processamento também são candidatos a programação assíncrona. Mas se o seu código tem um fluxo contínuo e cada operação precisa sempre aguardar a anterior, você pode usar o modelo síncrono. Vale a pena considerar tornar o código assíncrono sempre que possível, pois isto aumenta a performance.

Um alerta importante: a programação assíncrona usa mais recursos do computador, então é importante dimensionar corretamente a máquina, pois você terá muito mais código sendo executado ao mesmo tempo, e isto também pode aumentar a complexidade na hora de fazer depuração (debug).

#### Operações I/O Bound e CPU Bound

Quando falamos de processamento assíncrono, temos que levar em consideração dois aspectos:

- I/O Bound: operações que acessam recursos como disco, rede para realizar uma operação, por exemplo: 
    var web = new HttpClient();
    var site = await web.GetStringAsync(new Uri("https://www.microsoft.com”));

Neste exemplo, estamos baixando contéudo do site da Microsoft, como um texto, então estamos usando recursos de rede para acessar o site. A palavra "async" é quem permite a execução assíncrona e iremos falar dela mais adiante.

- CPU Bound: operações que executam muitos cálculos, que itilizam muito o processador da máquina, por exemplo:
    var lista = new List<string>();
    lista.Add(“Maria”);
    lista.Add(“Joao”);
    lista.Add(“Antonio”);
    lista.Add(“Joaquim”);
    lista.Sort();

Neste exemplo, estamos ordenando uma lista com Sort(), então estamos usando processamento.

#### Async e Await

Para programarmos de maneira assíncrona vamos utilizar sempre dois objetos: Task e Task<T>, que permitem esse tipo de opreção. Também utilizaremos as palavras chave async e await, que é onde tudo acontece. Estas duas palavras-chave são o ponto central da programação assíncrona.
A palavra await inicia a execução assíncrona do código, controlando o fluxo de exeucução e retornando ao ponto da chamada para continuar o fluxo. E a palavra async permite o código ser executado de maneira assíncrona.

Para deixar mais claro o conceito de execução de operações assíncronas,vamos construir um exemplo de acordo com a listagem abaixo, que é muito parecida com o fluxo da figura anterior.

    public partial class frmPrincipal : Form
    {
        string site;
        public frmPrincipal()
        {
        InitializeComponent();
        this.btnLer.Click += async (o, e) => { await btnLer_Click(o, e); };
        site = “”;
        }

        private async Task btnLer_Click(object sender, EventArgs e)
        {
        lstStatus.Items.Add(“Lendo site...”);
        lstStatus.Refresh();
        var web = new HttpClient();
        site = await web.GetStringAsync(new Uri(txtSite.Text));
        if (site != “” && txtPalavra.Text != “”)
            {
            lstStatus.Items.Add(“Site lido”);
            btnContar_Click(sender, e);
            }
        }

        private void btnContar_Click(object sender, EventArgs e)
        {
            if (txtPalavra.Text != “”)
            {
                var total = Regex.Matches(site, txtPalavra.Text).Count();
                lstStatus.Items.Add($”Total de ocorrências da palavra {txtPalavra.Text} = { total}”);
            }
            else
            {
                lstStatus.Items.Add(“Palavra não informada”);
            }
        }
    }

Esta é uma aplicação Windows Forms, então temos interação do usuário com a tela (UI) através de dois botões. Na figura temos a tela da aplicação em execução.

A ideia deste exemplo é baixar o conteúdo do site e permitir que o usuário conte quantas palavras existem no site informado. O exemplo da figura 2, temos vários textos ilustrando o que aconteceu durante a execução: quando o usuário clicou no botão “Ler” temos o texto “Lendo site...”, mas antes mesmo de terminar a leitura, o usuário clicou no botão “Contar” e, o resultado foi “Total de ocorrências da palavra Office = 0”, pois o site ainda não tinha sido lido totalmente, mesmo assim o usuário conseguiu clicar no botão. Isto ilustra o fluxo de execução do processamento assíncrono.

#### Declaração Task nos métodos

Um método assíncrono tem em sua definição a palavra-chave async e o objeto Task que representa o retorno do método. Veja que o Task pode ter um tipo de dados para retorno, por exemplo Task<string> retornará uma string.

Depois de declarado o método com async Task, espera-se que ele possua uma chamada para um código assíncrono, através da palavra-chave await.

#### Boas práticas com async

Sempre que você criar um método assíncrono, coloque a extensão Async no final do nome, pois isto indicará que o método aceita ser executado com await.

O código a seguir mostra uma WebAPI em .NET 5.0 com um método síncrono e outro assíncrono:

    namespace ExemploAPI.Controllers
    {
        [ApiController]
        [Route(“[controller]”)]
        public class DadosController : ControllerBase
        {
            private readonly ILogger<DadosController> _logger;
            public DadosController(ILogger<DadosController> logger)
            {
                _logger = logger;
            }

            [HttpGet(“sincrono”)]
            public string Get()
            {
                return “Exemplo de API - método sincrono”;
            }

            [HttpGet(“assincrono”)]
            public async Task<string> GetAsync()
            {
            var sr = new StreamReader(“./arquivos/teste.txt”);
            var conteudo = await sr.ReadToEndAsync();
            sr.Close();
            return conteudo;
            }
        }
    }

Veja que o método Get() é síncrono, pois não realiza operações assíncronas, mas o método GetAsync() faz a leitura de um arquivo de forma assíncrona (ReadToEndAsync), e por isto, tem a declaração async Task<string>, pois o retorno é assíncrono, do tipo string. A programação assíncrona pode ser aplicada a diversos tipos de
aplicação, como no exemplo anterior, que é uma aplicação web.

O uso de programação assíncrona pode criar um ótimo benefício para o seu código, mas lembre-se de se aprofundar e ficar atento às regras que demonstramos aqui.
