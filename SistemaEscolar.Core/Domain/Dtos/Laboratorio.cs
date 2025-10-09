namespace SistemaEscolar.Core.Domain.Dtos
{
    public class Laboratorio
    {
        public int LaboratorioId { get; set; }
        public string Nome { get; set; }
        public int? Capacidade { get; set; }
        public string Tipo { get; set; }
        public string Equipamentos { get; set; }
        public int EscolaId { get; set; }
        public bool Ativo { get; set; }
    }
}