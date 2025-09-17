// Define o namespace para organizar as classes do modelo.
namespace App.Models
{
    /// <summary>
    /// Representa uma disciplina no sistema.
    /// </summary>
    public class Disciplina
    {
        /// <summary>
        /// Identificador único da disciplina.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Nome da disciplina.
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Construtor da classe Disciplina.
        /// </summary>
        /// <param name="id">O ID da disciplina.</param>
        /// <param name="nome">O nome da disciplina.</param>
        public Disciplina(int id, string nome)
        {
            // Validação para garantir que o nome não seja nulo ou vazio.
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome da disciplina não pode ser vazio.");
            }
            Id = id;
            Nome = nome;
        }
    }
}