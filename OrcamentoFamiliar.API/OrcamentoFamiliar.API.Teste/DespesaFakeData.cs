using Bogus;
using Bogus.DataSets;
using OrcamentoFamiliar.API.Entity.Enum;
using OrcamentoFamiliar.API.Entity.Request;

namespace OrcamentoFamiliar.API.Teste
{
    public class DespesaFakeData
    {
        private static DateTime begin = new DateTime(2022, 01, 01);
        private static DateTime end = new DateTime(2022, 12, 31);

        public static Despesas CreateValidDespesa()
        {
            return new Despesas
            {
                Id = new Randomizer().Int(0, 10000),
                Descricao = new Finance().TransactionType(),
                Valor = new Randomizer().Decimal(1, 1000),
                Data = new Date().Between(begin, end),
                Categoria = EnumCategoria.Educacao,
                
            };
        }

        public static List<Despesas> CreateListValidDespesas(int limit = 5)
        {
            var list = new List<Despesas>();

            for (int i = 0; i < limit; i++)
            {
                list.Add(CreateValidDespesa());
            }

            return list;
        }

        public static DespesaRequest CreateValidDespesasDTO(bool newId = false)
        {
            return new DespesaRequest
            {
                //Id = newId ? new Randomizer().Int(0, 10000) : 0,
                Descricao = new Finance().TransactionType(),
                Valor = new Randomizer().Decimal(1, 1000),
                Data = new Date().Between(begin, end),
                Categoria = EnumCategoria.Educacao
            };
        }

        public static DespesaRequest CreateInvalidDespesasDTO()
        {
            return new DespesaRequest
            {
                //Id = 0,
                Descricao = "",
                Data = new DateTime(2023, 12, 03),
                Valor = 0.88m,
                Categoria = EnumCategoria.Educacao
            };
        }
    }
}
