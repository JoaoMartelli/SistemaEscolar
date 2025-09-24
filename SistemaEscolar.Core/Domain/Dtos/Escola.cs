using SistemaEscolar.Core.Domain.Enum;
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
        public EstadosEnum Estado { get; set; }
        public DateTime DataInauguracao { get; set; }
    }
}
