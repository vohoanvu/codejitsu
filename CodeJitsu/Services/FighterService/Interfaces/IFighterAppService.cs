using CodeJitsu.Controllers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CodeJitsu.Services.FighterService.Interfaces
{
    public interface IFighterAppService : IApplicationService
    {
        Task<ListResultDto<ViewFighterDto>> GetListAsync();
        Task<ViewFighterDto> GetAsync(Guid id);
        Task CreateAsync(CreateFighterDto input);
        Task UpdateAsync(Guid id, UpdateFighterDto input);
        Task DeleteAsync(Guid id);
    }
}
