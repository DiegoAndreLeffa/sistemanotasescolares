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

		[Fact]
		public void LancarNota_DeveAdicionarNota()
		{
			// Arrange
			var service = new EscolaService();
			service.AdicionarAluno(new Aluno(1, "Aluno"));
			service.AdicionarDisciplina(new Disciplina(101, "Disciplina"));
			var nota = new Nota(1, 101, 8.0);

			// Act
			service.LancarNota(nota);

			// Assert
			// A validação aqui é indireta, através do cálculo da média.
			Assert.Equal(8.0, service.CalcularMedia(1, 101));
		}

		[Fact]
		public void CalcularMedia_ComNotas_DeveRetornarMediaCorreta()
		{
			// Arrange
			var service = new EscolaService();
			service.AdicionarAluno(new Aluno(1, "Aluno"));
			service.AdicionarDisciplina(new Disciplina(101, "Disciplina"));
			service.LancarNota(new Nota(1, 101, 7.0));
			service.LancarNota(new Nota(1, 101, 9.0));

			// Act
			var media = service.CalcularMedia(1, 101);

			// Assert
			Assert.Equal(8.0, media);
		}

		[Fact]
		public void CalcularMedia_SemNotas_DeveRetornarNulo()
		{
			// Arrange
			var service = new EscolaService();
			service.AdicionarAluno(new Aluno(1, "Aluno"));
			service.AdicionarDisciplina(new Disciplina(101, "Disciplina"));

			// Act
			var media = service.CalcularMedia(1, 101);

			// Assert
			Assert.Null(media);
		}
		
		[Theory]
		[InlineData(7.0, true)]   // Média igual a 7 -> Aprovado
		[InlineData(8.5, true)]   // Média acima de 7 -> Aprovado
		[InlineData(6.9, false)]  // Média abaixo de 7 -> Reprovado
		public void VerificarAprovacao_ComMediasDiferentes_DeveRetornarStatusCorreto(double media, bool esperado)
		{
			// Arrange
			var service = new EscolaService();
			service.AdicionarAluno(new Aluno(1, "Aluno"));
			service.AdicionarDisciplina(new Disciplina(101, "Disciplina"));
			// Usamos uma única nota para forçar a média
			service.LancarNota(new Nota(1, 101, media));

			// Act
			var status = service.VerificarAprovacao(1, 101);

			// Assert
			Assert.Equal(esperado, status);
		}
    }
}