using AutoMapper;

namespace api.humanos.application.Mapper;

public class AutoMapperProfile : Profile{
    public AutoMapperProfile(){
        HumanosMapping.AddHumanosMapping(this);
    }
}