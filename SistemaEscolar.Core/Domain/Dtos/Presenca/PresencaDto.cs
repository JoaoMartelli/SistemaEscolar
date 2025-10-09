using System;

namespace SistemaEscolar.Core.Domain.Dtos.Presenca
{
    public class PresencaDto
    {
        public int? PresencaId { get; set; } // null = novo
        public int CursoId { get; set; }
        public int AlunoId { get; set; }
        public DateTime DataPresenca { get; set; }
        public bool StatusPresenca { get; set; } = true;
        public string Justificativa { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
