using SistemaEscolar.Core.Domain.Enum;
using System;
using System.Collections.Generic;

namespace SistemaEscolar.Core.Domain.Dtos
{
    public class AlunoDto
    {
        public int AlunoId { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public EstadosEnum Estado { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }

        public List<AlunoCursoDto> AlunoCursos { get; set; }
    }
}
