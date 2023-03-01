using CodeJitsu.Controllers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CodeJitsu.Services.FighterService.Interfaces
{
    public interface IFighterAppService : IApplicationService
    {
        Task<List<ViewFighterDto>> GetListAsync();
        Task<ViewFighterDto> GetAsync(Guid id);
        Task CreateAsync(CreateFighterDto input);
        Task<ViewFighterDto> UpdateAsync(Guid id, UpdateFighterDto input);
        Task DeleteAsync(Guid id);
    }
}
