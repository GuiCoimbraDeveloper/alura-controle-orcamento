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
    }
}
