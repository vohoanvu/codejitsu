using CodeJitsu.Controllers.Dtos;
using CodeJitsu.Entities.Fighter;
using CodeJitsu.Services.FighterService.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;

namespace CodeJitsu.Services.FighterService
{
    [DependsOn(typeof(CodeJitsuModule))]
    public class BeltRankAppService :
        CrudAppService<BeltRank, BeltRankDto, int, PagedAndSortedResultRequestDto, BeltRankDto, BeltRankDto>, IBeltRankAppService
    {
        private readonly IRepository<BeltRank, int> _beltRepo;

        public BeltRankAppService(IRepository<BeltRank, int> beltRepo) : base(beltRepo)
        {
            _beltRepo = beltRepo;
        }

        public async Task<int> GetBeltRankIdAsync(string beltColor, int stripe)
        {
            var beltRank = await _beltRepo.GetAsync(b =>
                b.Color == Enum.Parse<BeltColor>(beltColor) && b.Stripe == stripe);

            return beltRank.Id;
        }
    }
}
