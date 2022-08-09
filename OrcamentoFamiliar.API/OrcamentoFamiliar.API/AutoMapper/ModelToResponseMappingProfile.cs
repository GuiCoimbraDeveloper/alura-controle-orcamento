using AutoMapper;
using OrcamentoFamiliar.API.Entity;
using OrcamentoFamiliar.API.Entity.Response;

namespace OrcamentoFamiliar.API.AutoMapper
{
    public class ModelToResponseMappingProfile : Profile
    {
        public ModelToResponseMappingProfile()
        {
            CreateMap<Receitas, ReceitaResponse>();
            CreateMap<Despesas, DespesaResponse>();
        }
    }
}
