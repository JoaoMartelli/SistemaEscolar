using System;

namespace SistemaEscolar.Core.Domain.Dtos
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
    }
}
