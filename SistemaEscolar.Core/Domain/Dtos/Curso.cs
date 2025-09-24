namespace SistemaEscolar.Core.Domain.Dtos
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public int EscolaId { get; set; }
        public bool Ativo { get; set; }
    }
}
