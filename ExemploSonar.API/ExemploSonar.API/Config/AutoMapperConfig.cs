using AutoMapper;
using ExemploSonar.API.DTOs.Requests;
using ExemploSonar.API.DTOs.Responses;
using ExemploSonar.API.Entities;

namespace ExemploSonar.API.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegistroRequest, Registro>().ReverseMap();

            CreateMap<Registro, RegistroResponse>().ReverseMap();
        }
    }
}
