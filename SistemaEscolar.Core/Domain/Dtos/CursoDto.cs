using System.Collections.Generic;

namespace SistemaEscolar.Core.Domain.Dtos
{
    public class CursoDto
    {
        public int CursoId { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public int EscolaId { get; set; }
        public bool Ativo { get; set; }

        public EscolaDto Escola { get; set; }

        public List<AlunoCursoDto> AlunoCursos { get; set; }
    }
}
