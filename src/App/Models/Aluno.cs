// Importa o namespace para usar listas genéricas.
using System.Collections.Generic;

// Define o namespace para organizar as classes do modelo.
namespace App.Models
{
    /// <summary>
    /// Representa um aluno no sistema.
    /// </summary>
    public class Aluno
    {
        /// <summary>
        /// Identificador único do aluno.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Nome completo do aluno.
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Construtor da classe Aluno.
        /// </summary>
        /// <param name="id">O ID do aluno.</param>
        /// <param name="nome">O nome do aluno.</param>
        public Aluno(int id, string nome)
        {
            // Validação para garantir que o nome não seja nulo ou vazio.
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do aluno não pode ser vazio.");
            }
            Id = id;
            Nome = nome;
        }
    }
}