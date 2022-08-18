using AutoMapper;
using OrcamentoFamiliar.Domain.Entity;
using OrcamentoFamiliar.Domain.Entity.Request;

namespace OrcamentoFamiliar.Domain.AutoMapper
{
    public class RequestToModelMappingProfile : Profile
    {
        public RequestToModelMappingProfile()
        {
            CreateMap<ReceitaRequest, Receitas>();
            CreateMap<DespesaRequest, Despesas>();
            CreateMap<Despesas, DespesaRequest>();
        }
    }
}
