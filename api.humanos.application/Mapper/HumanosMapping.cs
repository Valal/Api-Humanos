using api.humanos.domain.DTOs;
using api.humanos.domain.POCOS.Context;
using AutoMapper;

namespace api.humanos.application.Mapper;

public static class HumanosMapping{
    public static Profile AddHumanosMapping(this Profile profile){
        profile.CreateMap<HumanosModel, HumanosDto>()
        .ForMember(hc => hc.id, opt => opt.MapFrom(db => db.id))
        .ForMember(hc => hc.nombre, opt => opt.MapFrom(db => db.nombre))
        .ForMember(hc => hc.sexo, opt => opt.MapFrom(db => db.sexo))
        .ForMember(hc => hc.edad, opt => opt.MapFrom(db => db.edad))
        .ForMember(hc => hc.altura, opt => opt.MapFrom(db => db.altura))
        .ForMember(hc => hc.peso, opt => opt.MapFrom(db => db.peso));

        return profile;        
    }
}