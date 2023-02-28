using AutoMapper;
using CodeJitsu.Entities.Fighter;
using CodeJitsu.Services.Dtos;

namespace CodeJitsu.ObjectMapping;

public class CodeJitsuAutoMapperProfile : Profile
{
    public CodeJitsuAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */
        CreateMap<CreateFighterDto, Fighter>().ReverseMap();
        CreateMap<UpdateFighterDto, Fighter>().ReverseMap();
        CreateMap<FighterDtoBase, Fighter>().ReverseMap();

        CreateMap<BeltRankDto, BeltRank>().ReverseMap();
    }
}
