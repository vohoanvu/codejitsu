using CodeJitsu.Entities.Fighter;
using CodeJitsu.Services.Dtos;
using CodeJitsu.Services.FighterService.Interfaces;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CodeJitsu.Services.FighterService
{
    public class BeltRankAppService :
        CrudAppService<BeltRank, BeltRankDto, int, List<BeltRankDto>, BeltRankDto, BeltRankDto>, IBeltRankAppService
    {
        public BeltRankAppService(IRepository<BeltRank, int> beltRepo) : base(beltRepo)
        {
        }
    }
}
