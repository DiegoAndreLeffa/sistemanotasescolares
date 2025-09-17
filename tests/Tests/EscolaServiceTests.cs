using Xunit;
using App.Models;
using App.Services;
using System;
using System.Linq;

namespace Tests
{
    public class EscolaServiceTests
    {
        // Teste para o método AdicionarAluno
        [Fact]
        public void AdicionarAluno_DeveAdicionarAlunoNaLista()
        {
            // Arrange (Organização)
            var service = new EscolaService();
            var aluno = new Aluno(1, "Teste Aluno");

            // Act (Ação)
            service.AdicionarAluno(aluno);

            // Assert (Verificação)
            var alunos = service.ListarAlunos();
            Assert.Single(alunos); // Verifica se há apenas um aluno na lista.
            Assert.Equal("Teste Aluno", alunos.First().Nome); // Verifica se o nome está correto.
        }

        [Fact]
        public void AdicionarAluno_ComIdDuplicado_DeveLancarExcecao()
        {
            // Arrange
            var service = new EscolaService();
            var aluno1 = new Aluno(1, "Aluno Um");
            var aluno2 = new Aluno(1, "Aluno Dois");
            service.AdicionarAluno(aluno1);

            // Act & Assert
            // Verifica se uma exceção do tipo InvalidOperationException é lançada.
            Assert.Throws<InvalidOperationException>(() => service.AdicionarAluno(aluno2));
        }

        // Teste para o método AdicionarDisciplina
        [Fact]
        public void AdicionarDisciplina_DeveAdicionarDisciplinaNaLista()
        {
            // Arrange
            var service = new EscolaService();
            var disciplina = new Disciplina(101, "História");

            // Act
            service.AdicionarDisciplina(disciplina);

            // Assert
            var disciplinas = service.ListarDisciplinas();
            Assert.Single(disciplinas);
            Assert.Equal("História", disciplinas.First().Nome);
        }
    }
}