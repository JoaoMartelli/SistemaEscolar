using System;

namespace SistemaEscolar.Core.Domain.Dtos
{
    public class AlunoCursoDto
    {
        public int AlunoId { get; set; }
        public int CursoId { get; set; }
        public DateTime DataMatricula { get; set; }
        
        public AlunoDto Aluno { get; set; }
        public CursoDto Curso { get; set; }
    }
}
