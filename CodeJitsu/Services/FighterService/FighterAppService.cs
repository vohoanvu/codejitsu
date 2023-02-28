using CodeJitsu.Entities.Fighter;
using CodeJitsu.Services.Dtos;
using CodeJitsu.Services.FighterService.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace CodeJitsu.Services.FighterService
{
    public class FighterAppService : IFighterAppService
    {
        private readonly IRepository<Entities.Fighter.Fighter, Guid> _fighterRepo;
        private readonly IRepository<BeltRank, int> _rankRepo;

        public FighterAppService(IRepository<Entities.Fighter.Fighter, Guid> fighterRepo, IRepository<BeltRank, int> rankRepo)
        {
            _fighterRepo = fighterRepo;
            _rankRepo = rankRepo;
        }

        public async Task<ListResultDto<ViewFighterDto>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ViewFighterDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(CreateFighterDto input)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid id, UpdateFighterDto input)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
