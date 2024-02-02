using AutoMapper;
using DotNetRpgProject.Model.Dto;
using DotNetRpgProject.Model.Entity;

namespace DotNetRpgProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterDto, Character>();
            CreateMap<Character, Character>();
        }
    }
}
