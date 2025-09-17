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
        }
    }
}