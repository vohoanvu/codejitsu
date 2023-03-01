using System.ComponentModel.DataAnnotations;

namespace CodeJitsu.Controllers.Dtos
{
    public class ViewFighterDto : FighterDtoBase
    {
        public Guid Id { get; set; }
    }
}
