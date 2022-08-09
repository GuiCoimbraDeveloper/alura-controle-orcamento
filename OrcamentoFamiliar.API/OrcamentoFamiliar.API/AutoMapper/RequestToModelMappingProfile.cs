using AutoMapper;
using OrcamentoFamiliar.API.Entity;
using OrcamentoFamiliar.API.Entity.Request;

namespace OrcamentoFamiliar.API.AutoMapper
{
    public class RequestToModelMappingProfile : Profile
    {
        public RequestToModelMappingProfile()
        {
            CreateMap<ReceitaRequest, Receitas>();
            CreateMap<DespesaRequest, Despesas>();
        }
    }
}
