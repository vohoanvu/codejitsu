using CodeJitsu.Services.Dtos;
using Volo.Abp.Application.Services;

namespace CodeJitsu.Services.FighterService.Interfaces
{
    public interface IBeltRankAppService : ICrudAppService<BeltRankDto, int, List<BeltRankDto>, BeltRankDto, BeltRankDto>
    {
    }
}
