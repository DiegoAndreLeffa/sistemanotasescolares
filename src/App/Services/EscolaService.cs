using App.Models;
using System.Collections.Generic;
using System.Linq;

namespace App.Services
{
    /// <summary>
    /// Serviço para gerenciar as operações da escola.
    /// </summary>
    public class EscolaService
    {
        // Listas privadas para armazenar os dados em memória.
        private readonly List<Aluno> _alunos = new List<Aluno>();
        private readonly List<Disciplina> _disciplinas = new List<Disciplina>();

        /// <summary>
        /// Adiciona um novo aluno à lista.
        /// </summary>
        /// <param name="aluno">O aluno a ser adicionado.</param>
        public void AdicionarAluno(Aluno aluno)
        {
            // Valida se já existe um aluno com o mesmo ID.
            if (_alunos.Any(a => a.Id == aluno.Id))
            {
                throw new InvalidOperationException("Já existe um aluno com este ID.");
            }
            _alunos.Add(aluno);
        }

        /// <summary>
        /// Retorna a lista de todos os alunos cadastrados.
        /// </summary>
        public IEnumerable<Aluno> ListarAlunos()
        {
            return _alunos;
        }

        /// <summary>
        /// Adiciona uma nova disciplina à lista.
        /// </summary>
        /// <param name="disciplina">A disciplina a ser adicionada.</param>
        public void AdicionarDisciplina(Disciplina disciplina)
        {
             // Valida se já existe uma disciplina com o mesmo ID.
            if (_disciplinas.Any(d => d.Id == disciplina.Id))
            {
                throw new InvalidOperationException("Já existe uma disciplina com este ID.");
            }
            _disciplinas.Add(disciplina);
        }

        /// <summary>
        /// Retorna a lista de todas as disciplinas cadastradas.
        /// </summary>
        public IEnumerable<Disciplina> ListarDisciplinas()
        {
            return _disciplinas;
        }
    }
}