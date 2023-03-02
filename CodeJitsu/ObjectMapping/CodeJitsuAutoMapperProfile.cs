using AutoMapper;
using CodeJitsu.Controllers.Dtos;
using CodeJitsu.Entities.Fighter;
using CodeJitsu.Services.FighterService.Interfaces;

namespace CodeJitsu.ObjectMapping;

public class CodeJitsuAutoMapperProfile : Profile
{
    public CodeJitsuAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */
        CreateMap<CreateFighterDto, Fighter>()
            .ForMember(x => x.BMI, y => y.MapFrom(z => z.Weight / (z.Height * z.Weight)))
            .ForMember(x => x.Gender, y => y.MapFrom(z => Enum.Parse<Gender>(z.Gender)))
            .ForMember(x => x.Role, y => y.MapFrom(z => Enum.Parse<FighterRole>(z.FighterRole)))
            .ReverseMap();

        CreateMap<UpdateFighterDto, Fighter>()
            .ReverseMap();

        CreateMap<FighterDtoBase, Fighter>().ReverseMap();

        CreateMap<Fighter, ViewFighterDto>()
            .ForMember(x => x.BeltColor, y => y.MapFrom(z => z.BeltRank.Color.ToString()))
            .ForMember(x => x.Stripe, y => y.MapFrom(z => z.BeltRank.Stripe))
            .ForMember(x => x.Gender, y => y.MapFrom(z => z.Gender.ToString()))
            .ForMember(x => x.FighterRole, y => y.MapFrom(z => z.Role.ToString()))
            .ReverseMap();


        CreateMap<BeltRankDto, BeltRank>().ReverseMap();
    }
}
