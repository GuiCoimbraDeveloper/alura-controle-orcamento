using OrcamentoFamiliar.API.Entity.Enum;

namespace OrcamentoFamiliar.API.Entity.Response
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
