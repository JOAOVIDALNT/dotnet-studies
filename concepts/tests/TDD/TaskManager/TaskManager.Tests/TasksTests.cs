using TaskManager.Domain.Entities;

namespace TaskManager.Tests
{
    public class TasksTests
    {
        [Fact]
        public void CriarTarefasComSucesso()
        {
            // ARRANGE
            var titulo = "Teste";
            var descricao = "descrição";
            var dataVencimento = DateTime.Now;
            var prioridade = 1;
            var etiquetas = new List<string>() { "Teste11", "Teste2" };

            // ACT
            var tarefa = new Domain.Entities.Task(titulo, descricao, dataVencimento, prioridade, etiquetas);

            // ASSERT
            Assert.Equal(tarefa.Title, titulo);
            Assert.Equal(tarefa.Title, titulo);
            //Assert.Equal();
        }
    }
}