namespace App.Models
{
    /// <summary>
    /// Representa uma nota de um aluno em uma disciplina.
    /// </summary>
    public class Nota
    {
        public int AlunoId { get; private set; }
        public int DisciplinaId { get; private set; }
        public double Valor { get; private set; }

        public Nota(int alunoId, int disciplinaId, double valor)
        {
            if (valor < 0 || valor > 10)
            {
                throw new ArgumentOutOfRangeException("A nota deve estar entre 0 e 10.");
            }
            AlunoId = alunoId;
            DisciplinaId = disciplinaId;
            Valor = valor;
        }
    }
}