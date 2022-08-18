namespace OrcamentoFamiliar.Domain.Entity.Request
{
    public class ReceitaRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
