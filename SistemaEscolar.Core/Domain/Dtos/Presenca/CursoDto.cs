namespace SistemaEscolar.Core.Domain.Dtos.Presenca
{
    public class CursoDto
    {
        public int CursoId { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int EscolaId { get; set; }
    }
}
