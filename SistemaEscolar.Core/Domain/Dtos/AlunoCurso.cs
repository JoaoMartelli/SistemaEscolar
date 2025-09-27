using System;

namespace SistemaEscolar.Core.Domain.Dtos
{
    public class AlunoCurso
    {
        public int AlunoId { get; set; }
        public int CursoId { get; set; }
        public DateTime DataMatricula { get; set; }
    }
}
