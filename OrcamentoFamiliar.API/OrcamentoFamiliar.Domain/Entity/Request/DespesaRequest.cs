using OrcamentoFamiliar.Domain.Entity.Enum;

namespace OrcamentoFamiliar.Domain.Entity.Request
{
    public class DespesaRequest
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public EnumCategoria? Categoria { get; set; } = EnumCategoria.Outras;
        public DateTime Data { get; set; }
    }
}
