using AutoMapper;
using OrcamentoFamiliar.Domain.Entity;
using OrcamentoFamiliar.Domain.Entity.Response;

namespace OrcamentoFamiliar.Domain.AutoMapper
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
