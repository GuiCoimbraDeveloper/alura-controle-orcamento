using OrcamentoFamiliar.API.Entity.Enum;

namespace OrcamentoFamiliar.API.Entity.Response
{
    public class ResumoResponse
    {

        public ResumoResponse()
        {
            ValorGastoCategoria = new List<KeyValuePair<string, decimal>>();
        }
        public decimal ReceitasMes { get; set; }
        public decimal DespesaMes { get; set; }
        public decimal Saldo { get; set; }
        public List<KeyValuePair<string, decimal>> ValorGastoCategoria { get; set; }

    }
}
