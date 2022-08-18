using AutoMapper;

namespace OrcamentoFamiliar.API.AutoMapper
{
    public class AutoMapperConfig
    {
        protected AutoMapperConfig()
        {
        }

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x =>
            {
                x.AddProfile<ModelToResponseMappingProfile>();
                x.AddProfile<RequestToModelMappingProfile>();
            });
        }
        /*
         public static IMapper GetConfiguration()
    {
        var autoMapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Despesas, DespesasDTO>().ReverseMap();
            cfg.CreateMap<Receitas, ReceitasDTO>().ReverseMap();
        });
        return autoMapperConfig.CreateMapper();
    }
         */
    }
}
