using OrcamentoFamiliar.Domain.Entity.Enum;

namespace OrcamentoFamiliar.Domain.Entity.Response
{
    public class DespesaResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public EnumCategoria Categoria { get; set; }
        public DateTime Data { get; set; }
    }
}
