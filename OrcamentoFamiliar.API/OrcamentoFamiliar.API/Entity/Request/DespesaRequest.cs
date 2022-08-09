namespace OrcamentoFamiliar.API.Entity.Request
{
    public class DespesaRequest
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
