using CodeJitsu.Controllers.Dtos;
using CodeJitsu.Entities.Fighter;
using CodeJitsu.Services.FighterService.Interfaces;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;

namespace CodeJitsu.Services.FighterService
{
    [DependsOn(typeof(CodeJitsuModule))]
    public class FighterAppService : ApplicationService, IFighterAppService
    {
        private readonly IRepository<Fighter, Guid> _fighterRepo;
        private readonly IRepository<BeltRank, int> _rankRepo;

        public FighterAppService(IRepository<Fighter, Guid> fighterRepo, 
            IRepository<BeltRank, int> rankRepo)
        {
            _fighterRepo = fighterRepo;
            _rankRepo = rankRepo;
        }

        public async Task<ListResultDto<ViewFighterDto>> GetListAsync()
        {
            var allFighters=  await _fighterRepo.GetListAsync(true);
            return ObjectMapper.Map<List<Fighter>, ListResultDto<ViewFighterDto>>(allFighters);
        }

        public async Task<ViewFighterDto> GetAsync(Guid id)
        {
            var fighter = await _fighterRepo.GetAsync(id);

            if (fighter == null)
            {
                throw new UserFriendlyException("Fighter Not Found!", StatusCodes.Status404NotFound.ToString());
            }

            return ObjectMapper.Map<Fighter, ViewFighterDto>(fighter);
        }

        public async Task CreateAsync(CreateFighterDto input)
        {
            if (!Enum.IsDefined(typeof(Gender), input.Gender) || 
                !Enum.IsDefined(typeof(FighterRole), input.FighterRole) ||
                !Enum.IsDefined(typeof(BeltColor), input.BeltColor))
            {
                throw new UserFriendlyException("Invalid Enum values", StatusCodes.Status400BadRequest.ToString());
            }

            var newFighter = ObjectMapper.Map<CreateFighterDto, Fighter>(input);

            await _fighterRepo.InsertAsync(newFighter);
        }

        public async Task UpdateAsync(Guid id, UpdateFighterDto input)
        {
            if (!Enum.IsDefined(typeof(Gender), input.Gender) ||
                !Enum.IsDefined(typeof(FighterRole), input.FighterRole) ||
                !Enum.IsDefined(typeof(BeltColor), input.BeltColor))
            {
                throw new UserFriendlyException("Invalid Enum values", StatusCodes.Status400BadRequest.ToString());
            }

            var existingFighter = await _fighterRepo.GetAsync(id);

            ObjectMapper.Map(input, existingFighter);

            await _fighterRepo.UpdateAsync(existingFighter);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _fighterRepo.DeleteAsync(id);
        }
    }
}
