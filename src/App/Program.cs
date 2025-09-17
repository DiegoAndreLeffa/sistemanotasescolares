using System;
using App.Models;
using App.Services;

namespace App
{
    class Program
    {
		static void Main(string[] args)
		{
			// Instancia o serviço que gerencia a escola.
			var escolaService = new EscolaService();

			Console.WriteLine("--- Sistema de Notas Escolares ---");

			// Adicionando alguns dados de exemplo
			escolaService.AdicionarAluno(new Aluno(1, "João Silva"));
			escolaService.AdicionarAluno(new Aluno(2, "Maria Santos"));
			escolaService.AdicionarDisciplina(new Disciplina(101, "Matemática"));
			escolaService.AdicionarDisciplina(new Disciplina(102, "Português"));
			escolaService.LancarNota(new Nota(alunoId: 1, disciplinaId: 101, valor: 8.5));
			escolaService.LancarNota(new Nota(alunoId: 1, disciplinaId: 101, valor: 9.0));
			escolaService.LancarNota(new Nota(alunoId: 2, disciplinaId: 101, valor: 6.0));

			// Exibindo os dados cadastrados
			Console.WriteLine("\n--- Alunos Cadastrados ---");
			foreach (var aluno in escolaService.ListarAlunos())
			{
				Console.WriteLine($"ID: {aluno.Id}, Nome: {aluno.Nome}");
			}

			Console.WriteLine("\n--- Disciplinas Cadastradas ---");
			foreach (var disciplina in escolaService.ListarDisciplinas())
			{
				Console.WriteLine($"ID: {disciplina.Id}, Nome: {disciplina.Nome}");
			}

			// Calculando e exibindo a média
			Console.WriteLine("\n--- Média dos Alunos ---");
			var mediaJoaoMatematica = escolaService.CalcularMedia(1, 101);
			if (mediaJoaoMatematica.HasValue)
			{
				Console.WriteLine($"Média do João em Matemática: {mediaJoaoMatematica.Value:F2}");
			}
			
			Console.WriteLine("\n--- Status de Aprovação ---");
			var statusJoao = escolaService.VerificarAprovacao(1, 101);
			if (statusJoao.HasValue)
			{
				string status = statusJoao.Value ? "Aprovado" : "Reprovado";
				Console.WriteLine($"Status do João em Matemática: {status}");
			}
        }
    }
}