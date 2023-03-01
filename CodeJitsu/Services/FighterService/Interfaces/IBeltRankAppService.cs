using CodeJitsu.Controllers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CodeJitsu.Services.FighterService.Interfaces
{
    public interface IBeltRankAppService : 
        ICrudAppService<BeltRankDto, int, PagedAndSortedResultRequestDto, BeltRankDto, BeltRankDto>
    {
        Task<int> GetBeltRankIdAsync(string beltColor, int stripe);
    }
}
