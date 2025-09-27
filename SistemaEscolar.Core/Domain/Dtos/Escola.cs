using System;

namespace SistemaEscolar.Core.Domain.Dtos
{
    public class Escola
    {
        public int EscolaId { get; set; }
        public string NomeCompleto { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public DateTime DataInauguracao { get; set; }
    }
}
