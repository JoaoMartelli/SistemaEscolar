using System;

namespace SistemaEscolar.Core.Domain.Dtos
{
    public class Presenca
    {
        public int PresencaId { get; set; }
        public int CursoId { get; set; }
        public int AlunoId { get; set; }
        public DateTime DataPresenca { get; set; }
        public string StatusPresenca { get; set; }
        public string Justificativa { get; set; }
        public bool Ativo { get; set; }
    }
}