using CodeJitsu.Controllers.Dtos;
using CodeJitsu.Entities.Fighter;
using CodeJitsu.ObjectMapping;
using CodeJitsu.Services.FighterService.Interfaces;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CodeJitsu.Services.FighterService
{
    public class FighterAppService : ApplicationService, IFighterAppService
    {
        private readonly IRepository<Fighter, Guid> _fighterRepo;
        private readonly IRepository<BeltRank, int> _rankRepo;
        private readonly IBeltRankAppService _beltRankAppService;

        public FighterAppService(IRepository<Fighter, Guid> fighterRepo, 
            IRepository<BeltRank, int> rankRepo, IBeltRankAppService beltRankAppService)
        {
            _fighterRepo = fighterRepo;
            _rankRepo = rankRepo;
            _beltRankAppService = beltRankAppService;
        }

        public async Task<List<ViewFighterDto>> GetListAsync()
        {
            var query = await _fighterRepo.WithDetailsAsync();
            var allFighters = query.ToList();
            return ObjectMapper.Map<List<Fighter>, List<ViewFighterDto>>(allFighters);
        }

        public async Task<ViewFighterDto> GetAsync(Guid id)
        {
            var query = await _fighterRepo.WithDetailsAsync();
            var fighter = query.FirstOrDefault(f => f.Id == id);
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

        public async Task<ViewFighterDto> UpdateAsync(Guid id, UpdateFighterDto input)
        {
            if (!Enum.IsDefined(typeof(Gender), input.Gender) ||
                !Enum.IsDefined(typeof(FighterRole), input.FighterRole) ||
                !Enum.IsDefined(typeof(BeltColor), input.BeltColor))
            {
                throw new UserFriendlyException("Invalid Enum values", StatusCodes.Status400BadRequest.ToString());
            }

            var existingFighter = await _fighterRepo.GetAsync(id);
            existingFighter.Update(input);
            existingFighter.BeltRankId = await _beltRankAppService.GetBeltRankIdAsync(input.BeltColor, input.Stripe);

            var updatedFighter = await _fighterRepo.UpdateAsync(existingFighter);
            return ObjectMapper.Map<Fighter, ViewFighterDto>(updatedFighter); //Error: updatedFighter did not include BeltRank data
        }

        public async Task DeleteAsync(Guid id)
        {
            await _fighterRepo.DeleteAsync(id);
        }
    }
}
