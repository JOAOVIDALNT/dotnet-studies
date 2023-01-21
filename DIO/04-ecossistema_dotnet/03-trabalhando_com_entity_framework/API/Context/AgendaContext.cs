using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Context
{
    public class AgendaContext : DbContext
    {
        // ENTIDADE É UMA CLASSE E AO MESMO TEMPO UMA TABELA NO DB
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
            // RECEBE A CONEXÃO/CONFIGURAÇÃO DO BANCO ATRAVÉS DO options E PASSA PARA O base QUE É O DbContext POIS ELE É QUEM GERENCIA A CONEXÃO COM O BANCO DE DADOS
            // SERVE APENAS COMO CONSTRUTOR. SEM CORPO.
            // NO PROGRAM.CS É POSSIVEL VER A IMPLEMENTAÇÃO DO OPTIONS PARA CONFIGURAR O DBCONTEXT
        }

        public DbSet<Contato> Contatos {get; set;}
        // Está dentro do dbset pois é uma classe no nosso programa e vai ser representado por uma tabela no banco de dados

    }
}