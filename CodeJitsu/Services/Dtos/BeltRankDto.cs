using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace CodeJitsu.Services.Dtos
{
    public class BeltRankDto: EntityDto<int>
    {
        [Required]
        public string Color { get; set; }

        [Required]
        [Range(0, 4)]
        public int Stripe { get; set; }
    }
}
