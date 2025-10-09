using System;

namespace SistemaEscolar.Core.Domain.Dtos.Presenca
{
    public class AlunoPresencaVM
    {
        public int AlunoId { get; set; }
        public int? PresencaId { get; set; }
        public string Nome { get; set; }
        public bool Presente { get; set; }
        public string Justificativa { get; set; }
        public DateTime Data { get; set; }
        public int CursoId { get; set; }
    }
}
